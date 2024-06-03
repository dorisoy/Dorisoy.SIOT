using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.Measure;

using SIOT.Controls.Charts;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Defaults;
using System.Runtime.Serialization;

using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;



namespace SIOT.ViewModels;
public partial class StatisticsViewModel : ObservableObject
{
    #region Fiels & Properties
    [ObservableProperty]
    private double _totalIncome;

    [ObservableProperty]
    private double _totalExpense;

    private string[] days;

    private string[] weeks;

    private string[] months;

    private string[] section;

    [ObservableProperty]
    private ObservableCollection<TransactionData> _weekListItems;

    [ObservableProperty]
    private ObservableCollection<ISeries> _weekChart;

    [ObservableProperty]
    private ObservableCollection<TransactionData> _monthListItems;

    [ObservableProperty]
    private ObservableCollection<ISeries> _monthChart;

    [ObservableProperty]
    private ObservableCollection<TransactionData> _yearListItems;

    [ObservableProperty]
    private ObservableCollection<ISeries> _yearChart;

    [ObservableProperty]
    private ObservableCollection<TransactionData> _transactionLists;

    public ObservableCollection<ISeries> ChartData { get; private set; }

    public ObservableCollection<TransactionData> DataSource { get; private set; }

    [ObservableProperty]
    public SolidColorPaint _legendTextPaint;

    private int _selectedIndex;
    public int SelectedIndex
    {
        get
        {
            return _selectedIndex;
        }
        set
        {
            _selectedIndex = value;
            UpdateListViewData();
        }
    }

    #endregion Fiels & Properties


    private readonly Random _random = new();
    private readonly List<DateTimePoint> _values = new();
    private readonly DateTimeAxis _customAxis;


    public StatisticsViewModel()
    {
        WeekData();
        MonthData();
        YearData();
        ChartData = new ObservableCollection<ISeries>();
        DataSource = new ObservableCollection<TransactionData>()
        {
            new TransactionData() { Duration = "Week" },
            new TransactionData() { Duration = "Month" },
            new TransactionData() { Duration = "Year" },
        };

        TransactionLists = WeekListItems;
        ChartData = WeekChart;
        //Statistics Chart Legend
        LegendTextPaint = new SolidColorPaint
        {
            Color = new SKColor(110, 110, 110),
            SKTypeface = SKTypeface.FromFamilyName("Arial")
        };

        UpdateIncomeExpenseData();


        //

        //Series = new ObservableCollection<ISeries>
        //{
        //    new LineSeries<DateTimePoint>
        //    {

        //        Values = _values,
        //        Fill = null,
        //        GeometryFill = null,
        //        GeometryStroke = null,

        //    }
        //};

        //_customAxis = new DateTimeAxis(TimeSpan.FromSeconds(1), Formatter)
        //{

        //    CustomSeparators = GetSeparators(),
        //    AnimationsSpeed = TimeSpan.FromMilliseconds(0),
        //    SeparatorsPaint = new SolidColorPaint(SKColors.Black.WithAlpha(100))
        //};

        //var yAxis = new Axis
        //{
        //    IsVisible = false,
        //  };

        ////XAxes = new Axis[] { _customAxis };
        //YAxes = new Axis[] { yAxis };

        //_ = ReadData();


        var data = new[]
        {
            new Fruit { Name = "kW·h", SalesPerDay = 4, Stock = 6 },
            new Fruit { Name = "kW·h", SalesPerDay = 6, Stock = 4 },
            new Fruit { Name = "kW·h", SalesPerDay = 2, Stock = 2 },
            new Fruit { Name = "kW·h", SalesPerDay = 8, Stock = 4 },
            new Fruit { Name = "kW·h", SalesPerDay = 3, Stock = 6 },
            new Fruit { Name = "kW·h", SalesPerDay = 4, Stock = 8 }
        };

        var salesPerDaysSeries = new ColumnSeries<Fruit>
        {
            Values = data,
            YToolTipLabelFormatter = point => $"{point.Model?.SalesPerDay} {point.Model?.Name}",
            DataLabelsPaint = new SolidColorPaint(new SKColor(30, 30, 30)),
            DataLabelsFormatter = point => $"{point.Model?.SalesPerDay} {point.Model?.Name}",
            DataLabelsPosition = DataLabelsPosition.End,
            // use the SalesPerDay property in this in the Y axis 
            // and the index of the fruit in the array in the X axis 
            Mapping = (fruit, index) => new(index, fruit.SalesPerDay)
        };

        // notice that the event signature is different for every series
        // use the  IDE intellisense to help you (see more bellow in this article). 
        salesPerDaysSeries.ChartPointPointerDown += OnPointerDown;
        salesPerDaysSeries.ChartPointPointerHover += OnPointerHover;
        salesPerDaysSeries.ChartPointPointerHoverLost += OnPointerHoverLost;

        ESeries = new ISeries[] { salesPerDaysSeries };


        EYAxes = new Axis[] { new Axis
        {
            IsVisible = false,
        } };
    }

