using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class CollectionConstantDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_CollectionConstantDescriptor()
        {
            // Arrange
            var descriptor = new CollectionConstantDescriptor
            (
                ["Active", "Pending", "Completed"],
                typeof(string).AssemblyQualifiedName!
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CollectionConstantDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(3, deserializedDescriptor.ConstantValues.Count);
            Assert.Equal(typeof(string).AssemblyQualifiedName, deserializedDescriptor.ElementType);
        }
    }
}
