using Accertify.Core.Models;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Shell.ObjectEditing;

namespace Accertify.Core.Attributes
{
    [EditorDescriptorRegistration(TargetType = typeof(ContentArea))]
    public class ContentAreaWithTypeNameEditorDescriptor : ContentAreaEditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);
            this.ClientEditingClass = "accertify.editors.contentAreaWithTypeName";
        }
    }
}
