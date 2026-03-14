using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class NotDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_NotDescriptor()
        {
            // Arrange
            var descriptor = new NotDescriptor
            (
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("IsActive", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(true, typeof(bool).AssemblyQualifiedName)
                )
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<NotDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<EqualsBinaryDescriptor>(deserializedDescriptor.Operand);
        }
    }
}
