using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class MemberInitDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_MemberInitDescriptor()
        {
            // Arrange
            var descriptor = new MemberInitDescriptor
            (
                new Dictionary<string, DescriptorBase>
                {
                    ["Name"] = new MemberSelectorDescriptor("FirstName", new ParameterDescriptor(parameterName)),
                    ["Age"] = new ConstantDescriptor(25, typeof(int).AssemblyQualifiedName)
                },
                "AnonymousType"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MemberInitDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(2, deserializedDescriptor.MemberBindings.Count);
            Assert.Equal("AnonymousType", deserializedDescriptor.NewType);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.MemberBindings["Name"]);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.MemberBindings["Age"]);
        }
    }
}
