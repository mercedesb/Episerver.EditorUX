using EPiServer.Cms.Shell.UI.ObjectEditing;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EditorUX.Models.Metadata
{
    public class RequiredPropertiesMetadataExtender : IMetadataExtender
    {
        public void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            // Add asterisk to required (editable) properties
            IEnumerable<ContentDataMetadata> props = metadata.Properties.OfType<ContentDataMetadata>().Where(p => p.IsRequired && !p.IsReadOnly);

            foreach (var property in props)
            {
                property.DisplayName = $"{property.DisplayName} (*)";
            }
        }
    }
}
