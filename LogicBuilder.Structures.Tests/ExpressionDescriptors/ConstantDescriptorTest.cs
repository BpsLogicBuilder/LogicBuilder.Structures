using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ConstantDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_ConstantDescriptor()
        {
            // Arrange
            var descriptor = new ConstantDescriptor(42, typeof(int).AssemblyQualifiedName);

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConstantDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(42, Convert.ToInt32(deserializedDescriptor.ConstantValue));
            Assert.Equal(typeof(int).AssemblyQualifiedName, deserializedDescriptor.Type);
        }
    }
}
