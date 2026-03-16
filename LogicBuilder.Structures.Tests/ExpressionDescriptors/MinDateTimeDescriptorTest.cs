using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class MinDateTimeDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_MinDateTimeDescriptor()
        {
            // Arrange
            var descriptor = new MinDateTimeDescriptor();

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MinDateTimeDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
        }
    }
}
