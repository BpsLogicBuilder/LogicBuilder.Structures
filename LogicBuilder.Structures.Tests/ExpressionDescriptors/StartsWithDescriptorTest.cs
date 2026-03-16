using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class StartsWithDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_StartsWithDescriptor()
        {
            // Arrange
            var descriptor = new StartsWithDescriptor
            (
                new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor("John", typeof(string).AssemblyQualifiedName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<StartsWithDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Name", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal("John", ((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue);
        }
    }
}
