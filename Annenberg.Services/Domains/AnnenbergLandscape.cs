using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annenberg.Services.Domains
{
    public class AnnenbergLandscape
    {
        public int Id { get; set; }
        public string Organization { get; set; }
        public string Functions { get; set; }
        public string Approach { get; set; }
        public string OrganizationType { get; set; }
        public string OrganizationType2 { get;  set; }
        public string AreaOfFocus { get; set; }
        public string Beneficiary { get;  set; }
        public string Beneficiary2 { get; set; }
        public string BeneficiaryPopNum { get; set; }
        public string Geography { get;  set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
