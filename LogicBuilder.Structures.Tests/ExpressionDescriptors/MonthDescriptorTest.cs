using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class MonthDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_MonthDescriptor()
        {
            // Arrange
            var descriptor = new MonthDescriptor
            (
                new MemberSelectorDescriptor("CreatedDate", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MonthDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal("CreatedDate", ((MemberSelectorDescriptor)deserializedDescriptor.Operand).MemberFullName);
        }
    }
}
