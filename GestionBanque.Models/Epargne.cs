using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    internal class Epargne : Compte
    {
        #region Champs

        private DateTime _dateDernierRetrait;

        public Epargne(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }

        public static double TauxEpargne { get { return 0.045; } }
        
        #endregion

        #region Propriétés

        public DateTime DateDernierRetrait
		{
			get { return _dateDernierRetrait; }
			private set { _dateDernierRetrait = value; }
		}

        #endregion

        #region Méthodes

        #region Gestion de l'argent

        /// <summary>
        /// Retirer de l'argent du solde et enregistrer la date de dernier retrait
        /// </summary>
        /// <param name="montant"></param>
        public override void Retrait(double montant)
        {
            // Vérification si le solde dépasse la ligne de crédit
            if (montant > Solde)
            {
                throw new Exception("Vous avez dépassé le Solde");
            }

            double oldSolde = Solde;
            
            base.Retrait(montant);
            
            // Vérification si le solde a été changé
            if (Solde != oldSolde) 
            {
                DateDernierRetrait = DateTime.Now;
            }
        }

        /// <summary>
        /// Calculer l'intérêt de taux 4.5%
        /// </summary>
        /// <returns></returns>
        protected override double CalculerInteret()
        {            
            return Solde * TauxEpargne;
        }

        #endregion

        #endregion
    }
}
