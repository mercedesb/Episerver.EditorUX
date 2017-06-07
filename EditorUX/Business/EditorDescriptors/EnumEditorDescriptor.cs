using EditorUX.Business.Selection;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;

namespace EditorUX.Business.EditorDescriptors
{
    /// <summary>
    /// This editor descriptor can be inherited from to define SelectOnes or SelectManys for various enums 
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public class EnumEditorDescriptor<TEnum> : EditorDescriptor
    {
        public override void ModifyMetadata(
            ExtendedMetadata metadata,
            IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(EnumSelectionFactory<TEnum>);

            ClientEditingClass =
                "epi-cms/contentediting/editors/SelectionEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }

}
