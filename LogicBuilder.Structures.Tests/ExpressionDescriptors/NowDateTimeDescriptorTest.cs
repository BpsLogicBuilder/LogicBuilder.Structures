using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class NowDateTimeDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_NowDateTimeDescriptor()
        {
            // Arrange
            var descriptor = new NowDateTimeDescriptor();

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<NowDateTimeDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
        }
    }
}
