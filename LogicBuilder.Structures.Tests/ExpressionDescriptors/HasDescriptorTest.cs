using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class HasDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_HasDescriptor()
        {
            // Arrange
            var descriptor = new HasDescriptor
            (
                new MemberSelectorDescriptor("Orders", new ParameterDescriptor(parameterName)),
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Status", new ParameterDescriptor("$order")),
                    new ConstantDescriptor("Shipped", typeof(string).AssemblyQualifiedName)
                )
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<HasDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<EqualsBinaryDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Orders", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
        }
    }
}
