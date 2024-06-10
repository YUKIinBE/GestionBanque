using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public interface IBanker : ICustomer
    {
		public Personne Titulaire { get; }
		public string Numero { get; }

		public void AppliquerInteret();
    }
}
