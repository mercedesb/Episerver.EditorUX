using EditorUX.Business.Selection;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;

namespace EditorUX.Business.EditorDescriptors
{
    /// <summary>
    /// This editor descriptor is used to apply a dropdown editor to a property of time DayOfWeek or DayOfWeek?
    /// example: [UIHint(MakingWavesUIHint.DayOfWeek)]
    /// </summary>
    [EditorDescriptorRegistration(TargetType = typeof(DayOfWeek)), EditorDescriptorRegistration(TargetType = typeof(DayOfWeek?))]
    public class DayOfWeekEditorDescriptor : EnumEditorDescriptor<DayOfWeek>
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DayOfWeekSelectionAttribute : SelectOneAttribute
    {
        public override Type SelectionFactoryType
        {
            get
            {
                return typeof(EnumSelectionFactory<DayOfWeek>);
            }
            set
            {
                base.SelectionFactoryType = value;
            }
        }
    }
}
