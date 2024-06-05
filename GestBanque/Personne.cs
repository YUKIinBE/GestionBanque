using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestBanque
{
    internal class Personne
    {
        #region Attributs
        private string _Nom;
        private string _Prenom;
		private DateTime _DateNaiss;

        #endregion

        #region Properties
        public string Nom
		{
			get { return _Nom; }
			set { _Nom = value; }
		}
		public string Prenom
		{
			get { return _Prenom; }
			set { _Prenom = value; }
		}
        public DateTime DateNaiss
        {
            get { return _DateNaiss; }
            set { _DateNaiss = value; }
        }
        #endregion
    }
}
