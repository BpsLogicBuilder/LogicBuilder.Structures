namespace LogicBuilder.Structures.Tests
{
    public class ScreenSettings<TDialogSetting>(TDialogSetting settings) : ScreenSettingsBase
    {
        public TDialogSetting Settings { get; set; } = settings;
    }
}
