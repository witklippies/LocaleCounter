using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;

using LocaleCounter.Entities;
using LocaleCounter.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMyCounter, MyCounter>();
// builder.Services.AddSingleton<INumberToWords, NumberToWordsLocal>();

builder.Services.AddSingleton<INumberToWords, NumberToWordsLocalCulture>();

//builder.Services.AddDbContext<LocalizationDBContext>(opt => opt.UseInMemoryDatabase("LocaleCouter"));

var app = builder.Build();

var supportedCultures = new List<CultureInfo> 
    {
        new CultureInfo("en-US"),
        new CultureInfo("en-GB"),
        new CultureInfo("af-ZA"),
    };

    var options = new RequestLocalizationOptions 
    {
        DefaultRequestCulture = new RequestCulture("en-ZA"),
        SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

app.UseRequestLocalization(options);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
