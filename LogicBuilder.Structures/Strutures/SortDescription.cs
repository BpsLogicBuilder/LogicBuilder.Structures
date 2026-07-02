namespace LogicBuilder.Expressions.Utils.Strutures
{
    public class SortDescription(string propertyName, ListSortDirection sortDirection)
    {
        public string PropertyName { get; } = propertyName;
        public ListSortDirection SortDirection { get; } = sortDirection;
    }
}
