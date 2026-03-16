using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpansionDescriptors
{
    public class SelectExpandDefinitionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_SelectExpandDefinitionDescriptor_WithOptionalParameters()
        {
            // Arrange
            var descriptor = new SelectExpandDefinitionDescriptor
            (
                ["Name", "Email", "Age"],
                [
                    new SelectExpandItemDescriptor("Orders")
                ]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectExpandDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(3, deserializedDescriptor.Selects.Count);
            Assert.Contains("Name", deserializedDescriptor.Selects);
            Assert.Contains("Email", deserializedDescriptor.Selects);
            Assert.Contains("Age", deserializedDescriptor.Selects);
            Assert.Single(deserializedDescriptor.ExpandedItems);
            Assert.Equal("Orders", deserializedDescriptor.ExpandedItems[0].MemberName);
        }

        [Fact]
        public void CanSerializeAndDeserialize_SelectExpandDefinitionDescriptor_WithoutOptionalParameters()
        {
            // Arrange
            var descriptor = new SelectExpandDefinitionDescriptor();

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectExpandDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Empty(deserializedDescriptor.Selects);
            Assert.Empty(deserializedDescriptor.ExpandedItems);
        }
    }
}
