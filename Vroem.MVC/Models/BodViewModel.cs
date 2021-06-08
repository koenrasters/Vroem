using System;
using System.ComponentModel.DataAnnotations;

namespace Vroem.MVC.Models
{
    public class BodViewModel
    {
        public int AutoID { get; set; }
        [Required(ErrorMessage = "Vul een prijs in om een bod te kunnen doen")]
        public int Prijs { get; set; }
    }
}