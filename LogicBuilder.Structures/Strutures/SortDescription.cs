namespace LogicBuilder.Expressions.Utils.Strutures
{
    public class SortDescription(string propertyName, ListSortDirection sortDirection)
    {
        public string PropertyName { get; set; } = propertyName;
        public ListSortDirection SortDirection { get; set; } = sortDirection;
    }
}
