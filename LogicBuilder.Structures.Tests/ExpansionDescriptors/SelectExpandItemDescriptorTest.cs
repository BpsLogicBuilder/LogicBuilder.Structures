using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.Strutures;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpansionDescriptors
{
    public class SelectExpandItemDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_SelectExpandItemDescriptor_WithOptionalParameters()
        {
            // Arrange
            var parameterName = "$it";
            var filterDescriptor = new SelectExpandItemFilterDescriptor
            (
                new FilterLambdaDescriptor
                (
                    new GreaterThanBinaryDescriptor
                    (
                        new MemberSelectorDescriptor("Price", new ParameterDescriptor(parameterName)),
                        new ConstantDescriptor(100, typeof(int).FullName)
                    ),
                    "Product",
                    parameterName
                )
            );

            var queryFunctionDescriptor = new SelectExpandItemQueryFunctionDescriptor
            (
                new SortCollectionDescriptor
                (
                    [
                        new SortDescriptionDescriptor("Name", ListSortDirection.Ascending)
                    ],
                    0,
                    10
                )
            );

            var descriptor = new SelectExpandItemDescriptor
            (
                "Products",
                filterDescriptor,
                queryFunctionDescriptor,
                ["Id", "Name", "Price"],
                [
                    new SelectExpandItemDescriptor("Category", null, null, null, null)
                ]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectExpandItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal("Products", deserializedDescriptor.MemberName);
            Assert.NotNull(deserializedDescriptor.Filter);
            Assert.NotNull(deserializedDescriptor.QueryFunction);
            Assert.Equal(3, deserializedDescriptor.Selects.Count);
            Assert.Contains("Id", deserializedDescriptor.Selects);
            Assert.Contains("Name", deserializedDescriptor.Selects);
            Assert.Contains("Price", deserializedDescriptor.Selects);
            Assert.Single(deserializedDescriptor.ExpandedItems);
            Assert.Equal("Category", deserializedDescriptor.ExpandedItems[0].MemberName);
        }

        [Fact]
        public void CanSerializeAndDeserialize_SelectExpandItemDescriptor_WithoutOptionalParameters()
        {
            // Arrange
            var descriptor = new SelectExpandItemDescriptor
            (
                "Products"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectExpandItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal("Products", deserializedDescriptor.MemberName);
            Assert.Null(deserializedDescriptor.Filter);
            Assert.Null(deserializedDescriptor.QueryFunction);
            Assert.Empty(deserializedDescriptor.Selects);
            Assert.Empty(deserializedDescriptor.ExpandedItems);
        }
    }
}
