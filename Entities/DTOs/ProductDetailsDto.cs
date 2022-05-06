using Core.Entites;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
    public class ProductDetailsDto : Product,IDto
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string CategoryName { get; set; }
        public string ProductImage { get; set; }
        public int CategoryEqualProductTranslateID { get; set; }
    }
}
