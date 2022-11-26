using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Entity.Concretes
{
    public class Teachers:BaseEntity
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        [ForeignKey("BranchId")]
        public Branches Branches { get; set; }
    }
}
