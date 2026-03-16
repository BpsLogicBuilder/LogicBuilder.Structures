using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class AverageDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_AverageDescriptor()
        {
            // Arrange
            var descriptor = new AverageDescriptor
            (
                new ParameterDescriptor("source"),
                new MemberSelectorDescriptor("Score", new ParameterDescriptor(parameterName)),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AverageDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SelectorBody);
            Assert.Equal(parameterName, deserializedDescriptor.SelectorParameterName);
        }
    }
}
