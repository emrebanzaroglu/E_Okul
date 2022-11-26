using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Entity.Concretes
{
    public class Students:BaseEntity
    {
        public int SchoolNo { get; set; }
        public int TCNo { get; set; }
        [ForeignKey("BranchId")]
        public Branches Branches { get; set; }
    }
}
