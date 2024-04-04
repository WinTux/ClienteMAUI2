using _20240326.ConexionDatos;
using _20240326.Pages;
using Microsoft.Extensions.Logging;

namespace _20240326
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IRestConexionDatos,RestConexionDatos>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<GestionPlatosPage>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
