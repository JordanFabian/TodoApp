using Microsoft.Extensions.Logging;
using TodoApp.Services;
using TodoApp.ViewModels;
using TodoApp.Views;

namespace TodoApp;

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

		builder.Services.AddSingleton<IAgendaService, AgendaService>();

		builder.Services.AddSingleton<AgendaListPage>();
		builder.Services.AddTransient<AddUpdateAgendaDetail>();

        builder.Services.AddSingleton<AgendaListPageViewModel>();
		builder.Services.AddTransient<AddUpdateAgendaDetailViewModel>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

}
