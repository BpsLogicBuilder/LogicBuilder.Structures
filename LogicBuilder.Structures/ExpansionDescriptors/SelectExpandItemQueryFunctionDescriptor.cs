namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SelectExpandItemQueryFunctionDescriptor(SortCollectionDescriptor sortCollection)
    {
        public SortCollectionDescriptor SortCollection { get; set; } = sortCollection;
    }
}
