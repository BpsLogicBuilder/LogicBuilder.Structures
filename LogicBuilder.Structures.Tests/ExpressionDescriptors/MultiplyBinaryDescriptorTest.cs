using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class MultiplyBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_MultiplyBinaryDescriptor()
        {
            // Arrange
            var descriptor = new MultiplyBinaryDescriptor
            (
                new MemberSelectorDescriptor("Quantity", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(2, typeof(int).AssemblyQualifiedName!)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MultiplyBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Quantity", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal(2, System.Convert.ToInt32(((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue));
        }
    }
}
