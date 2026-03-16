using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SelectExpandDefinitionDescriptor(List<string>? selects = null, List<SelectExpandItemDescriptor>? expandedItems = null)
    {
        public List<string> Selects { get; set; } = selects ?? [];
        public List<SelectExpandItemDescriptor> ExpandedItems { get; set; } = expandedItems ?? [];
    }
}
