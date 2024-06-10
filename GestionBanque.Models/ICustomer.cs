using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public interface ICustomer
    {
        public double Solde { get; }

        /// <summary>
        /// Ajouter de l'argent au solde
        /// </summary>
        /// <param name="montant"></param>
        public void Depot(double montant);

        /// <summary>
        /// Ajouter de l'argent au solde
        /// </summary>
        /// <param name="montant"></param>
        /// <summary>
        /// Retirer tout l'argent dans le compte Epargne-Pension
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Retrait(double montant);
    }
}
