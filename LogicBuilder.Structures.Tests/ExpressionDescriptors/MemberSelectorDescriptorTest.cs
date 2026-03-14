using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class MemberSelectorDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_MemberSelectorDescriptor()
        {
            // Arrange
            var descriptor = new MemberSelectorDescriptor("FirstName", new ParameterDescriptor(parameterName));

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MemberSelectorDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal("FirstName", deserializedDescriptor.MemberFullName);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal(parameterName, ((ParameterDescriptor)deserializedDescriptor.SourceOperand).ParameterName);
        }
    }
}
