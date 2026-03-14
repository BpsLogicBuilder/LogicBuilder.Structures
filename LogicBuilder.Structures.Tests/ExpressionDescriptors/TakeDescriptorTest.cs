using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class TakeDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_TakeDescriptor()
        {
            // Arrange
            var descriptor = new TakeDescriptor
            (
                new ParameterDescriptor("source"),
                10
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<TakeDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal(10, deserializedDescriptor.Count);
        }
    }
}
