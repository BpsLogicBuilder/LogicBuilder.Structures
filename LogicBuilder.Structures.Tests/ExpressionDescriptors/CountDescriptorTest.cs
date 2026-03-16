using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class CountDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_CountDescriptor()
        {
            // Arrange
            var descriptor = new CountDescriptor
            (
                new ParameterDescriptor("source"),
                new EqualsBinaryDescriptor
                (
                    new MemberSelectorDescriptor("IsActive", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(true, typeof(bool).AssemblyQualifiedName)
                ),
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CountDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<EqualsBinaryDescriptor>(deserializedDescriptor.FilterBody);
            Assert.Equal(parameterName, deserializedDescriptor.FilterParameterName);
        }
    }
}
