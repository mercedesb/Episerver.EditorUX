using EditorUX.Business.Attributes;
using EditorUX.Business.Metadata;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Shell.ObjectEditing;
using System.ComponentModel;

namespace EditorUX.Business.Initialization
{
    /// <summary>
    /// Module for customizing templates and rendering.
    /// </summary>
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class EditorUXInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            // register required properties metadata extender
            var registry = context.Locate.Advanced.GetInstance<MetadataHandlerRegistry>();
            registry.RegisterMetadataHandler(typeof(ContentData), new RequiredPropertiesMetadataExtender());

            // add img alt text required attribute automatically to all XhtmlStrings
            TypeDescriptor.AddAttributes(typeof(XhtmlString), new[] { new ImgAltTextRequiredAttribute() });
        }

        public void Uninitialize(InitializationEngine context)
        {

        }

        public void Preload(string[] parameters)
        {
        }
    }
}
