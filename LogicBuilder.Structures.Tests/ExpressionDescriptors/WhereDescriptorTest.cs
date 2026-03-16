using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class WhereDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_WhereDescriptor()
        {
            // Arrange
            var descriptor = new WhereDescriptor
            (
                new ParameterDescriptor("source"),
                new GreaterThanBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Age", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(18, typeof(int).AssemblyQualifiedName)
                ),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<WhereDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<GreaterThanBinaryDescriptor>(deserializedDescriptor.FilterBody);
            Assert.Equal(parameterName, deserializedDescriptor.FilterParameterName);
        }
    }
}
