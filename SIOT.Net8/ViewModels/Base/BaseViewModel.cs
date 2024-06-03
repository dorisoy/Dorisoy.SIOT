
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SIOT.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //private bool _isBusy;
        //public bool IsBusy
        //{
        //    get => _isBusy;
        //    set => SetProperty(ref _isBusy, value);
        //}

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        private string loadingText = string.Empty;
        public string LoadingText
        {
            get { return loadingText; }
            set { SetProperty(ref loadingText, value); }
        }

        private bool dataLoaded = false;
        public bool DataLoaded
        {
            get { return dataLoaded; }
            set { SetProperty(ref dataLoaded, value); }
        }

        private bool isErrorState = false;
        public bool IsErrorState
        {
            get { return isErrorState; }
            set { SetProperty(ref isErrorState, value); }
        }

        private string errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private string errorImage = string.Empty;
        public string ErrorImage
        {
            get { return errorImage; }
            set { SetProperty(ref errorImage, value); }
        }

        public BaseViewModel() =>
        IsErrorState = false;


        //Set Loading Indicators for Page
        protected void SetDataLoadingIndicators(bool isStarting = true)
        {
            if (isStarting)
            {
                IsBusy = true;
                DataLoaded = false;
                IsErrorState = false;
                ErrorMessage = "";
                ErrorImage = "";
            }
            else
            {
                LoadingText = "";
                IsBusy = false;
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
