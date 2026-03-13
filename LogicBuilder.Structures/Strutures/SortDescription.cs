namespace LogicBuilder.Expressions.Utils.Strutures
{
    public class SortDescription(string propertyName, ListSortDirection order)
    {
        public string PropertyName { get; set; } = propertyName;
        public ListSortDirection SortDirection { get; set; } = order;
    }
}
