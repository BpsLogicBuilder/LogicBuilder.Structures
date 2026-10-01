using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.Json;
using System;
using System.Linq;
using System.Reflection;
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
            var exception = Assert.Throws<JsonException>(() =>
            {
                JsonSerializer.Deserialize<TestDescriptorWithInvalidTypeString>(json);
            });
            Assert.Equal($"Type \"{typeof(ConstantDescriptorWithInvalidTypeString).FullName}\" is not an allowed type for {typeof(TestDescriptorBaseWithInvalidTypeString).FullName}.", exception.Message);
        }

        [Fact]
        public void DescriptorConverterDoesNotInstantiate_TypeOutsideAllowlist()
        {
            // Arrange
            GadgetType.Instantiated = false;
            string json = "{\"TypeString\":\"" + typeof(GadgetType).AssemblyQualifiedName + "\"}";

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DescriptorBase>(json));
            Assert.False(GadgetType.Instantiated);
        }

        [Fact]
        public void DescriptorConverterRejects_DescriptorSubtypeFromUnregisteredAssembly()
        {
            // Arrange
            string json = "{\"TypeString\":\"" + typeof(ExternalDescriptor).AssemblyQualifiedName + "\"}";

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DescriptorBase>(json));
            Assert.Throws<JsonException>(() => JsonSerializer.Serialize<DescriptorBase>(new ExternalDescriptor()));
        }

        [Fact]
        public void DescriptorConverterAccepts_DescriptorSubtypeFromRegisteredAssembly()
        {
            // Arrange
            JsonSerializerOptions options = new();
            options.Converters.Add(new DescriptorConverter(typeof(ExternalDescriptor).Assembly));
            string json = JsonSerializer.Serialize<DescriptorBase>(new ExternalDescriptor { Name = "A" }, options);

            // Act
            DescriptorBase result = JsonSerializer.Deserialize<DescriptorBase>(json, options)!;

            // Assert
            Assert.Equal("A", Assert.IsType<ExternalDescriptor>(result).Name);
        }

        [Fact]
        public void DescriptorConverterAccepts_DescriptorSubtypeFromRegisteredAssembly_UsingTypesListConstructor()
        {
            // Arrange
            JsonSerializerOptions options = new();
            options.Converters.Add(new TestDescriptorConverter(typeof(ExternalDescriptor).Assembly.GetTypes().Where(t => typeof(DescriptorBase).IsAssignableFrom(t)).ToArray()));
            string json = JsonSerializer.Serialize<DescriptorBase>(new ExternalDescriptor { Name = "A" }, options);

            // Act
            DescriptorBase result = JsonSerializer.Deserialize<DescriptorBase>(json, options)!;

            // Assert
            Assert.Equal("A", Assert.IsType<ExternalDescriptor>(result).Name);
        }

        [Fact]
        public void DescriptorThrowsJsonException_WhenJsonTpePropertyNameIsNotAString()
        {
            // Arrange
            JsonSerializerOptions options = new();
            options.Converters.Add(new TestDescriptorConverterWithInvalidPropertyName(typeof(ExternalDescriptor).Assembly.GetTypes().Where(t => typeof(DescriptorBase).IsAssignableFrom(t)).ToArray()));
            string json = JsonSerializer.Serialize<DescriptorBase>(new ExternalDescriptor { Name = "A" }, options);

            // Act Assert
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DescriptorBase>(json, options)!);
        }

        [Fact]
        public void DescriptorConverterAccepts_TypeStringWithDifferentAssemblyVersion()
        {
            // Arrange
            string typeString = $"{typeof(ConstantDescriptor).FullName}, {typeof(ConstantDescriptor).Assembly.GetName().Name}, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null";
            string json = "{\"TypeString\":\"" + typeString + "\",\"Constant\":1}";

            // Act & Assert
            Assert.IsType<ConstantDescriptor>(JsonSerializer.Deserialize<DescriptorBase>(json));
        }

        [Fact]
        public void CreateConverterThrows_WhenTypesListContainsInvalidTypes()
        {
            // Act Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new TestDescriptorConverter(typeof(ExternalDescriptor).Assembly.GetTypes().ToArray());
            });
        }

        [Fact]
        public void CreateConverterThrows_WhenTypesListIsNull()
        {
            // Act Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new TestDescriptorConverter((Type[])null!);
            });
        }

        [Fact]
        public void CreateConverterThrows_WhenAssemblyListIsNull()
        {
            // Act Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new TestDescriptorConverter((Assembly[])null!);
            });
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

    public class GadgetType
    {
        public static bool Instantiated { get; set; }
        protected GadgetType() => Instantiated = true;
    }

    public class ExternalDescriptor : DescriptorBase
    {
        public int ID { get; set; }
        public string? Name { get; set; }
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

    internal class TestDescriptorConverter : JsonTypeConverter<DescriptorBase>
    {
        public TestDescriptorConverter()
        {
        }

        public TestDescriptorConverter(params Assembly[] additionalAssemblies)
            : base(additionalAssemblies)
        {
        }

        public TestDescriptorConverter(params Type[] types)
            : base(types)
        {
        }

        public override string TypePropertyName => nameof(DescriptorBase.TypeString);
    }

    internal class TestDescriptorConverterWithInvalidPropertyName : JsonTypeConverter<DescriptorBase>
    {
        public TestDescriptorConverterWithInvalidPropertyName()
        {
        }

        public TestDescriptorConverterWithInvalidPropertyName(params Assembly[] additionalAssemblies)
            : base(additionalAssemblies)
        {
        }

        public TestDescriptorConverterWithInvalidPropertyName(params Type[] types)
            : base(types)
        {
        }

        public override string TypePropertyName => nameof(ExternalDescriptor.ID);
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
