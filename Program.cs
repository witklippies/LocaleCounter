using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

using LocaleCounter.Entities;
using LocaleCounter.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMyCounter, MyCounter>();

// builder.Services.AddSingleton<INumberToWords, NumberToWordsLocal>();

var optionsBuilder = new DbContextOptionsBuilder<LocalizationDBContext>();
optionsBuilder.UseInMemoryDatabase("LocalCounter");
var context = new LocalizationDBContext(optionsBuilder.Options); 

var stringLocalizerFactory = new MyStringLocalizerFactory(context);
var stringLocalizer = stringLocalizerFactory.Create(null);

builder.Services.AddSingleton<INumberToWords, NumberToWordsCulture>(x =>
{
    var numberToWordsCulture = new NumberToWordsCulture(stringLocalizer);
    return numberToWordsCulture;
});

var app = builder.Build();

// ***** START OF LOCALIZATION SECTION *****
var supportedCultures = new List<CultureInfo>
{
    new CultureInfo("af-ZA"),
    new CultureInfo("fr-MA"),
    new CultureInfo("ar-MA")
};

var options = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-ZA"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

app.UseRequestLocalization(options);
// ***** END OF LOCALIZATION SECTION *****

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
