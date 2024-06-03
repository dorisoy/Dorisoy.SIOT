

namespace SIOT
{
    // All the code in this file is included in all platforms.
    public class PopupAction
    {
        public static async Task<T> DisplayPopup<T>(BasePopupPage page) where T : new()
        {
            try
            {
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(page);
                }
                return (T)await page.returnResultTask.Task;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static async Task<string> DisplayPopup(BasePopupPage page)
        {
            try
            {
                if (Application.Current?.MainPage != null)
                    await Application.Current.MainPage.Navigation.PushModalAsync(page);

                return (string)await page.returnResultTask.Task;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static async Task ClosePopup(object returnValue = null)
        {
            if (Application.Current?.MainPage != null && Application.Current.MainPage.Navigation.ModalStack.Count > 0)
            {
                try
                {
                    var currentPage = (BasePopupPage)Application.Current.MainPage.Navigation.ModalStack.LastOrDefault();
                    currentPage?.returnResultTask.TrySetResult(returnValue);
                }
                catch (Exception ex)
                {

                }
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }

    }
}
