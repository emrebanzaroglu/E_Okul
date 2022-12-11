using E_Okul.Entity.Concretes;
using System.ComponentModel.DataAnnotations;

namespace E_Okul.UI.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        public Students Students { get; set; }
        public List<Branches> Branches { get; set; }
        public List<Teachers> Teachers { get; set; }
        public string Head { get; set; }
        public string Text { get; set; }
        public string Cls { get; set; }
    }
}
