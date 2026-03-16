using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ModuloBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ModuloBinaryDescriptor()
        {
            // Arrange
            var descriptor = new ModuloBinaryDescriptor
            (
                new MemberSelectorDescriptor("Count", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(10, typeof(int).AssemblyQualifiedName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ModuloBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Count", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal(10, System.Convert.ToInt32(((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue));
        }
    }
}
