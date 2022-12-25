using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.HomePage
{
    public class HomePageImage : BaseEntity
    {
        public string ImageSrc { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }

    public enum ImageLocation 
    {
        /// <summary>
        /// عکس سمت چپ اسلایدر ====> تصویر بالایی
        /// </summary>
        چپ_اسلایدر_تصویر_بالا = 0,

        /// <summary>
        /// عکس سمت چپ اسلایدر ====> تصویر پایینی
        /// </summary>
        چپ_اسلایدر_تصویر_پایین = 1,

        /// <summary>
        /// عکس پایین و سمت راست اسلایدر
        /// </summary>
        پایینِ_اسلایدر_تصویر_راست = 2,

        /// <summary>
        /// عکس مرکزی صفحه که کل صفحه رو می پوشونه 
        /// </summary>
        عکسِ_کشیده_وسط_صفحه = 3,

        /// <summary>
        /// دسته بندی و مجموعه ای از عکس ها 
        /// </summary>
        گروه_اول = 4,

        /// <summary>
        /// دسته بندی مجموعه ای از عکس ها 2 
        /// </summary>
        گروه_دوم = 5,

    }
}
