
using SIOT.Resources.Translations;

namespace SIOT.Extensions;

[ContentProperty(nameof(Key))]
public class LocalizeExtension : IMarkupExtension
{
    IStringLocalizer<AppTranslations> _localizer;

    public string Key { get; set; } = string.Empty;

    public LocalizeExtension()
    {
        _localizer = ServiceHelper.GetService<IStringLocalizer<AppTranslations>>();
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        string localizedText = _localizer[Key];
        return localizedText;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
