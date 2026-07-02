using LogicBuilder.Expressions.Utils.Strutures;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SortDescriptionDescriptor(string propertyName, ListSortDirection sortDirection)
    {
        public string PropertyName { get; } = propertyName;
        public ListSortDirection SortDirection { get; } = sortDirection;
    }
}
