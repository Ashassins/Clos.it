var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

// COCKRAOCH INFO
// connStringBuilder.Host = "{host-name}";
connStringBuilder.Port = 26257;
connStringBuilder.SslMode = SslMode.Require;
connStringBuilder.Username = "Ashassins";
connStringBuilder.Password = "oyY1nkAuz5-YaJ4GpX6UhQ";
connStringBuilder.Database = "defaultdb";
connStringBuilder.RootCertificate = "~/.postgresql/root.crt";
connStringBuilder.TrustServerCertificate = true;