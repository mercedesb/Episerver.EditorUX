using EditorUX.Models;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System.Collections.Generic;

namespace EditorUX.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(IList<ImageWithLabel>))]
    public class ImageWithLabelListEditorDescriptor : CollectionEditorDescriptor<ImageWithLabel>
    {
        public ImageWithLabelListEditorDescriptor() : base()
        {
        }
    }
}