    public Axis[] EYAxes { get; set; }
    public ISeries[] ESeries { get; set; }

    private void OnPointerDown(IChartView chart, ChartPoint<Fruit, RoundedRectangleGeometry, LabelGeometry>? point)
    {
        if (point?.Visual is null) return;
        point.Visual.Fill = new SolidColorPaint(SKColors.Red);
        chart.Invalidate(); // <- ensures the canvas is redrawn after we set the fill
        //Trace.WriteLine($"Clicked on {point.Model?.Name}, {point.Model?.SalesPerDay} items sold per day");
    }

    private void OnPointerHover(IChartView chart, ChartPoint<Fruit, RoundedRectangleGeometry, LabelGeometry>? point)
    {
        if (point?.Visual is null) return;
        point.Visual.Fill = new SolidColorPaint(SKColors.Yellow);
        chart.Invalidate();
        //Trace.WriteLine($"Pointer entered on {point.Model?.Name}");
    }

    private void OnPointerHoverLost(IChartView chart, ChartPoint<Fruit, RoundedRectangleGeometry, LabelGeometry>? point)
    {
        if (point?.Visual is null) return;
        point.Visual.Fill = null;
        chart.Invalidate();
        //Trace.WriteLine($"Pointer left {point.Model?.Name}");
    }


    /// <summary>
    /// -----
    /// </summary>
    public ISeries[] Series { get; set; } =
    {
        new LineSeries<DateTimePoint>
        {
            Values = new ObservableCollection<DateTimePoint>
            {
                new DateTimePoint(new DateTime(2024, 1, 1), 10),
                new DateTimePoint(new DateTime(2024, 2, 1), 80),
                new DateTimePoint(new DateTime(2024, 3, 1), 50),
                new DateTimePoint(new DateTime(2024, 4, 1), 13),
                new DateTimePoint(new DateTime(2024, 5, 1), 50),
                new DateTimePoint(new DateTime(2024, 6, 1), 70),
                new DateTimePoint(new DateTime(2024, 7, 1), 90),
                new DateTimePoint(new DateTime(2024, 8, 1), 30),
                new DateTimePoint(new DateTime(2024, 9, 1), 60),
                new DateTimePoint(new DateTime(2024, 10, 1), 10),
                new DateTimePoint(new DateTime(2024, 11, 1), 40),
                new DateTimePoint(new DateTime(2024, 12, 1), 11)
            }
        }
    };

    public Axis[] XAxes { get; set; } =
    {
       new DateTimeAxis(TimeSpan.FromDays(1), Formatter)

    };

    public Axis[] YAxes { get; set; } =
    {
        new Axis
        {
            IsVisible = false,
            //CustomSeparators = new double[] { 0, 10, 25, 50, 100 },
            MinLimit = 0, // forces the axis to start at 0
            MaxLimit = 100, // forces the axis to end at 100
            SeparatorsPaint = new SolidColorPaint(SKColors.Black.WithAlpha(100)),
            LabelsRotation = 45
        }
    };


    private static string Formatter(DateTime date)
    {
        return $"{date.Month}M";
    }



    /// <summary>
    /// 
    /// </summary>

    //public ObservableCollection<ISeries> Series { get; set; }

    //public Axis[] XAxes { get; set; }
    //public Axis[] YAxes { get; set; }

    //public object Sync { get; } = new object();

    //public bool IsReading { get; set; } = true;

    //private async Task ReadData()
    //{
    //    //为了使这个示例保持简单，我们运行下一个无限循环
    //    //在实际应用程序中，当视图被释放时，应该停止循环/任务

