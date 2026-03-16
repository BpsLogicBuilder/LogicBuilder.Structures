using LogicBuilder.Expressions.Utils.Strutures;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SortDescriptionDescriptor(string propertyName, ListSortDirection sortDirection)
    {
        public string PropertyName { get; set; } = propertyName;
        public ListSortDirection SortDirection { get; set; } = sortDirection;
    }
}
