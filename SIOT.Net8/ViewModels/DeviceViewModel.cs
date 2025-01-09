namespace SIOT.ViewModels;

public partial class DeviceViewModel : ObservableObject
{
    public ICommand ShowCotrolCommand { get; }
    public ICommand IncreaseDemoNumberCommand { get; }
    public ICommand DecreaseDemoNumberCommand { get; }

    public DeviceViewModel()
    {
        ShowTab1 = true;
        ShowCotrolCommand = new RelayCommand<string?>(ShowCotrol);
        IncreaseDemoNumberCommand = new RelayCommand(IncreaseDemoNumber);
        DecreaseDemoNumberCommand = new RelayCommand(DecreaseDemoNumber);
        sliderMax = 180;
    }


    [ObservableProperty]
    private bool _showTab1;
    [ObservableProperty]
    private bool _showTab2;
    [ObservableProperty]
    private bool _showTab3;
    [ObservableProperty]
    private bool _showTab4;


    [ObservableProperty]
    private double demoNumber;

    [ObservableProperty]
    private Color gaugeColor;

    [ObservableProperty]
    private double sliderMax;

    private void IncreaseDemoNumber()
    {
        DemoNumber++;
        SetGaugeColor();
    }

    private void DecreaseDemoNumber()
    {
        DemoNumber--;
        SetGaugeColor();
    }

    private void SetGaugeColor()
    {
        if (DemoNumber > 30)
        {
            GaugeColor = Microsoft.Maui.Graphics.Colors.Red;
            return;
        }
        if (DemoNumber > 20)
        {
            GaugeColor = Microsoft.Maui.Graphics.Colors.Orange;
            return;
        }
        else
        {
            GaugeColor = Microsoft.Maui.Graphics.Color.Parse("#2566dc");
        }
    }

    private void ShowCotrol(string? tab)
    {
        switch (tab)
        {
            case "1":
                ShowTab1 = true;
                ShowTab2 = false;
                ShowTab3 = false;
                ShowTab4 = false;
                SliderMax = 180;
                break;
            case "2":
                ShowTab1 = false;
                ShowTab2 = true;
                ShowTab3 = false;
                ShowTab4 = false;
                SliderMax = 180;
                break;
            case "3":
                ShowTab1 = false;
                ShowTab2 = false;
                ShowTab3 = true;
                ShowTab4 = false;
                SliderMax = 20000;
                break;
            case "4":
                ShowTab1 = false;
                ShowTab2 = false;
                ShowTab3 = false;
                ShowTab4 = true;
                SliderMax = 180;
                break;
            default:
                ShowTab1 = true;
                ShowTab2 = false;
                ShowTab3 = false;
                ShowTab4 = false;
                SliderMax = 180;
                break;
        }
    }
}
