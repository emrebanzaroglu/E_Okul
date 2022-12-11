using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Dto
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
        public int TCNo { get; set; }
        public int SchoolNo { get; set; }
    }
}
