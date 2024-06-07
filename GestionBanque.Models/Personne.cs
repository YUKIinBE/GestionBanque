using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Personne
    {
        #region Chapms

        private string _nom;
        private string _prenom;
        private DateTime _dateNaiss;

        #endregion

        #region Propriétés

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public DateTime DateNaiss
        {
            get { return _dateNaiss; }
            set 
            {
                // Vérifier si la personne est majeur
                TimeSpan temp = DateTime.Now - DateNaiss;
                int age = (int)(temp.TotalDays / 365.25);
                if (age >= 18)
                {
                    _dateNaiss = value;
                }
                else 
                {
                    throw new Exception("Vous n'êtes pas majeur. Impossible de créer un compte");
                }
            }
        }

        #endregion

        #region Méthodes

        #region Surcharge d'opérateur

        /// <summary>
        /// Vérifier si les deux Personnes sont les mêmes
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Personne p1, Personne p2)
        {
            return p1.Nom == p2.Nom && p1.Prenom == p2.Prenom && p1.DateNaiss == p2.DateNaiss;
           
        }

        /// <summary>
        /// Vérifier si les deux Personnes ne sont pas les mêmes
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Personne p1, Personne p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #endregion
    }
}