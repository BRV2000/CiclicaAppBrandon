using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using Plugin.LocalNotification;

namespace Frontend
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureSyncfusionCore()
                .UseMauiApp<App>()
                .UseSimpleToolkit()
                .UseLocalNotification()
                .UseSimpleShell()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Verah___.ttf", "Verah");
                    fonts.AddFont("windows_command_prompt.ttf", "Prompt");
                    fonts.AddFont("fa-brands-400.ttf", "FontAwesome");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesome6");
                });


#if ANDROID || IOS
		builder.DisplayContentBehindBars();
#endif

            return builder.Build();
        }
    }
}