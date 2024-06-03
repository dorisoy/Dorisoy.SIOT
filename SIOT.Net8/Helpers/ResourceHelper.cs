
namespace SIOT
{
    public static class ResourceHelper
    {
        public static T FindResource<T>(string resourceKey)
        {
            if (Application.Current?.Resources != null &&
                Application.Current.Resources.TryGetValue(resourceKey, out var result))
            {
                if (result is T)
                {
                    return (T)result;
                }
                else if (result is OnPlatform<T>)
                {
                    return (OnPlatform<T>)result;
                }
            }

            return default(T);
        }
    }
}