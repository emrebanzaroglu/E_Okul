using E_Okul.Entity.Concretes;
using System.ComponentModel.DataAnnotations;

namespace E_Okul.UI.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        public Students Students { get; set; }
        public Branches Branches { get; set; }
        public Teachers Teachers { get; set; }
        public string Head { get; set; }
        public string Text { get; set; }
        public string Cls { get; set; }
    }
}
