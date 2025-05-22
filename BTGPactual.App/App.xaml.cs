using BTGPactual.App.LocalDataBase;
using BTGPactual.App.View;
using BTGPactual.App.ViewModel;
#if WINDOWS
using Microsoft.UI.Windowing;
#endif


namespace BTGPactual.App
{
    public partial class App : Application
    {
        LocalDbService _localDbService;
        public App(LocalDbService localDbService)
        {
            InitializeComponent();
            _localDbService = localDbService;
            
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
#if WINDOWS
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();

                // Maximiza a janela principal
                var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
                var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

                if (appWindow != null)
                {
                    var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
                    appWindow.MoveAndResize(new Windows.Graphics.RectInt32(
                        0, 0,
                        (int)displayInfo.Width,
                        (int)displayInfo.Height));

                    // Ou simplesmente maximizar
                    var window = handler.PlatformView;
                    window.ExtendsContentIntoTitleBar = true;

                    if (appWindow.Presenter is OverlappedPresenter overlappedPresenter)
                    {
                        overlappedPresenter.Maximize();
                    }
                }
#endif
            });


        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window mainPageWindow = new Window(new ClientesView(new ClientesViewModel(_localDbService)));
            return mainPageWindow;
        }

        public static void OpenCenteredWindow(Window newWindow)
        {
#if WINDOWS
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();

                var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
                var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

                if (appWindow != null)
                {
                    // Centraliza a janela
                    var displayArea = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(windowId, Microsoft.UI.Windowing.DisplayAreaFallback.Nearest);
                    var centerX = (displayArea.WorkArea.Width / 2) - 400;
                    var centerY = (displayArea.WorkArea.Height / 2) - 290;

                    appWindow.MoveAndResize(new Windows.Graphics.RectInt32(
                    (int)centerX, (int)centerY,
                        800,  // Largura
                        500)); // Altura
                }
            });

            Application.Current.OpenWindow(newWindow);
#endif
        }
    }
}