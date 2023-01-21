using System;
using Microsoft.Data.SqlClient;
using Closit.Models;
using Closit.Controllers;
using Closit.Pages;
using System.Net.Security;
using Npgsql;
namespace main {
    class Program {
        static void Main(string[] args) {
            // COCKROACH INFO---------------------------------------------------
            var connStringBuilder = new NpgsqlConnectionStringBuilder();
            
            connStringBuilder.Host = "east-blob-8299.7tt.cockroachlabs.cloud";
            connStringBuilder.Port = 26257;
            connStringBuilder.SslMode = SslMode.Require;
            connStringBuilder.Username = "Ashassins";
            connStringBuilder.Password = "oyY1nkAuz5-YaJ4GpX6UhQ";
            connStringBuilder.Database = "defaultdb";
            connStringBuilder.RootCertificate = "~/.postgresql/root.crt";
            connStringBuilder.TrustServerCertificate = true;
            // END COCKROACH INFO-----------------------------------------------
            
            var builder = WebApplication.CreateBuilder(args);
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
        }
    }
}