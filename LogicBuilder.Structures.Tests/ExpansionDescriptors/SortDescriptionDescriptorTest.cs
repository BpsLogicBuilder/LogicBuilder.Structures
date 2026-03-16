using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using LogicBuilder.Expressions.Utils.Strutures;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpansionDescriptors
{
    public class SortDescriptionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_SortDescriptionDescriptor()
        {
            // Arrange
            var descriptor = new SortDescriptionDescriptor("Name", ListSortDirection.Ascending);

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SortDescriptionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal("Name", deserializedDescriptor.PropertyName);
            Assert.Equal(ListSortDirection.Ascending, deserializedDescriptor.SortDirection);
        }
    }
}
