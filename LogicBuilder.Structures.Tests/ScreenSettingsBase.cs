using System;
using System.Text.Json.Serialization;

namespace LogicBuilder.Structures.Tests
{
    [JsonConverter(typeof(ScreenSettingsConverter))]
    abstract public class ScreenSettingsBase
    {
        public string TypeString => this.GetType().AssemblyQualifiedName ?? throw new ArgumentException($"{this.GetType().Name}: {{75FE4EA4-09BF-40C2-A750-50E46A801147}}");
    }
}
