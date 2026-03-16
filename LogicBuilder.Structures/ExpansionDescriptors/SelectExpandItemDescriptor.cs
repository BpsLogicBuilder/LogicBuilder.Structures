using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SelectExpandItemDescriptor(string memberName, SelectExpandItemFilterDescriptor? filter = null, SelectExpandItemQueryFunctionDescriptor? queryFunction = null, List<string>? selects = null, List<SelectExpandItemDescriptor>? expandedItems = null)
    {
        public string MemberName { get; set; } = memberName;
        public SelectExpandItemFilterDescriptor? Filter { get; set; } = filter;
        public SelectExpandItemQueryFunctionDescriptor? QueryFunction { get; set; } = queryFunction;
        public List<string> Selects { get; set; } = selects ?? [];
        public List<SelectExpandItemDescriptor> ExpandedItems { get; set; } = expandedItems ?? [];
    }
}
