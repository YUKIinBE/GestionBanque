using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionBanque.Models
{
    public class Banque
    {

		#region Chapms
		private string _Nom;
		private List<Courant> _Courants = new List<Courant>();
		#endregion

		#region Propriétés
		public string Nom
		{
			get { return _Nom; }
			set { _Nom = value; }
		}
		private List<Courant> Courants
		{
			get { return _Courants; }
			set { _Courants = value; }
		}
        #endregion

        #region Indexeur de list Courants
        public Courant? this[string numeroCompte]
		{
			get
			{
				// Parcourir la liste Courants pour trouver le compte souhaité récupérer

				Courant? compte = Courants.SingleOrDefault(c => c.Numero == numeroCompte);

				// Traiter le cas "null"

				if (compte is null)
				{
					throw new KeyNotFoundException("Le numéro n'est enregistré pas");
				}

				return compte;
			}
		}
        #endregion

        #region Methods

        #region Gestion de lists Courants
		/// <summary>
		/// Ajouter un nouveau compte à la liste Courants
		/// </summary>
		/// <param name="compte"></param>
		/// <exception cref="ArgumentException"></exception>
        public void Ajouter(Courant compte)
		{
			// Vérifier si le compte n'existe pas dans la liste Courants

			if (Courants.Any(c => c.Numero == compte.Numero))
			{
				throw new ArgumentException("Le numéro de compte existe déjà");
            }

			Courants.Add(compte);
		}

		/// <summary>
		/// Supprimer un compte de la liste Courants
		/// </summary>
		/// <param name="numeroCompte"></param>
		/// <exception cref="KeyNotFoundException"></exception>
		public void Supprimer(string numeroCompte)
		{
			// Parcourir la liste Courants pour trouver le compte souhaité supprimer

			Courant? compte = Courants.FirstOrDefault(c => c.Numero == numeroCompte);

            if (compte is null)
			{
                throw new KeyNotFoundException("Le numéro n'est pas enregistré");
            }

			Courants.Remove(compte);
        }
        #endregion

        #region Recherche d'info

		/// <summary>
		/// Calculer la somme de tous les soldes de comptes possédés par le même titulaire
		/// </summary>
		/// <param name="titulaire"></param>
		/// <returns> double : la somme de tous les soldes </returns>
        public double AvoirDesComptes(Personne titulaire)
        {
			// Créer une liste temp et stocker tous les comptes trouvés avec le même titulaire
            List<Courant> ComptesDeMemePersonne = new List<Courant>();
            ComptesDeMemePersonne = Courants.Where(c => c.Titulaire == titulaire).ToList();

			// Calculer la somme des soldes
			double sommeAvoirs = 0;
			foreach (var compte in ComptesDeMemePersonne)
			{
				sommeAvoirs += compte;
			}

			return sommeAvoirs;

		}
        #endregion

        #endregion


    }
}
