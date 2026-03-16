using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using LogicBuilder.Expressions.Utils.Strutures;
using LogicBuilder.Structures.Tests.Helpers;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpansionDescriptors
{
    public class SortCollectionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_SortCollectionDescriptor()
        {
            // Arrange
            var descriptor = new SortCollectionDescriptor
            (
                [
                    new SortDescriptionDescriptor("Name", ListSortDirection.Ascending),
                    new SortDescriptionDescriptor("Age", ListSortDirection.Descending),
                    new SortDescriptionDescriptor("CreatedDate", ListSortDirection.Descending)
                ],
                20,
                100
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SortCollectionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(3, deserializedDescriptor.SortDescriptions.Count);
            Assert.Equal(20, deserializedDescriptor.Skip);
            Assert.Equal(100, deserializedDescriptor.Take);

            var sortList = new List<SortDescriptionDescriptor>(deserializedDescriptor.SortDescriptions);
            Assert.Equal("Name", sortList[0].PropertyName);
            Assert.Equal(ListSortDirection.Ascending, sortList[0].SortDirection);
            Assert.Equal("Age", sortList[1].PropertyName);
            Assert.Equal(ListSortDirection.Descending, sortList[1].SortDirection);
            Assert.Equal("CreatedDate", sortList[2].PropertyName);
            Assert.Equal(ListSortDirection.Descending, sortList[2].SortDirection);
        }
    }
}
