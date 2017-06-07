# Episerver.EditorUX
An Episerver Alloy site with sample code for taking the editor experience up a notch

Please find examples for the following use cases:

### Editor.css 

- .btn-blue added to styles dropdown

### Property definitions 

- EditorUX/Models/Pages/Demo/UXPage: examples of formatted names and defined descriptions

- EditorUX/ClientResources/Styles/Styles.css: display description text directly in the UI

### UIHints and Editor Descriptors (used on the UXPage)

- EditorUX/Business/EditorDescriptors/DateOnlyEditorDescriptor: register an editor to display only the Date editor (and not time) when updating a DateTime property
- EditorUX/Business/Attributes/DayOfWeekSelectionAttribute: apply the enum editor descriptor for the DayOfWeek enum and using a dropdown for the editor
- EditorUX/Business/Attributes/ImgAltTextRequiredAttribute: validate XhtmlString properties for image alt text
- EditorUX.Business.Initialization/EditorUXInitialization: register image alt text validation globally

### IMetadataExtender 

- EditorUX/Business/Metadata/RequiredPropertiesMetadataExtender: extend property metadata to display (*) next to required fields automatically

### IValidate<>

- EditorUX/Business/Validation/ValidationPageValidator: validate pages according to custom criteria

### Custom editors (used on the UXPage)

- EditorUX/Business/EditorDescriptors/AutocompleteListEditorDescriptor: register custom editor for autocomplete functionality
- EditorUX/Business/Attributes/AutocompleteListAttribute: set properties necessary for the autocomplete editor display and apply the autocomplete editor to property

### IList<> (used on the UXPage)

- EditorUX/Models/ImageWithLabel: list object to add and edit
- EditorUX.Models.Properties.PropertyListBase: base class for all list property definitions to inherit from
- EditorUX.Models.Properties.ImageWithLabelListProperty: specific property definition for ImageWithLabel
- EditorUX/Business/EditorDescriptorsImageWithLabelListEditorDescriptor: register the list editor to display for properties of type IList<ImageWithLabel>

