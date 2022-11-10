﻿using Microsoft.Extensions.Logging;
using MauiApp1.Data;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;

namespace MauiApp1;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddBlazorise(options =>
        {
            options.Immediate = true;
        })
		.AddBootstrap5Providers()
		.AddFontAwesomeIcons();

        builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
