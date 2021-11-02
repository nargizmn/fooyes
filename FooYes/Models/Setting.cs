using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string HeaderLogo { get; set; }
        [StringLength(maximumLength: 50)]
        public string HeaderColorfulLogo { get; set; }
        [StringLength(maximumLength: 50)]
        public string HomeHeroSecBgImg { get; set; }
        [StringLength(maximumLength: 100)]
        public string HomeHeroSecTitle { get; set; }
        [StringLength(maximumLength: 200)]
        public string HomeHeroSecSubtitle { get; set; }
        [StringLength(maximumLength: 50)]
        public string HomeBannerSecBgImg { get; set; }
        [StringLength(maximumLength: 100)]
        public string HomeBannerSecTitle { get; set; }
        [StringLength(maximumLength: 200)]
        public string HomeBannerSecSubtitle { get; set; }
        [StringLength(maximumLength: 200)]
        public string HomeBannerSecDesc { get; set; }
        [StringLength(maximumLength: 100)]
        public string HomeOrderSecTitle { get; set; }
        [StringLength(maximumLength: 300)]
        public string HomeOrderSecSubtitle1 { get; set; }
        [StringLength(maximumLength: 300)]
        public string HomeOrderSecSubtitle2 { get; set; }
        [StringLength(maximumLength: 100)]
        public string Address { get; set; }
        [StringLength(maximumLength: 50)]
        public string Phone { get; set; }
        [StringLength(maximumLength: 50)]
        public string Email { get; set; }
        [StringLength(maximumLength: 50)]
        public string WorkWithUsHeroSecBgImg { get; set; }
        [StringLength(maximumLength: 100)]
        public string WorkWithUsHeroSecTitle { get; set; }
        [StringLength(maximumLength: 200)]
        public string WorkWithUsHeroSecSubtitle { get; set; }
        [StringLength(maximumLength: 100)]
        public string ContactHeroSecBgImg { get; set; }
        [StringLength(maximumLength: 100)]
        public string ContactHeroSecTitle { get; set; }
        [StringLength(maximumLength: 200)]
        public string ContactHeroSecSubtitle { get; set; }
        public string ContactMapUrl { get; set; }
        public string JobTerms { get; set; }


        [NotMapped]
        public IFormFile HeaderLogoImgFile { get; set; }
        [NotMapped]
        public IFormFile HeaderColorfulLogoImgFile { get; set; }
        [NotMapped]
        public IFormFile HomeHeroSecBgImgFile { get; set; }
        [NotMapped]
        public IFormFile HomeBannerSecBgImgFile { get; set; }
        [NotMapped]
        public IFormFile WorkWithUsHeroSecBgImgFile { get; set; }
        [NotMapped]
        public IFormFile ContactHeroSecBgImgFile { get; set; }
    }
}
