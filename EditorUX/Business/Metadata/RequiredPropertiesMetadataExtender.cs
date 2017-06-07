using EPiServer.Cms.Shell.UI.ObjectEditing;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EditorUX.Business.Metadata
{
    /// <summary>
    /// Add an asterisk to denote required, editable fields. Note, this does not work if property names are localized.
    /// </summary>
    public class RequiredPropertiesMetadataExtender : IMetadataExtender
    {
        public void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            IEnumerable<ContentDataMetadata> props = metadata.Properties.OfType<ContentDataMetadata>().Where(p => p.IsRequired && !p.IsReadOnly);

            foreach (var property in props)
            {
                property.DisplayName = $"{property.DisplayName} (*)";
            }
        }
    }
}
