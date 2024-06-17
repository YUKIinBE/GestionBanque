using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public interface IPaiement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emetteur"></param>
        /// <param name="receveur"></param>
        /// <param name="montant"></param>
        /// <returns></returns>
        public bool EffectuerPaiement(Compte emetteur, Compte receveur, double montant)
        {
            // Vérifier si le montant est négaitf
            if (montant < 0)
            {
                throw new Exception("Le montant doit être positif");
            }

            // Vérifier si le montant dépasse le solde d'emetteur
            if (montant > emetteur.Solde)
            {
                throw new Exception("L'argent dans le compte n'est pas assez");
            }

            Console.WriteLine($"Transaction de {montant} euros de {emetteur.Titulaire.Prenom} {emetteur.Titulaire.Prenom} vers {receveur.Titulaire.Prenom} {receveur.Titulaire.Nom} avec {this.GetType} réussie");

            return true;
        }
    }
}
