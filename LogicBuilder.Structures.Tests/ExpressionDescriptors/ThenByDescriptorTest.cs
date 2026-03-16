using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ThenByDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ThenByDescriptor()
        {
            // Arrange
            var descriptor = new ThenByDescriptor
            (
                new ParameterDescriptor("source"),
                new MemberSelectorDescriptor("Age", new ParameterDescriptor(parameterName)),
                LogicBuilder.Expressions.Utils.Strutures.ListSortDirection.Descending,
                parameterName
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ThenByDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SelectorBody);
            Assert.Equal(LogicBuilder.Expressions.Utils.Strutures.ListSortDirection.Descending, deserializedDescriptor.SortDirection);
            Assert.Equal(parameterName, deserializedDescriptor.SelectorParameterName);
        }
    }
}