    //    while (IsReading)
    //    {
    //        await Task.Delay(100);

    //        //因为我们正在从另一个线程更新图表
    //        //我们需要使用锁来访问图表数据。
    //        //如果您的更改是在UI线程中进行的，那么这是不必要的。
    //        lock (Sync)
    //        {
    //            _values.Add(new DateTimePoint(DateTime.Now, _random.Next(0, 10)));

    //            if (_values.Count > 250) _values.RemoveAt(0);

    //            // 每次添加新点时，我们都需要更新分隔符 
    //            _customAxis.CustomSeparators = GetSeparators();
    //        }
    //    }
    //}

    //private double[] GetSeparators()
    //{
    //    var now = DateTime.Now;

    //    return new double[]
    //    {
    //        now.AddSeconds(-25).Ticks,
    //        now.AddSeconds(-20).Ticks,
    //        now.AddSeconds(-15).Ticks,
    //        now.AddSeconds(-10).Ticks,
    //        now.AddSeconds(-5).Ticks,
    //        now.Ticks
    //    };
    //}




    private void WeekData()
    {
        WeekListItems = new ObservableCollection<TransactionData>()
        {
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Food,
                IconColor = Color.FromArgb("#3e5aff"),
                Title = "Food for lunch",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 12.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Camera,
                IconColor = Color.FromArgb("#7644ad"),
                Title = "Netflix Subscription",
                Date = "7:00 AM - Mar 22, 2023",
                Amount = 719.99,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Receipt,
                IconColor = Color.FromArgb("#d54381"),
                Title = "Salary",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 4689.89,
                IsCredited = true
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Airballoon,
                IconColor = Color.FromArgb("#af4aff"),
                Title = "AirBNB Royalty",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 125.50,
                IsCredited = false
            },
        };

