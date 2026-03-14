using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ConvertDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ConvertDescriptor()
        {
            // Arrange
            var descriptor = new ConvertDescriptor
            (
                new MemberSelectorDescriptor("Amount", new ParameterDescriptor(parameterName)),
                typeof(double).AssemblyQualifiedName!
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConvertDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal(typeof(double).AssemblyQualifiedName, deserializedDescriptor.Type);
        }
    }
}
