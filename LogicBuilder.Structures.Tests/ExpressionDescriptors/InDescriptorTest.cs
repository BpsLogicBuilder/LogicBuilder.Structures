using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class InDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_InDescriptor()
        {
            // Arrange
            var descriptor = new InDescriptor
            (
                new MemberSelectorDescriptor("Status", new ParameterDescriptor(parameterName)),
                new CollectionConstantDescriptor
                (
                    ["Active", "Pending"],
                    typeof(string).AssemblyQualifiedName!
                )
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<InDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.ItemToFind);
            Assert.IsType<CollectionConstantDescriptor>(deserializedDescriptor.ListToSearch);
            Assert.Equal("Status", ((MemberSelectorDescriptor)deserializedDescriptor.ItemToFind).MemberFullName);
        }
    }
}
