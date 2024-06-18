using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public abstract class Compte : IBanker
    {
        #region Champs

        private string _numero;
        private double _solde;
        private Personne _titulaire;


        #region Événement & Action et Func
        //public event PassageEnNegatifDelegate PassageEnNegatifEvent;
        public event Action<Compte> PassageEnNegatifEvent;

        //Action raisePassageEnNegatif = () => { PassageEnNegatifEvent(); };

        #endregion

        #endregion

        #region Constructeur

        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        public Compte(string numero, Personne titulaire, double solde)
        {
            Numero = numero;
            Titulaire = titulaire;
            Solde = solde;
        }

        #endregion

        #region Propriétés

        public string Numero
        {
            get { return _numero; }
            private set { _numero = value; }
        }
        public double Solde
        {
            get { return _solde; }
            private set { _solde = value; }
        }
        public Personne Titulaire
        {
            get { return _titulaire; }
            private set { _titulaire = value; }
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
            if (montant <= 0)
            {
                throw new SoldeInsuffisantException();
                return;
            }

            Solde -= montant;

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
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Le montant doit être positif");
            }

            Solde += montant;
            Console.WriteLine($"Votre Solde : {Solde}");
        }
        /// <summary>
        /// Calculer l'intérêt de taux différents en fonction de type de comptes
        /// </summary>
        /// <returns></returns>
        protected abstract double CalculerInteret();

        public void AppliquerInteret()
        {
            double interetCalcule = CalculerInteret();
            Console.WriteLine($"Interet calculé : {interetCalcule}");
            Solde += interetCalcule;
        }

        protected void RaisePassageEnNegatif()
        {
            if (PassageEnNegatifEvent != null)
            {
                PassageEnNegatifEvent?.Invoke(this);
            }
        }

        #endregion

        #region Recherche d'info

        #endregion

        #endregion
    }
}
