using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class LessThanOrEqualsBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_LessThanOrEqualsBinaryDescriptor()
        {
            // Arrange
            var descriptor = new LessThanOrEqualsBinaryDescriptor
            (
                new MemberSelectorDescriptor("Quantity", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(10, typeof(int).FullName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<LessThanOrEqualsBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Quantity", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal(10, System.Convert.ToInt32(((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue));
        }
    }
}
