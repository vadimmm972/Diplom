using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sell_Buy.Models
{
    public class Modal_Magazine
    {
       [Required]
        [Display(Name = "Названия магазина")]
        public string NameMagazine { get; set; }

        [Display(Name = "Фото для магазина")]
        public string PhotoMagazine { get; set; }


    }
}