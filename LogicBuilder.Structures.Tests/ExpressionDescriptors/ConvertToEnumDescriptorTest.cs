using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ConvertToEnumDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_ConvertToEnumDescriptor()
        {
            // Arrange
            var descriptor = new ConvertToEnumDescriptor
            (
                "Active",
                "MyNamespace.Status"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConvertToEnumDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal("Active", deserializedDescriptor.ConstantValue);
            Assert.Equal("MyNamespace.Status", deserializedDescriptor.Type);
        }
    }
}
