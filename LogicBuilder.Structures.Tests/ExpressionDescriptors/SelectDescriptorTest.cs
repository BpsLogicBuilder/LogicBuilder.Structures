using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class SelectDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_SelectDescriptor()
        {
            // Arrange
            var descriptor = new SelectDescriptor
            (
                new ParameterDescriptor("source"),
                new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SelectorBody);
            Assert.Equal(parameterName, deserializedDescriptor.SelectorParameterName);
        }
    }
}
