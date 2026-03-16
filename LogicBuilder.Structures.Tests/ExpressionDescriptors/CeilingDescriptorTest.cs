using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class CeilingDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_CeilingDescriptor()
        {
            // Arrange
            var descriptor = new CeilingDescriptor
            (
                new MemberSelectorDescriptor("Value", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CeilingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal("Value", ((MemberSelectorDescriptor)deserializedDescriptor.Operand).MemberFullName);
        }
    }
}
