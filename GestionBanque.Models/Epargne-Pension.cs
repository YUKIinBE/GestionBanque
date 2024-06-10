using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class Epargne_Pension : Compte
    {
        #region Champs

        private DateTime _dateDeDernierDepot;
		private double _montantMensuelMax;

        #endregion

        #region Propriétés

        public DateTime DateDeDernierDepot
		{
			get { return _dateDeDernierDepot; }
			private set { _dateDeDernierDepot = value; }
		}
        public double MontantMensuelMax
        {
            get { return _montantMensuelMax; }
            set { _montantMensuelMax = value; }
        }

        #endregion

        #region Méthodes

        #region Gestion de l'argent

        public override void Depot(double montant)
        {
            // Vérification si le dépot a été déjà fait dans le même mois
            if (DateDeDernierDepot.Year == DateTime.Now.Year && DateDeDernierDepot.Month == DateTime.Now.Month)
            {
                throw new Exception("Vous avez déjà déposé de l'argent ce mois-ci");
            }

            // Vérification si le montant à déposer dépasse le montant maximum d'un mois
            if(montant > MontantMensuelMax)
            {
                throw new Exception("Vous ne pouvez pas dépasser le montant maximum d'un mois");
            }

            // Ajout de l'argent au solde et enregistrement de la date de l'opération
            base.Depot(montant);

            DateDeDernierDepot = DateTime.Now;
        }

        protected override double CalculerInteret()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
