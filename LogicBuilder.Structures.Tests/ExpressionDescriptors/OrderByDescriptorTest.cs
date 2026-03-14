using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class OrderByDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_OrderByDescriptor()
        {
            // Arrange
            var descriptor = new OrderByDescriptor
            (
                new ParameterDescriptor("source"),
                new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                LogicBuilder.Expressions.Utils.Strutures.ListSortDirection.Ascending,
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<OrderByDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SelectorBody);
            Assert.Equal(LogicBuilder.Expressions.Utils.Strutures.ListSortDirection.Ascending, deserializedDescriptor.SortDirection);
            Assert.Equal(parameterName, deserializedDescriptor.SelectorParameterName);
        }
    }
}
