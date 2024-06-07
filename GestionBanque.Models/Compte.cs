using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Compte
    {
        #region Champs

        private string _numero;
        private double _solde;
        private Personne _titulaire;

        #endregion

        #region Propriétés

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public double Solde
        {
            get { return _solde; }
            private set { _solde = value; }
        }
        public Personne Titulaire
        {
            get { return _titulaire; }
            set { _titulaire = value; }
        }

        #endregion

        #region Méthodes

        #region Surcharge d'opérateur

        /// <summary>
        /// Additionner montant et solde d'un compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="compte"></param>
        /// <returns></returns>
        public static double operator +(double montant, Compte compte)
        {
            if (compte.Solde < 0) compte.Solde = 0;

            double somme = montant + compte.Solde;
            return somme;
        }

        #endregion

        #region Gestion de l'argent

        /// <summary>
        /// Retirer de l'argent du solde
        /// </summary>
        /// <param name="montant"></param>
        public virtual void Retrait(double montant)
        {
            // Vérification de montant demandé
            if (montant >= 0)
            {
                Console.WriteLine("Montant doit être positif");
                return;
            }

            // Vérification de l'argent disponible
            if (Solde > montant)
            {
                Solde -= montant;
            }
            else
            {
                throw new Exception("Vous avez dépassé la limite");
            }

            // Affichage de solde restant
            Console.WriteLine($"Votre Solde : {Solde}");
        }
        /// <summary>
        /// Retirer tout l'argent dans le compte Epargne-Pension
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Retrait()
        {
            Console.WriteLine($"Vous avez {Solde} dans le compte. 33% sera déduit de ce montant");
            Console.WriteLine($"Voici votre argent : {Solde - (Solde * 0.33)}");
            Solde = 0;
        }

        /// <summary>
        /// Ajouter de l'argent au solde
        /// </summary>
        /// <param name="montant"></param>
        public virtual void Depot(double montant)
        {
            // Vérification de l'argent déposé
            if (montant > 0)
            {
                Solde += montant;
            }
            else
            {
                throw new Exception("Le montant doit être positif");
            }
            Console.WriteLine($"Votre Solde : {Solde}");
        }

        #endregion

        #endregion
    }
}
