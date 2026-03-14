using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class GreaterThanOrEqualsBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_GreaterThanOrEqualsBinaryDescriptor()
        {
            // Arrange
            var descriptor = new GreaterThanOrEqualsBinaryDescriptor
            (
                new MemberSelectorDescriptor("Score", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(50, typeof(int).AssemblyQualifiedName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<GreaterThanOrEqualsBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Score", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal(50, System.Convert.ToInt32(((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue));
        }
    }
}