        WeekChart = new ObservableCollection<ISeries>
        {
            new PieSeries<int> { Name = "Salary", Values = new List<int> { 2 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "Food & Drink", Values = new List<int> { 4 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "E-Wallet", Values = new List<int> { 1 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "Internet", Values = new List<int> { 4 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "Shopping", Values = new List<int> { 3 }, InnerRadius = 80 }
        };
    }

    private void MonthData()
    {
        MonthListItems = new ObservableCollection<TransactionData>()
        {
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Camera,
                IconColor = Color.FromArgb("#7644ad"),
                Title = "Netflix Subscription",
                Date = "7:00 AM - Mar 22, 2023",
                Amount = 719.99,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Receipt,
                IconColor = Color.FromArgb("#d54381"),
                Title = "Salary",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 4689.89,
                IsCredited = true
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Food,
                IconColor = Color.FromArgb("#3e5aff"),
                Title = "Food for lunch",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 32.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Airballoon,
                IconColor = Color.FromArgb("#af4aff"),
                Title = "AirBNB Royalty",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 185.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Camera,
                IconColor = Color.FromArgb("#7644ad"),
                Title = "Arthur Kim",
                Date = "7:00 AM - Mar 22, 2023",
                Amount = 65,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Receipt,
                IconColor = Color.FromArgb("#d54381"),
                Title = "Nell Sanchez",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 565,
                IsCredited = true
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Food,
                IconColor = Color.FromArgb("#3e5aff"),
                Title = "Amelia Coleman",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 70.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Airballoon,
                IconColor = Color.FromArgb("#af4aff"),
                Title = "Credit Card Bill",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 30.50,
                IsCredited = false
            },
        };

        MonthChart = new ObservableCollection<ISeries>
        {
            new PieSeries<int> { Name = "Salary", Values = new List<int> { 22 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "Food & Drink", Values = new List<int> { 10 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "E-Wallet", Values = new List<int> { 4 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "Internet", Values = new List<int> { 25 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "Shopping", Values = new List<int> { 35 }, InnerRadius = 80 }
        };
    }

    private void YearData()
    {
        YearListItems = new ObservableCollection<TransactionData>()
        {
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Receipt,
                IconColor = Color.FromArgb("#d54381"),
                Title = "Salary",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 4789.89,
                IsCredited = true
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Airballoon,
                IconColor = Color.FromArgb("#af4aff"),
                Title = "AirBNB Royalty",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 135.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Food,
                IconColor = Color.FromArgb("#3e5aff"),
                Title = "Food for lunch",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 22.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Camera,
                IconColor = Color.FromArgb("#7644ad"),
                Title = "Netflix Subscription",
                Date = "7:00 AM - Mar 22, 2023",
                Amount = 519.99,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Camera,
                IconColor = Color.FromArgb("#7644ad"),
                Title = "Arthur Kim",
                Date = "7:00 AM - Mar 22, 2023",
                Amount = 65,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Receipt,
                IconColor = Color.FromArgb("#d54381"),
                Title = "Nell Sanchez",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 350,
                IsCredited = true
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Food,
                IconColor = Color.FromArgb("#3e5aff"),
                Title = "Amelia Coleman",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 70.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Airballoon,
                IconColor = Color.FromArgb("#af4aff"),
                Title = "Credit Card Bill",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 30.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Camera,
                IconColor = Color.FromArgb("#7644ad"),
                Title = "Refund",
                Date = "7:00 AM - Mar 22, 2023",
                Amount = 35,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Receipt,
                IconColor = Color.FromArgb("#d54381"),
                Title = "Nell Sanchez",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 650,
                IsCredited = true
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Food,
                IconColor = Color.FromArgb("#3e5aff"),
                Title = "Chase Blair",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 20.50,
                IsCredited = false
            },
            new TransactionData
            {
                ImageIcon = MauiKitIcons.Airballoon,
                IconColor = Color.FromArgb("#af4aff"),
                Title = "Credit Card Bill",
                Date = "3:05 PM - Aug 22, 2022",
                Amount = 80.50,
                IsCredited = false
            },
        };

        YearChart = new ObservableCollection<ISeries>
        {
            new PieSeries<int> { Name = "0.5小时", Values = new List<int> { 230 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "1小时", Values = new List<int> { 130 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "1.5小时", Values = new List<int> { 70 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "2小时", Values = new List<int> { 350 }, InnerRadius = 80 },
            new PieSeries<int> { Name = "2.5小时", Values = new List<int> { 150 }, InnerRadius = 80 }
        };
    }

    public ISeries[] LineSeries { get; set; } =
    {
        new LineSeries<int>
        {
            Values = new int[] { 4, 4, 7, 2, 8 },
            Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90)),
            //Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 4 },
            LineSmoothness = 1,
        },
        new LineSeries<int>
        {
            Values = new int[] { 7, 5, 3, 2, 6 },
            Fill = new SolidColorPaint(SKColors.Red.WithAlpha(90)), 
            //Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
            LineSmoothness = 1,
        }
    };


    /// <summary>
    /// Method for update the listview items.
    /// </summary>
    private void UpdateListViewData()
    {
        switch (SelectedIndex)
        {
            case 0:
                TransactionLists = WeekListItems;
                ChartData = WeekChart;
                section = days;
                break;
            case 1:
                TransactionLists = MonthListItems;
                ChartData = MonthChart;
                section = weeks;
                break;
            case 2:
                TransactionLists = YearListItems;
                ChartData = YearChart;
                section = months;
                break;
            default:
                break;
        }

        UpdateIncomeExpenseData();
    }

    /// <summary>
    /// Method for update the income and expense data.
    /// </summary>
    private void UpdateIncomeExpenseData()
    {
        TotalIncome = 0;
        TotalExpense = 0;

        var incomeCollection = TransactionLists.Where(item => item.IsCredited).ToList();
        var expenseCollection = TransactionLists.Where(item => !item.IsCredited).ToList();

        for (int i = 0; i < incomeCollection.Count; i++)
        {
            TotalIncome += incomeCollection[i].Amount;
        }
        for (int i = 0; i < expenseCollection.Count; i++)
        {
            TotalExpense += expenseCollection[i].Amount;
        }
    }

    [RelayCommand]
    private async void TransactionDetail()
    {
        await Shell.Current.GoToAsync(nameof(EReceiptPage));
    }

}

public class LogarithmicPoint
{
    public double X { get; set; }
    public double Y { get; set; }
}

public class Fruit
{
    public string Name { get; set; } = string.Empty;
    public double SalesPerDay { get; set; }
    public int Stock { get; set; }
}
