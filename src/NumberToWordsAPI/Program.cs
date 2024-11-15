using NumberToWordsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

string? numberToWordsURL = builder.Configuration.GetValue<string>("NumberToWordsURL");

if (numberToWordsURL != null)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder
                    .AllowCredentials()
                    .WithOrigins(numberToWordsURL)
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<INumberToWordsService, NumberToWordsService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
