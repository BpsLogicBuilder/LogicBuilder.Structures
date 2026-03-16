using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class AllDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_AllDescriptor()
        {
            // Arrange
            var descriptor = new AllDescriptor
            (
                new ParameterDescriptor("source"),
                new GreaterThanBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Score", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(50, typeof(int).AssemblyQualifiedName)
                ),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AllDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<GreaterThanBinaryDescriptor>(deserializedDescriptor.FilterBody);
            Assert.Equal(parameterName, deserializedDescriptor.FilterParameterName);
        }
    }
}
