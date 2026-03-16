using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class SelectManyDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_SelectManyDescriptor()
        {
            // Arrange
            var descriptor = new SelectManyDescriptor
            (
                new ParameterDescriptor("source"),
                new MemberSelectorDescriptor("Orders", new ParameterDescriptor(parameterName)),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectManyDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SelectorBody);
            Assert.Equal(parameterName, deserializedDescriptor.SelectorParameterName);
        }
    }
}
