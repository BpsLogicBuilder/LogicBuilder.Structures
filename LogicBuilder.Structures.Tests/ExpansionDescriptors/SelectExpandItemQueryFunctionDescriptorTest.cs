using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using LogicBuilder.Expressions.Utils.Strutures;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpansionDescriptors
{
    public class SelectExpandItemQueryFunctionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_SelectExpandItemQueryFunctionDescriptor()
        {
            // Arrange
            var sortCollection = new SortCollectionDescriptor
            (
                [
                    new SortDescriptionDescriptor("LastName", ListSortDirection.Ascending),
                    new SortDescriptionDescriptor("FirstName", ListSortDirection.Ascending)
                ],
                10,
                50
            );

            var descriptor = new SelectExpandItemQueryFunctionDescriptor(sortCollection);

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectExpandItemQueryFunctionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.NotNull(deserializedDescriptor.SortCollection);
            Assert.Equal(2, deserializedDescriptor.SortCollection.SortDescriptions.Count);
            Assert.Equal(10, deserializedDescriptor.SortCollection.Skip);
            Assert.Equal(50, deserializedDescriptor.SortCollection.Take);
        }
    }
}
