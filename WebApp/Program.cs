var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (bool.TryParse(Environment.GetEnvironmentVariable("APPLY_MIGRATIONS"), out var applyMigrations) && applyMigrations)
{
    for (var i = 20; i > 0; i--)
    {
        Console.WriteLine($"Waiting for {i} seconds before exiting...");
        await Task.Delay(TimeSpan.FromSeconds(1));
    }

    Console.WriteLine("Exiting now.");
    Environment.Exit(0);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseHealthChecks("/health");

app.MapRazorPages();

app.Run();
