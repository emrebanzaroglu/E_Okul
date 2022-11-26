using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Entity.Concretes
{
    public class Branches
    {
        [Key]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public ICollection<Students> Students { get; set; }
        public ICollection<Teachers> Teachers { get; set; }
    }
}
