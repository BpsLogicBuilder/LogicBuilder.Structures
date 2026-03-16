using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System;
using System.Linq;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class CustomMethodDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_CustomMethodDescriptor_StaticMethod()
        {
            // Arrange - Using string.Concat as a static method
            var descriptor = new CustomMethodDescriptor
            (
                typeof(string).AssemblyQualifiedName!,
                "Concat",
                [typeof(string).AssemblyQualifiedName!, typeof(string).AssemblyQualifiedName!],
                [
                    new ConstantDescriptor("Hello", typeof(string).AssemblyQualifiedName!),
                    new ConstantDescriptor("World", typeof(string).AssemblyQualifiedName!)
                ]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CustomMethodDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(typeof(string).AssemblyQualifiedName, deserializedDescriptor.DeclaringType);
            Assert.Equal("Concat", deserializedDescriptor.MethodName);
            Assert.Equal(2, deserializedDescriptor.ParameterTypeNames.Length);
            Assert.Equal(2, deserializedDescriptor.Args.Length);

            // Verify MethodInfo can be reconstructed
            Type stringType = Type.GetType(deserializedDescriptor.DeclaringType)!;
            var reconstructedMethodInfo = stringType.GetMethod(deserializedDescriptor.MethodName, deserializedDescriptor.ParameterTypeNames.Select(Type.GetType).ToArray()!);
            Assert.NotNull(reconstructedMethodInfo);
            Assert.Equal("Concat", reconstructedMethodInfo.Name);
            Assert.True(reconstructedMethodInfo.IsStatic);
        }

        [Fact]
        public void CanSerializeAndDeserialize_CustomMethodDescriptor_InstanceMethod()
        {
            // Arrange - Using string.Substring as an instance method
            var parameterName = "$it";
            var descriptor = new CustomMethodDescriptor
            (
                typeof(string).AssemblyQualifiedName!,
                "Substring",
                [typeof(int).AssemblyQualifiedName!, typeof(int).AssemblyQualifiedName!],
                [
                    new MemberSelectorDescriptor("Text", new ParameterDescriptor(parameterName)),
                    new ConstantDescriptor(0, typeof(int).AssemblyQualifiedName!),
                    new ConstantDescriptor(5, typeof(int).AssemblyQualifiedName!)
                ]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CustomMethodDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(typeof(string).AssemblyQualifiedName, deserializedDescriptor.DeclaringType);
            Assert.Equal("Substring", deserializedDescriptor.MethodName);
            Assert.Equal(2, deserializedDescriptor.ParameterTypeNames.Length);
            Assert.Equal(3, deserializedDescriptor.Args.Length);

            // Verify MethodInfo can be reconstructed
            Type stringType  = Type.GetType(deserializedDescriptor.DeclaringType)!;
            var reconstructedMethodInfo = stringType.GetMethod(deserializedDescriptor.MethodName, deserializedDescriptor.ParameterTypeNames.Select(Type.GetType).ToArray()!);
            Assert.NotNull(reconstructedMethodInfo);
            Assert.Equal("Substring", reconstructedMethodInfo.Name);
            Assert.False(reconstructedMethodInfo.IsStatic);

            // Verify the source operand (the instance the method is called on)
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Args[0]);
        }
    }
}
