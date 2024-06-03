using System.ComponentModel;
using System.Globalization;

namespace SIOT.Resources.Translations;

public class LocalizationResourceManager : INotifyPropertyChanged
{
    /// <summary>
    /// Usage: Title = "{Binding MyCodeBehindLocalizationResourceManager[MainPageTitle], Mode=OneWay}"
    /// where MyCodeBehindLocalizationResourceManager is a code-behind property with value LocalizationResourceManager.Instance
    /// So here the Title value is binding to the resource value
    /// Each time we call the method LocalizationResourceManager.SetCulture, our property value is updated.
    /// </summary>
    private LocalizationResourceManager()
    {
        AppTranslations.Culture = CultureInfo.CurrentCulture;
    }

    public static LocalizationResourceManager Instance { get; } = new();

    public object this[string resourceKey] =>
        AppTranslations.ResourceManager.GetObject(resourceKey, AppTranslations.Culture) ?? Array.Empty<byte>();

    public static string Translate(string text)
    {
        var translation = AppTranslations.ResourceManager.GetString(text, AppTranslations.Culture);
        if (translation == null)
        {
            translation = text;
        }
        return translation;
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    public void SetCulture(CultureInfo culture)
    {
        AppTranslations.Culture = culture;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
