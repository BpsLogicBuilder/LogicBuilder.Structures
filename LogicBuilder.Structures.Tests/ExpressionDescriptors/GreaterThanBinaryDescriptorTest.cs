using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class GreaterThanBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_GreaterThanBinaryDescriptor()
        {
            // Arrange
            var descriptor = new GreaterThanBinaryDescriptor
            (
                new MemberSelectorDescriptor("Age", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(18, typeof(int).AssemblyQualifiedName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<GreaterThanBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Age", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal(18, System.Convert.ToInt32(((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue));
        }
    }
}
