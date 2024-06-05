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
        #region Field
        private string _Nom;
        private string _Prenom;
        private DateTime _DateNaiss;

        #endregion

        #region Properties

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }
        public string Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value; }
        }
        public DateTime DateNaiss
        {
            get { return _DateNaiss; }
            set 
            {
                // Vérifier si la personne est majeur
                TimeSpan temp = DateTime.Now - DateNaiss;
                int age = (int)(temp.TotalDays / 365.25);
                if (age >= 18)
                {
                    _DateNaiss = value;
                }
                else 
                {
                    Console.WriteLine("Vous n'êtes pas majeur. Impossible de créer un compte");
                }
            }
        }
        #endregion
    }
}
