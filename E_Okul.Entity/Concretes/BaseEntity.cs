using E_Okul.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Entity.Concretes
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? Picture { get; set; }
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
