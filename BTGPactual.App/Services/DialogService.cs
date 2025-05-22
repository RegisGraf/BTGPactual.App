namespace BTGPactual.App.Services
{
    public static class DialogService
    {
        public static async void DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public static async Task<bool> DisplayConfirm(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public static async void DisplayConfirm(string title, string message, string accept)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, accept);
        }
    }
}
