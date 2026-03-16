using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class OrBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_OrBinaryDescriptor()
        {
            // Arrange
            var descriptor = new OrBinaryDescriptor
            (
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Status", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor("Active", typeof(string).AssemblyQualifiedName)
                ),
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Status", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor("Pending", typeof(string).AssemblyQualifiedName)
                )
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<OrBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<EqualsBinaryDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<EqualsBinaryDescriptor>(deserializedDescriptor.Right);
        }
    }
}
