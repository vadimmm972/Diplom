using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sell_Buy.Models
{
    public class Modal_Registration
    {
       [Required]
        [Display(Name = "Фамилия")]
        public string NameFirst { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string NameLast { get; set; }

       
        [Display(Name = "Отчество")]
        public string NameMiddle { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Электронная почта")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Регион")]
        public string Region { get; set; }
       [Required]
        [Display(Name = "Город")]
        public string Sity { get; set; }

        [Display(Name = "Язык ")]
        public string Language { get; set; }

        [Display(Name = "Фотография ")]
        public string Image { get; set; }
    }
}