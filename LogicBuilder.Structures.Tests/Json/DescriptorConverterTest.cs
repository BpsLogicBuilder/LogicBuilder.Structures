using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.Json;
using System;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.Json
{
    public class DescriptorConverterTest
    {
        [Fact]
        public void DescriptorConverterThrows_WhenJsonPropertyIsDefault()
        {
            // Arrange
            string json = JsonSerializer.Serialize(new { Name = "John" });//Serialize anonymous type so JsonProperty of Start object is default

            // Act & Assert
            Assert.Throws<JsonException>(() =>
            {
                JsonSerializer.Deserialize<object>(json, TestSerializationOptions.Default);
            });
        }

        [Fact]
        public void DescriptorConverterThrows_WhenJsonTokenTypeIsNotStartObject()
        {
            // Arrange
            string json = JsonSerializer.Serialize((object)"MyString");//Use a string so JsonTokenType is not StartObject

            // Act & Assert
            Assert.Throws<JsonException>(() =>
            {
                JsonSerializer.Deserialize<object>(json, TestSerializationOptions.Default);
            });
        }

        [Fact]
        public void DescriptorConverterThrows_WhenTypeStringIsInvalid()
        {
            // Arrange
            TestDescriptorWithInvalidTypeString testDescriptor = new(new ConstantDescriptorWithInvalidTypeString(1));
            string json = JsonSerializer.Serialize(testDescriptor);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                JsonSerializer.Deserialize<TestDescriptorWithInvalidTypeString>(json);
            });
            Assert.Equal($"Type cannot be loaded for {typeof(ConstantDescriptorWithInvalidTypeString).FullName}.", exception.Message);
        }

        [Fact]
        public void DescriptorConverterThrows_WhenValueIsNull()
        {
            // Arrange
            TestDescriptor nullValue = new(null);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                JsonSerializer.Serialize(nullValue);
            });
            Assert.Equal("Type cannot be null", exception.Message);
        }
    }

    internal class TestDescriptor(TestDescriptorBase? constant) : TestDescriptorBase
    {
        public TestDescriptorBase? Constant { get; set; } = constant;
    }

    internal class TestDescriptorWithInvalidTypeString(TestDescriptorBaseWithInvalidTypeString constant) : TestDescriptorBaseWithInvalidTypeString
    {
        public TestDescriptorBaseWithInvalidTypeString Constant { get; set; } = constant;
    }

    internal class ConstantDescriptorWithInvalidTypeString(object constant) : TestDescriptorBaseWithInvalidTypeString
    {
        public object Constant { get; set; } = constant;
    }

    internal class TestObjectConverter : JsonTypeConverter<object>
    {
        public override string TypePropertyName => nameof(DescriptorBase.TypeString);

        public override bool CanConvert(Type typeToConvert)
            => typeToConvert == typeof(object);
    }

    internal class TestDescriptorConverterWithNullHandling : JsonTypeConverter<TestDescriptorBase>
    {
        public override string TypePropertyName => nameof(DescriptorBase.TypeString);

        public override bool HandleNull => true;
    }

    internal class TestDescriptorConverterWithInvalidTypeString : JsonTypeConverter<TestDescriptorBaseWithInvalidTypeString>
    {
        public override string TypePropertyName => nameof(DescriptorBase.TypeString);
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(TestDescriptorConverterWithNullHandling))]
    public abstract class TestDescriptorBase : IExpressionDescriptor
    {
        public string TypeString => this.GetType().AssemblyQualifiedName!;
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(TestDescriptorConverterWithInvalidTypeString))]
    public abstract class TestDescriptorBaseWithInvalidTypeString : IExpressionDescriptor
    {
        public string TypeString => this.GetType().FullName!;
    }

    static class TestSerializationOptions
    {
        private static JsonSerializerOptions? _default;
        public static JsonSerializerOptions Default
        {
            get
            {
                if (_default != null)
                    return _default;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                options.Converters.Add(new TestObjectConverter());

                _default = options;

                return _default;
            }
        }
    }
}
