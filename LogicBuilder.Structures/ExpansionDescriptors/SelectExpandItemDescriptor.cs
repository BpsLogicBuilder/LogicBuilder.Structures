using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SelectExpandItemDescriptor(string memberName, SelectExpandItemFilterDescriptor? filter = null, SelectExpandItemQueryFunctionDescriptor? queryFunction = null, List<string>? selects = null, List<SelectExpandItemDescriptor>? expandedItems = null)
    {
        public string MemberName { get; } = memberName;
        public SelectExpandItemFilterDescriptor? Filter { get; } = filter;
        public SelectExpandItemQueryFunctionDescriptor? QueryFunction { get; } = queryFunction;
        public List<string> Selects { get; } = selects ?? [];
        public List<SelectExpandItemDescriptor> ExpandedItems { get; } = expandedItems ?? [];
    }
}
