using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class AndBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_AndBinaryDescriptor()
        {
            // Arrange
            var descriptor = new AndBinaryDescriptor
            (
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("IsActive", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(true, typeof(bool).AssemblyQualifiedName)
                ),
                new GreaterThanBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Age", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(18, typeof(int).AssemblyQualifiedName)
                )
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AndBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<EqualsBinaryDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<GreaterThanBinaryDescriptor>(deserializedDescriptor.Right);
        }
    }
}
