using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpansionDescriptors
{
    public class SelectExpandItemFilterDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_SelectExpandItemFilterDescriptor()
        {
            // Arrange
            var parameterName = "$it";
            var filterLambda = new FilterLambdaDescriptor
            (
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Status", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor("Active", typeof(string).AssemblyQualifiedName)
                ),
                "Order",
                parameterName
            );

            var descriptor = new SelectExpandItemFilterDescriptor(filterLambda);

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectExpandItemFilterDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.NotNull(deserializedDescriptor.FilterLambdaOperator);
            Assert.IsType<FilterLambdaDescriptor>(deserializedDescriptor.FilterLambdaOperator);
            Assert.Equal("Order", deserializedDescriptor.FilterLambdaOperator.SourceElementType);
            Assert.Equal(parameterName, deserializedDescriptor.FilterLambdaOperator.ParameterName);
        }
    }
}
