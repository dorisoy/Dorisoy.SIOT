
namespace SIOT.Services;
public class EwalletServices
{
    static EwalletServices _instance;

    public static EwalletServices Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EwalletServices();

            return _instance;
        }
    }

    public static readonly Random Random = new Random();
    public List<Color> Colors { get; } = new List<Color>()
    {
        Color.FromArgb("#7644ad"),
        Color.FromArgb("#d54381"),
        Color.FromArgb("#E88F1A"),
        Color.FromArgb("#8010E0"),
        Color.FromArgb("#7ed321"),
        Color.FromArgb("#ff4a4a"),
        Color.FromArgb("#ff844a"),
        Color.FromArgb("#4acaff"),
        Color.FromArgb("#567cd7"),
        Color.FromArgb("#523ee8"),
        Color.FromArgb("#35c659"),
        Color.FromArgb("#d483fc")
    };

    public List<Notification> GetNotifications
    {
        get
        {
            return new List<Notification>
            {
                new Notification
                {
                    Title = "You Get Cashback!",
                    Description = "You get $5 cashback from payment!",
                    Icon = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/ewallet/icon_1.png"
                },
                new Notification
                {
                    Title = "New Service is Available!",
                    Description = "Now you can track your payment",
                    Icon = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/ewallet/icon_2.png"
                },
                new Notification
                {
                    Title = "Netflix Subscription Monthy Bill",
                    Description = "Your subscription for Netflix is now paid",
                    Icon = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/ewallet/icon_3.png"
                },
                new Notification
                {
                    Title = "E-Wallet is Connected!",
                    Description = "Your E-Wallet is now connected to MauiPay",
                    Icon = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/ewallet/icon_4.png"
                },
                new Notification
                {
                    Title = "Verification Successfull",
                    Description = "Your account verification is completed",
                    Icon = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/ewallet/icon_5.png"
                },
                new Notification
                {
                    Title = "Account Verification Required",
                    Description = "Your account need verification",
                    Icon = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/ewallet/icon_6.png"
                }
            };
        }
    }
    public List<TransactionData> GetTransactions
    {
        get
        {
            return new List<TransactionData>
            {
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.Cash,
                    IconColor = Color.FromArgb("#d54381"),
                    Title = "Salary",
                    Date = "3:05 PM - Aug 22, 2022",
                    Amount = 4789.89,
                    IsCredited = true
                },
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.HomeCity,
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
                    ImageIcon = MauiKitIcons.Play,
                    IconColor = Color.FromArgb("#7644ad"),
                    Title = "Netflix Subscription",
                    Date = "7:00 AM - Mar 22, 2023",
                    Amount = 519.99,
                    IsCredited = false
                },
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.NaturePeople,
                    IconColor = Color.FromArgb("#7644ad"),
                    Title = "Arthur Kim",
                    Date = "7:00 AM - Mar 22, 2023",
                    Amount = 65,
                    IsCredited = false
                },
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.Account,
                    IconColor = Color.FromArgb("#d54381"),
                    Title = "Nell Sanchez",
                    Date = "3:05 PM - Aug 22, 2022",
                    Amount = 350,
                    IsCredited = true
                },
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.NaturePeople,
                    IconColor = Color.FromArgb("#3e5aff"),
                    Title = "Amelia Coleman",
                    Date = "3:05 PM - Aug 22, 2022",
                    Amount = 70.50,
                    IsCredited = false
                },
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.CreditCard,
                    IconColor = Color.FromArgb("#af4aff"),
                    Title = "Credit Card Bill",
                    Date = "3:05 PM - Aug 22, 2022",
                    Amount = 30.50,
                    IsCredited = false
                },
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.CreditCardRefund,
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
                    ImageIcon = MauiKitIcons.Account,
                    IconColor = Color.FromArgb("#3e5aff"),
                    Title = "Chase Blair",
                    Date = "3:05 PM - Aug 22, 2022",
                    Amount = 20.50,
                    IsCredited = false
                },
                new TransactionData
                {
                    ImageIcon = MauiKitIcons.CreditCardMultiple,
                    IconColor = Color.FromArgb("#af4aff"),
                    Title = "Credit Card Bill",
                    Date = "3:05 PM - Aug 22, 2022",
                    Amount = 80.50,
                    IsCredited = false
                },
            };
        }
    }

    public List<WalletContact> GetContacts
    {
        get
        {
            return new List<WalletContact>
            {
                new WalletContact
                {
                    Name = "Alaya Cordova",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-1.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Cecily Trujillo",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-2.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Eathan Sheridan",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-3.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Komal Orr",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-4.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Sariba Abood",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-5.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Justin O'Moore",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-6.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Alissia Shah",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-7.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Antoni Whitney",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-8.jpg",
                    PhoneNumber = "324-157-3235"
                },
                new WalletContact
                {
                    Name = "Jaime Zuniga",
                    Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-9.jpg",
                    PhoneNumber = "324-157-3235"
                }
            };
        }
    }

    public List<ServiceCategory> GetPaymentServices
    {
        get
        {
            return new List<ServiceCategory>
            {
                new ServiceCategory
                {
                    Name = "Electricity",
                    Icon = MauiKitIcons.LightbulbOn,
                    IconColor = Colors[Random.Next(6)],
                },
                new ServiceCategory
                {
                    Name = "Water",
                    Icon = MauiKitIcons.Water,
                    IconColor = Colors[Random.Next(6)],
                },
                new ServiceCategory
                {
                    Name = "Internet",
                    Icon = MauiKitIcons.Wifi,
                    IconColor = Colors[Random.Next(6)],
                },
                new ServiceCategory
                {
                    Name = "Television",
                    Icon = MauiKitIcons.Television,
                    IconColor = Colors[Random.Next(6)],
                }
            };
        }
    }

    public ObservableCollection<ServiceCategoryGroup> GetAllServices
    {
        get
        {
            return new ObservableCollection<ServiceCategoryGroup>
            {
                new ServiceCategoryGroup ("Bill", new List<ServiceCategory>
                {
                    new ServiceCategory
                    {
                        Name = "Electricity",
                        Icon = MauiKitIcons.LightbulbOn,
                        IconColor = Colors[Random.Next(3)],
                    },
                    new ServiceCategory
                    {
                        Name = "Water",
                        Icon = MauiKitIcons.Water,
                        IconColor = Colors[Random.Next(3)],
                    },
                    new ServiceCategory
                    {
                        Name = "Internet",
                        Icon = MauiKitIcons.Wifi,
                        IconColor = Colors[Random.Next(3)],
                    },
                    new ServiceCategory
                    {
                        Name = "Television",
                        Icon = MauiKitIcons.Television,
                        IconColor = Colors[Random.Next(3)],
                    },
                    new ServiceCategory
                    {
                        Name = "E-Wallet",
                        Icon = MauiKitIcons.Wallet,
                        IconColor = Colors[Random.Next(3)],
                    },
                    new ServiceCategory
                    {
                        Name = "Games",
                        Icon = MauiKitIcons.Gamepad,
                        IconColor = Colors[Random.Next(3)],
                    },
                    new ServiceCategory
                    {
                        Name = "Merchant",
                        Icon = MauiKitIcons.Cart,
                        IconColor = Colors[Random.Next(3)],
                    },
                    new ServiceCategory
                    {
                        Name = "Installment",
                        Icon = MauiKitIcons.Card,
                        IconColor = Colors[Random.Next(3)],
                    }
                }),
                new ServiceCategoryGroup ("Insurance", new List<ServiceCategory>
                {
                    new ServiceCategory
                    {
                        Name = "Health",
                        Icon = MauiKitIcons.Security,
                        IconColor = Colors[Random.Next(4)],
                    },
                    new ServiceCategory
                    {
                        Name = "Mobile",
                        Icon = MauiKitIcons.Cellphone,
                        IconColor = Colors[Random.Next(4)],
                    },
                    new ServiceCategory
                    {
                        Name = "Motor",
                        Icon = MauiKitIcons.Motorbike,
                        IconColor = Colors[Random.Next(4)],
                    },
                    new ServiceCategory
                    {
                        Name = "Car",
                        Icon = MauiKitIcons.Car,
                        IconColor = Colors[Random.Next(4)],
                    }
                }),
                new ServiceCategoryGroup ("Option", new List<ServiceCategory>
                {
                    new ServiceCategory
                    {
                        Name = "Assurance",
                        Icon = MauiKitIcons.Briefcase,
                        IconColor = Colors[Random.Next(5)],
                    },
                    new ServiceCategory
                    {
                        Name = "Shopping",
                        Icon = MauiKitIcons.Shopping,
                        IconColor = Colors[Random.Next(5)],
                    },
                    new ServiceCategory
                    {
                        Name = "Deal",
                        Icon = MauiKitIcons.Sale,
                        IconColor = Colors[Random.Next(5)],
                    },
                    new ServiceCategory
                    {
                        Name = "Invest",
                        Icon = MauiKitIcons.ProgressCheck,
                        IconColor = Colors[Random.Next(5)],
                    }
                })
            };
        }
    }
    public List<CardData> GetMyCards
    {
        get
        {
            return new List<CardData>
            {
                new CardData
                {
                    CardType = "CREDIT CARD",
                    Number = "****  ****  ****  5838",
                    Name = "Alex Wilson",
                    Expiry = "08/25",
                    CardCvv = 846,
                    BackgroundImage = "abs_bg.png",
                    BackgroundGradientStart = Color.FromArgb("#BF3F0041"),
                    BackgroundGradientEnd = Color.FromArgb("#012E8B"),
                    CardTypeIcon = "master_card.png"
                },
                new CardData
                {
                    CardType = "DEBIT CARD",
                    Number = "****  ****  ****  0743",
                    Name = "Alex Wilson",
                    Expiry = "05/23",
                    CardCvv = 543,
                    BackgroundImage = "bg_tablet.png",
                    BackgroundGradientStart = Color.FromArgb("#af4aff"),
                    BackgroundGradientEnd = Color.FromArgb("#3e5aff"),
                    CardTypeIcon = "visa.png"
                },
                new CardData
                {
                    CardType = "CREDIT CARD",
                    Number = "****  ****  ****  0629",
                    Name = "Alex Wilson",
                    Expiry = "06/26",
                    CardCvv = 346,
                    BackgroundImage = "bg_trans.png",
                    BackgroundGradientStart = Color.FromArgb("#d54381"),
                    BackgroundGradientEnd = Color.FromArgb("#7644ad"),
                    CardTypeIcon = "master_card.png"
                },
            };
        }
    }
}
