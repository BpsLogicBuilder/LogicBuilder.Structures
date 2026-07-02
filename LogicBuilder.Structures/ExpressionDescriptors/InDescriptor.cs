namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class InDescriptor(DescriptorBase itemToFind, DescriptorBase listToSearch) : DescriptorBase
    {
        public DescriptorBase ItemToFind { get; } = itemToFind;
        public DescriptorBase ListToSearch { get; } = listToSearch;
    }
}