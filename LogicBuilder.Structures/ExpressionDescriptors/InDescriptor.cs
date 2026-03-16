namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class InDescriptor(DescriptorBase itemToFind, DescriptorBase listToSearch) : DescriptorBase
    {
        public DescriptorBase ItemToFind { get; set; } = itemToFind;
        public DescriptorBase ListToSearch { get; set; } = listToSearch;
    }
}