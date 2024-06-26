﻿using System.Collections.Generic;
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

		private string _nom;
		private List<Compte> _comptes = new List<Compte>();

		#endregion

		#region Propriétés

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}
		public List<Compte> Comptes
		{
			get { return _comptes; }
			private set { _comptes = value; }
		}

        #endregion

        #region Indexeur de la liste Comptes

		/// <summary>
		/// Indexeur de la liste Comptes
		/// </summary>
		/// <param name="numeroCompte"></param>
		/// <returns>Compte lié au numéro de compte</returns>
		/// <exception cref="KeyNotFoundException"></exception>
        public Compte? this[string numeroCompte]
		{
			get
			{
				// Parcourir la liste Comptes pour trouver le compte souhaité récupérer
				Compte? compte = Comptes.SingleOrDefault(c => c.Numero == numeroCompte);

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

        #region Gestion de liste Courants

		/// <summary>
		/// Ajouter un nouveau compte à la liste Comptes
		/// </summary>
		/// <param name="compte"></param>
		/// <exception cref="ArgumentException"></exception>
        public void Ajouter(Courant compte)
		{
			// Vérifier si le numéro de compte est null
			if (compte.Numero is null)
			{
				throw new ArgumentException("Le numéro de compte ne peut pas être null");
			}

            // Vérifier si le compte existe dans la liste Comptes
            if (Comptes.Any(c => c.Numero == compte.Numero))
			{
				throw new ArgumentException("Le numéro de compte existe déjà");
            }

            Console.WriteLine("Le compte a été ajouté à la liste");
            Comptes.Add(compte);

			compte.PassageEnNegatifEvent += PassageEnNegatifAction;
		}

		/// <summary>
		/// Supprimer un compte de la liste Comptes
		/// </summary>
		/// <param name="numeroCompte"></param>
		/// <exception cref="KeyNotFoundException"></exception>
		public void Supprimer(string numeroCompte)
		{
			// Parcourir la liste Courants pour trouver le compte souhaité supprimer
			Compte? compte = Comptes.FirstOrDefault(c => c.Numero == numeroCompte);

            if (compte is null)
			{
                throw new KeyNotFoundException("Le numéro n'est pas enregistré");
            }

            Console.WriteLine("Le compte a été supprimé de la liste");
            Comptes.Remove(compte);
        }

		public void PassageEnNegatifAction(Compte compte)
		{
            Console.WriteLine($"Le compte {compte.Numero} vient de passer en négatif");
        }

        #endregion

        #region Recherche d'info

        /// <summary>
        /// Calculer la somme de tous les soldes de comptes possédés par le même titulaire
        /// </summary>
        /// <param name="titulaire"></param>
        /// <returns></returns>
        public double AvoirDesComptes(Personne titulaire)
        {
			// Créer une liste temp et stocker tous les comptes trouvés avec le même titulaire
            List<Compte> comptesDeMemePersonne = new List<Compte>();
            comptesDeMemePersonne = Comptes.Where(c => c.Titulaire == titulaire).ToList();

			// Calculer la somme des soldes
			double sommeAvoirs = 0;
			foreach (var compte in comptesDeMemePersonne)
			{
				sommeAvoirs += compte;
			}

			return sommeAvoirs;

		}

		public static void AfficherInfo(Compte compte)
		{
			if(compte is Courant)
			{
				// Vérifier quel taux à appliquer (positif ou négatif)
				double temp = (compte.Solde > 0) ? Courant.TauxCourantPositif : Courant.TauxCourantNegatif;

                Console.WriteLine($"C'est un compte Courant.");
				Console.WriteLine($"Chaque année un taux d'intérêt de {temp:P}");
				return;
            }
            else if (compte is Epargne)
            {
                Console.WriteLine($"C'est un compte Courant.");
                Console.WriteLine($"Chaque année un taux d'intérêt de {Epargne.TauxEpargne:P}");
                return;
            }
        }

        #endregion

        #endregion


    }
}
