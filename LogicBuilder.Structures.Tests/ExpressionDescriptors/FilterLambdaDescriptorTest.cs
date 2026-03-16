using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class FilterLambdaDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_FilterLambdaDescriptor()
        {
            // Arrange
            var descriptor = new FilterLambdaDescriptor
            (
                new GreaterThanBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Age", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(18, typeof(int).AssemblyQualifiedName)
                ),
                "MyNamespace.Person",
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FilterLambdaDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<GreaterThanBinaryDescriptor>(deserializedDescriptor.FilterBody);
            Assert.Equal("MyNamespace.Person", deserializedDescriptor.SourceElementType);
            Assert.Equal(parameterName, deserializedDescriptor.ParameterName);
        }
    }
}
