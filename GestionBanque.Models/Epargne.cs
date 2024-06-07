﻿using System;
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

        #endregion

        #endregion
    }
}