using LogicBuilder.Structures.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.Json
{
    public class ScreenSettingsConverterTest
    {
        [Fact]
        public void FlowSettings_RoundTrips_ThroughJsonSerialization()
        {
            var model = new FlowSettings
            (
                new ScreenSettings<string>("dialog-settings")
            );

            var json = JsonSerializer.Serialize(model);
            var result = JsonSerializer.Deserialize<FlowSettings>(json, SerializationOptions.Default);

            Assert.NotNull(result);
            Assert.IsType<ScreenSettings<string>>(result.ScreenSettings);
        }
    }
}
