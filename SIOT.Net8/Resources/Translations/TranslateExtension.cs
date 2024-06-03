using System.Reflection;
using System.Resources;

namespace SIOT.Resources.Translations;

[ContentProperty(nameof(Text))]
public class TranslateExtension : IMarkupExtension<BindingBase>
{
    public string Text { get; set; }
    public IValueConverter Converter { get; set; }

    /// <summary>
    /// No need to create an additional property for LocalizationResourceManager, we can hide it in MarkupExtension 
    /// The Title value can be updated to:
    /// Title="{localization:Translate MainPageTitle}"
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Text}]",
            Source = LocalizationResourceManager.Instance,
            Converter = Converter
        };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return ProvideValue(serviceProvider);
    }
}
