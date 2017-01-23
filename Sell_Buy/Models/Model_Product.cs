using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sell_Buy.Models
{
    public class Model_Product
    {
        [Required]
        [Display(Name = "Название")]
        public string NameMagazine { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }


        [Required]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Валюта")]
        public string Currency { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Производитель")]
        public string Producer { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Фото")]
        public string Photo { get; set; }

    
    }
}