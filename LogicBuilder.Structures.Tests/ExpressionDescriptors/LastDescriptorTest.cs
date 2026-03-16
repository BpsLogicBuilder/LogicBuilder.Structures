using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class LastDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_LastDescriptor()
        {
            // Arrange
            var descriptor = new LastDescriptor
            (
                new ParameterDescriptor("source"),
                new GreaterThanBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Value", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(0, typeof(int).AssemblyQualifiedName)
                ),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<LastDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<GreaterThanBinaryDescriptor>(deserializedDescriptor.FilterBody);
            Assert.Equal(parameterName, deserializedDescriptor.FilterParameterName);
        }
    }
}
