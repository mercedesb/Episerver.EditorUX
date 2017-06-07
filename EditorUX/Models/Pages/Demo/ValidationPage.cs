namespace EditorUX.Models.Pages
{
    /// <summary>
    /// Used primarily for publishing news articles on the website
    /// </summary>
    [SiteContentType(
        GroupName = Global.GroupNames.Demo,
        GUID = "ED049FC7-1211-409F-96B9-EE63E9D5C8F3")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-article.png")]
    public class ValidationPage : StandardPage
    {
    }
}