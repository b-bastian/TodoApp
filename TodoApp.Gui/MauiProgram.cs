﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoApp.Core;
using TodoApp.Core.ViewModels;
using TodoApp.TodoData;

namespace TodoApp.Gui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IRepository>(new StaticData());

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();



#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

