namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class MemberSelectorDescriptor(string memberFullName, DescriptorBase sourceOperand) : DescriptorBase
    {
        public string MemberFullName { get; set; } = memberFullName;
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}