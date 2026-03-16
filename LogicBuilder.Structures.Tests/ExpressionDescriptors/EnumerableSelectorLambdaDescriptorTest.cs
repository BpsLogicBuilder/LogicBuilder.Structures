using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class EnumerableSelectorLambdaDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_EnumerableSelectorLambdaDescriptor()
        {
            // Arrange
            var descriptor = new EnumerableSelectorLambdaDescriptor
            (
                new MemberSelectorDescriptor("Orders", new ParameterDescriptor(parameterName)),
                "MyNamespace.Customer",
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<EnumerableSelectorLambdaDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Selector);
            Assert.Equal("MyNamespace.Customer", deserializedDescriptor.SourceElementType);
            Assert.Equal(parameterName, deserializedDescriptor.ParameterName);
        }
    }
}
