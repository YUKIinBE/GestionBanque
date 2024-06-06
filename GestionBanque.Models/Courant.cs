namespace GestionBanque.Models
{
    public class Courant
    {
        #region Field
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
            private set
            {
                // Vérification si le solde ne dépasse pas la ligne de crédit
                if (value > - LigneDeCredit)
                {
                    _Solde = value;
                }
                else 
                {
                    Console.WriteLine("Vous dépassez la ligne de crédit");
                }
            }
        }
        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            set
            {
                // Vérification si la ligne de crédit est positif
                if (value > 0)
                {
                    _LigneDeCredit = value;
                }
                else
                {
                    Console.WriteLine("Votre ligne de crédit doit être positif");
                }
            }
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
            // Vérification de montant demandé
            if(Montant > 0)
            {
                return;
            }

            // Vérification de l'argent disponible
            if (Solde > Montant)
            {
                Solde -= Montant;
            }
            else
            {
                Console.WriteLine("Vous avez dépassé la limite");
            }

            // Affichage de solde restant
            Console.WriteLine($"Votre Solde : {Solde}");
        }
        public void Depot(double Montant)
        {
            // Vérification de l'argent déposé
            if (Montant > 0)
            {
                Solde += Montant;
            }
            else
            {
                Console.WriteLine("Le montant doit être positif");
            }
            Console.WriteLine($"Votre Solde : {Solde}");
        }
        #endregion

        #region Surcharge d'opérateur
        /// <summary>
        /// Additionner montant et solde d'un compte
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="compte"></param>
        /// <returns> La somme </returns>
        public static double operator +(double amount, Courant compte)
        {
            if (compte.Solde < 0) compte.Solde = 0;

            double somme = amount + compte.Solde;
            return somme;
        }

        #endregion

        #endregion
    }
}
