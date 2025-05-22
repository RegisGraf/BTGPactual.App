using BTGPactual.App.LocalDataBase;
using BTGPactual.App.View;
using BTGPactual.App.ViewModel;
using Microsoft.Extensions.Logging;

namespace BTGPactual.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            #region Interfaces and Services
            builder.Services.AddSingleton<LocalDbService>();
            #endregion

            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            #region ViewModels
            builder.Services.AddSingleton<ClientesViewModel>();
            builder.Services.AddSingleton<CriarOuALterarClienteViewModel>();
            #endregion

            return builder;
        }

        public static MauiAppBuilder RegisterView(this MauiAppBuilder builder)
        {
            #region View
            builder.Services.AddTransient<ClientesView>();
            builder.Services.AddTransient<CriarOuAlterarClienteView>();
            #endregion

            return builder;
        }
    }
}
