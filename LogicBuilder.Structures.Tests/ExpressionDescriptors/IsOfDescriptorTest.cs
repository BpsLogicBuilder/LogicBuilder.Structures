using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class IsOfDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_IsOfDescriptor()
        {
            // Arrange
            var descriptor = new IsOfDescriptor
            (
                new MemberSelectorDescriptor("Value", new ParameterDescriptor(parameterName)),
                typeof(string).AssemblyQualifiedName!
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<IsOfDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal(typeof(string).AssemblyQualifiedName, deserializedDescriptor.Type);
        }
    }
}
