using EPiServer.Core;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace EditorUX.Models
{
    public class ImageWithLabel
    {
        [Display(Name = "Desktop Image", Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(
            Name = "Mobile Image",
            Order = 115)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference MobileImage { get; set; }

        [Display(Name = "Label", Order = 120)]
        public virtual string Label { get; set; }
    }
}
