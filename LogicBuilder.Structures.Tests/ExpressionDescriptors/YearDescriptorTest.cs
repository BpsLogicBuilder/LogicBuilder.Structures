using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class YearDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_YearDescriptor()
        {
            // Arrange
            var descriptor = new YearDescriptor
            (
                new MemberSelectorDescriptor("BirthDate", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<YearDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal("BirthDate", ((MemberSelectorDescriptor)deserializedDescriptor.Operand).MemberFullName);
        }
    }
}
