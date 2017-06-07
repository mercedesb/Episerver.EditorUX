using EditorUX.Business.Attributes;
using EditorUX.Business.EditorDescriptors;
using EditorUX.Business.Selection;
using EditorUX.Models.Properties;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EditorUX.Models.Pages
{
    /// <summary>
    /// Used primarily for publishing news articles on the website
    /// </summary>
    [SiteContentType(
        GroupName = Global.GroupNames.Demo,
        GUID = "38503501-D035-440E-A5E1-CBF0BA898459")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-ux.png")]
    public class UXPage : StandardPage
    {
        [Display(
           Name = "More specific main body name<br/><small>inherited from Standard Page</small>",
           GroupName = SystemTabNames.Content,
           Order = 310)]
        [CultureSpecific]
        [Required]
        public override XhtmlString MainBody { get; set; }

        [Display(
           Name = "Property with description",
            Description = "This is a description that might describe how the property is used or the tone the text should have, etc.",
           GroupName = SystemTabNames.Content,
           Order = 320)]
        [CultureSpecific]
        public virtual string ExamplePropertyDescription { get; set; }

        [Display(
           Name = "File<br/><small>sample media file UIHint</small>",
           GroupName = SystemTabNames.Content,
           Order = 320)]
        [UIHint(UIHint.MediaFile)]
        public virtual ContentReference ExampleUIHint { get; set; }

        [Display(
           Name = "Date Only",
           GroupName = SystemTabNames.Content,
           Order = 330)]
        [UIHint(MakingWavesUIHint.DateOnly)]
        public virtual DateTime ExampleDateOnly { get; set; }

        [Display(
            Name = "Day of Week<br/><small>sample enum editor</small>",
           GroupName = SystemTabNames.Content,
           Order = 330)]
        [DayOfWeekSelection]
        public virtual DayOfWeek ExampleEnum { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Autocomplete",
           GroupName = SystemTabNames.Content,
           Order = 340)]
        // TODO: test this
        [BackingType(typeof(PropertyStringListNonAlloy))]
        [AutocompleteList(typeof(DemoSelectionQuery))]
        [UIHint(MakingWavesUIHint.AutocompleteList)]
        public virtual IEnumerable<string> ExampleAutocomplete { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image with label list",
           GroupName = SystemTabNames.Content,
           Order = 350)]
        public virtual IList<ImageWithLabel> ExampleIList { get; set; }
    }
}