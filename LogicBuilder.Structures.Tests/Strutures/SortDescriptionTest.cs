using LogicBuilder.Expressions.Utils.Strutures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicBuilder.Structures.Tests.Strutures
{
    public class SortDescriptionTest
    {
        [Fact]
        public void CanInitialize_SortDescription()
        {
            // Arrange
            string memberFullName = "Name";
            // Act
            var sortDescription = new SortDescription(memberFullName, ListSortDirection.Descending);
            // Assert
            Assert.Equal(memberFullName, sortDescription.PropertyName);
            Assert.Equal(ListSortDirection.Descending, sortDescription.SortDirection);
        }
    }
}
