using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestBanque
{
    internal class Courant
    {
        #region Attributs
        private string _Numero;
        private double _Solde;
        private double _LigneDeCredit;
        private Personne _Titulaire;
        #endregion

        #region Properties
        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        public double Solde
        {
            get { return _Solde; }
            private set { _Solde = value; }
        }
        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            set { _LigneDeCredit = value; }
        }
        public Personne Titulaire
        {
            get { return _Titulaire; }
            set { _Titulaire = value; }
        }
        #endregion

        #region Methods

        #region Gestion de l'argent
        public void Retrait(double Montant)
        {
            if(Solde > Montant)
            {
                Solde -= Montant;
            }
            else if (Solde + LigneDeCredit > Montant)
            {
                Console.WriteLine("Vous touchez maintenant le crédit");
                Solde -= Montant;
            }
            else
            {
                Console.WriteLine("Vous avez dépassé la limite");
            }

            Console.WriteLine($"Votre Solde : {Solde}");
        }
        public void Depot(double Montant)
        {
            Solde += Montant;
            Console.WriteLine($"Votre Solde : {Solde}");
        }
        #endregion

        #endregion
    }
}
