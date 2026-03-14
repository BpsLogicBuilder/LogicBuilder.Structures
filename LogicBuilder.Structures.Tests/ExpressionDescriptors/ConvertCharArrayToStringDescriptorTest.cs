using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ConvertCharArrayToStringDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ConvertCharArrayToStringDescriptor()
        {
            // Arrange
            var descriptor = new ConvertCharArrayToStringDescriptor
            (
                new MemberSelectorDescriptor("CharArray", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConvertCharArrayToStringDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal("CharArray", ((MemberSelectorDescriptor)deserializedDescriptor.SourceOperand).MemberFullName);
        }
    }
}
