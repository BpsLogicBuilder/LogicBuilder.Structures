using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class SelectorLambdaDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_SelectorLambdaDescriptor()
        {
            // Arrange
            var descriptor = new SelectorLambdaDescriptor
            (
                new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                typeof(string).AssemblyQualifiedName!,
                parameterName,
                typeof(string).AssemblyQualifiedName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectorLambdaDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Selector);
            Assert.Equal(typeof(string).AssemblyQualifiedName, deserializedDescriptor.SourceElementType);
            Assert.Equal(parameterName, deserializedDescriptor.ParameterName);
            Assert.Equal(typeof(string).AssemblyQualifiedName, deserializedDescriptor.BodyType);
        }
    }
}
