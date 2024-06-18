using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Models
{
    public class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException() : base("Montant doit être positif") { }
    }
}
