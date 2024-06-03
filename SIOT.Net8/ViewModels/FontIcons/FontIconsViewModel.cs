
namespace SIOT.ViewModels.FontIcons;
public class FontIconsViewModel : BaseViewModel
{
    public int TotalIcon { get; private set; }
    public int TotalFont { get; private set; }

    public ObservableCollection<FontIconGroupModel> _fontIconGroup;
    public ObservableCollection<FontIconGroupModel> FontIconGroup
    {
        get { return _fontIconGroup; }
        set
        {
            _fontIconGroup = value;
            OnPropertyChanged("FontIconGroup");
        }
    }
    public FontIconsViewModel()
    {
        CreateIconCollection();
    }

    void CreateIconCollection()
    {
        _fontIconGroup = new ObservableCollection<FontIconGroupModel>
        {
            new FontIconGroupModel( "SIOT Icons", (List<FontIconModel>)mauiKit) ,
            new FontIconGroupModel( "IonIcons", (List<FontIconModel>)ionIcons ),
            new FontIconGroupModel( "Font Awesome Pro", (List<FontIconModel>)faPro ),
            new FontIconGroupModel( "Font Awesome Brands", (List<FontIconModel>)faBrands ),
            new FontIconGroupModel( "Font Awesome Regular", (List<FontIconModel>)faRegular ),
            new FontIconGroupModel( "Line Awesome", (List<FontIconModel>)lineAwesome ),
            new FontIconGroupModel( "Material Designs", (List<FontIconModel>)materialDesign )
        };

        var iconCollection = new ObservableCollection<FontIconGroupModel>();
        foreach (var icon in _fontIconGroup)
        {
            iconCollection.Add(icon);
            TotalIcon += icon.Count();
        }

        FontIconGroup = iconCollection;
        TotalFont = FontIconGroup.Count();
    }

    public readonly IList<FontIconModel> mauiKit =
        typeof(MauiKitIcons).GetFields()
            .Select(x => new FontIconModel
            {
                Type = "SIOT Icons",
                Name = x.Name,
                Value = x.GetValue(null).ToString()
            })
            .ToList();

    public readonly IList<FontIconModel> faBrands =
        (List<FontIconModel>)typeof(FaBrands)
            .GetFields()
            .Select(x => new FontIconModel
            {
                Type = "Font Awesome Brands",
                Name = x.Name,
                Value = x.GetValue(null).ToString()
            })
            .ToList();

    public readonly IList<FontIconModel> faPro =
        typeof(FaPro)
            .GetFields()
            .Select(x => new FontIconModel
            {
                Type = "Font Awesome Pro",
                Name = x.Name,
                Value = x.GetValue(null).ToString()
            })
            .ToList();

    public readonly IList<FontIconModel> faRegular =
        typeof(FaRegular)
            .GetFields()
            .Select(x => new FontIconModel
            {
                Type = "Font Awesome Regular",
                Name = x.Name,
                Value = x.GetValue(null).ToString()
            })
            .ToList();

    public readonly IList<FontIconModel> lineAwesome =
        typeof(LineAwesome).GetFields()
            .Select(x => new FontIconModel
            {
                Type = "Line Awesome",
                Name = x.Name,
                Value = x.GetValue(null).ToString()
            })
            .ToList();

    public readonly IList<FontIconModel> ionIcons =
        typeof(IonIcons).GetFields()
            .Select(x => new FontIconModel
            {
                Type = "IonIcons",
                Name = x.Name,
                Value = x.GetValue(null).ToString()
            })
            .ToList();

    public readonly IList<FontIconModel> materialDesign =
        typeof(MaterialDesignIcons).GetFields()
            .Select(x => new FontIconModel
            {
                Type = "Material Designs",
                Name = x.Name,
                Value = x.GetValue(null).ToString()
            })
            .ToList();

}
