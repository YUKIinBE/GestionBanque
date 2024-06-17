using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class CarteDeCredit : IPaiement
    {
        #region Champs

        private Personne _titulaire;
        private DateTime _dateExpiration;

        #endregion

        #region Propriétés

        public Personne Titulaire
		{
			get { return _titulaire; }
			set { _titulaire = value; }
		}
        public DateTime DateExpiration
        {
            get { return _dateExpiration; }
            set { _dateExpiration = value; }
        }

        public bool EffectuerPaiement(Compte emetteur, Compte receveur, double montant)
        {
            // Vérifier si la date d'expiration dépasse la date cette opération
            if (DateExpiration > DateTime.Now) 
            {
                throw new Exception("La date d'expiration est passée");
            }

            // Vérifier si le montant est négaitf
            if (montant < 0)
            {
                throw new Exception("Le montant doit être positif");
            }

            // Vérifier si le montant dépasse le solde d'emetteur
            if(montant > emetteur.Solde)
            {
                throw new Exception("L'argent dans le compte n'est pas assez");
            }

            Console.WriteLine($"Transaction de {montant} euros de {emetteur.Titulaire.Prenom} {emetteur.Titulaire.Prenom} vers {receveur.Titulaire.Prenom} {receveur.Titulaire.Nom} avec {this.GetType} réussie");

            return true;
        }

        #endregion
    }
}
