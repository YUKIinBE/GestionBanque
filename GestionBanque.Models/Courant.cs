namespace GestionBanque.Models
{
    public class Courant : Compte
    {
        #region Chapms

        private double _ligneDeCredit;

        #endregion

        #region Propriétés

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

        #endregion

        #endregion
    }
}
