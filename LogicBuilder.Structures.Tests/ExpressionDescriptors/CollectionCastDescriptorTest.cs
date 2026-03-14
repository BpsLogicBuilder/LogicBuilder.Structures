using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class CollectionCastDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_CollectionCastDescriptor()
        {
            // Arrange
            var descriptor = new CollectionCastDescriptor
            (
                new ParameterDescriptor("source"),
                typeof(string).AssemblyQualifiedName!
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CollectionCastDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal(typeof(string).AssemblyQualifiedName, deserializedDescriptor.Type);
        }
    }
}
