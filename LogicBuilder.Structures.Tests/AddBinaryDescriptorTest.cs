using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests
{
    public class AddBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_AddBinaryDescriptor()
        {
            // Arrange
            var descriptor = new AddBinaryDescriptor
            (
                new MemberSelectorDescriptor("UnitPrice", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(1.00m, typeof(decimal).FullName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AddBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("UnitPrice", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal(1.00m, (decimal)((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue);
        }
    }
}
