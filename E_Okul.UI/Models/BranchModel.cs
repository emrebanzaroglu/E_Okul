using E_Okul.Entity.Concretes;
using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;

namespace E_Okul.UI.Models
{
    public class BranchModel
    {
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        public Branches Branches { get; set; }
        public string Head { get; set; }
        public string Text { get; set; }
        public string Cls { get; set; }
    }
}
