using LogicBuilder.Expressions.Utils.Strutures;
using System.Linq;

namespace LogicBuilder.Structures.Tests.Strutures
{
    public class SortCollectionTest
    {
        [Fact]
        public void CanInitializeSortCollection()
        {   
            // Arrange
            var sortCollection = new SortCollection
            (
                [ 
                    new SortDescription("Name", ListSortDirection.Ascending), 
                    new SortDescription("Age", ListSortDirection.Descending)
                ], 
                20, 
                3
            );

            // Act & Assert
            Assert.NotNull(sortCollection);
            Assert.Equal(2, sortCollection.SortDescriptions.Count);
            Assert.Equal("Name", sortCollection.SortDescriptions.First().PropertyName);
            Assert.Equal(ListSortDirection.Ascending, sortCollection.SortDescriptions.First().SortDirection);
            Assert.Equal("Age", sortCollection.SortDescriptions.Last().PropertyName);
            Assert.Equal(ListSortDirection.Descending, sortCollection.SortDescriptions.Last().SortDirection);
        }
    }
}
