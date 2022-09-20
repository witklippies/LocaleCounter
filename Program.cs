using System.Globalization;
using Microsoft.AspNetCore.Localization;

using LocaleCounter.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMyCounter, MyCounter>();
// builder.Services.AddSingleton<INumberToWords, NumberToWordsLocal>();
builder.Services.AddSingleton<INumberToWords, NumberToWordsLocalCulture>();

var app = builder.Build();

var supportedCultures = new List<CultureInfo> 
{
    new CultureInfo("en-US"),
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
