namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ParameterDescriptor(string parameterName) : DescriptorBase
    {
        public string ParameterName { get; set; } = parameterName;
    }
}