using E_Okul.Entity.Concretes;
using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;

namespace E_Okul.UI.Models
{
    public class TeacherModel
    {
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        public Teachers Teachers { get; set; }
        public string Head { get; set; }
        public string Text { get; set; }
        public string Cls { get; set; }
    }
}
