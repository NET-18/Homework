using Generate.Services;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddScoped<EmailsService>();
        builder.Services.AddScoped<FriendsService>();
        builder.Services.AddScoped<LargeTextsService>();
        builder.Services.AddScoped<MergingService>();
        builder.Services.AddScoped<NamesAndSurnamesService>();
        builder.Services.AddScoped<PhoneNumbersService>();
        builder.Services.AddScoped<WordsService>();

        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
