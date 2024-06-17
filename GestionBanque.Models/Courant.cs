namespace GestionBanque.Models
{
    public class Courant : Compte
    {
        #region Chapms

        private double _ligneDeCredit;

        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }

        public Courant(string numero, Personne titulaire, double ligneDeCredit) : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        #endregion



        #region Propriétés

        public static double TauxCourantPositif => 0.03;
        public static double TauxCourantNegatif => 0.0975;

        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set
            {
                // Vérification si la ligne de crédit est positif
                if (value > 0)
                {
                    _ligneDeCredit = value;
                }
                else
                {
                    Console.WriteLine("Votre ligne de crédit doit être positif");
                }
            }
        }

        #endregion

        #region Méthodes

        #region Gestion de l'argent

        public override void Retrait(double montant)
        {
            // Vérification si le solde dépasse la ligne de crédit
            if (montant > Solde + LigneDeCredit)
            {
                throw new Exception("Vous dépassez la ligne de crédit");
            }
            
            base.Retrait(montant);
        }

        /// <summary>
        /// Calculer l'intérêt de taux 3% pour le Solde en positif et 9.75% en négatif
        /// </summary>
        /// <returns></returns>
        protected override double CalculerInteret()
        {
            return (Solde > 0)? Solde * TauxCourantPositif : Solde * TauxCourantNegatif;
        }
        #endregion

        #endregion
    }
}
