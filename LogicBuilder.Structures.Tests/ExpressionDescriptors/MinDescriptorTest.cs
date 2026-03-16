using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class MinDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_MinDescriptor()
        {
            // Arrange
            var descriptor = new MinDescriptor
            (
                new ParameterDescriptor("source"),
                new MemberSelectorDescriptor("Price", new ParameterDescriptor(parameterName)),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MinDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SelectorBody);
            Assert.Equal(parameterName, deserializedDescriptor.SelectorParameterName);
        }
    }
}
