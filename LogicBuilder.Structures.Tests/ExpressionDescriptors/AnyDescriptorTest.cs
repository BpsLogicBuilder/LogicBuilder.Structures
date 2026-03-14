using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class AnyDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_AnyDescriptor()
        {
            // Arrange
            var descriptor = new AnyDescriptor
            (
                new ParameterDescriptor("source"),
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("Status", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor("Active", typeof(string).AssemblyQualifiedName)
                ),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AnyDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<EqualsBinaryDescriptor>(deserializedDescriptor.FilterBody);
            Assert.Equal(parameterName, deserializedDescriptor.FilterParameterName);
        }
    }
}
