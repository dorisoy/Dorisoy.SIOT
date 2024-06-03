namespace SIOT.Models;
public class CardData
{
    public string CardType { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Expiry { get; set; }
    public int CardCvv { get; set; }
    public string BackgroundImage { get; set; }
    public Color BackgroundGradientStart { get; set; }
    public Color BackgroundGradientEnd { get; set; }
    public string CardTypeIcon { get; set; }
}

public class ServiceCategory
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public Color IconColor { get; set; }
}

public class ServiceCategoryGroup : List<ServiceCategory>
{
    public string GroupName { get; set; }
    public ServiceCategoryGroup(string groupName, List<ServiceCategory> services) : base(services)
    {
        GroupName = groupName;
    }
}

public class WalletContact
{
    public string Name { get; set; }
    public string Avatar { get; set; }
    public string PhoneNumber { get; set; }
}

public class TransactionChartData
{
    #region Constructor
    public TransactionChartData(string section, double incomeValue, double expenseValue, double difference)
    {
        Section = section;
        Income = incomeValue;
        Expense = expenseValue;
        Difference = difference;
    }
    #endregion

    #region Properties
    public string Section { get; set; }
    public double Income { get; set; }
    public double Expense { get; set; }
    public double Difference { get; set; }

    #endregion
}
public class TransactionData
{
    public string Duration { get; set; }
    public string ImageIcon { get; set; }
    public Color IconColor { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string TransactionId { get; set; }
    public Color BackgroundColor { get; set; }
    public double Amount { get; set; }
    public string Date { get; set; }
    public bool IsCredited { get; set; }

}
