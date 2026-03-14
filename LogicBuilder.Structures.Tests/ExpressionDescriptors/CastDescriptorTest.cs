using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class CastDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_CastDescriptor()
        {
            // Arrange
            var descriptor = new CastDescriptor
            (
                new MemberSelectorDescriptor("Value", new ParameterDescriptor(parameterName)),
                typeof(decimal).AssemblyQualifiedName!
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CastDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal(typeof(decimal).AssemblyQualifiedName, deserializedDescriptor.Type);
        }
    }
}
