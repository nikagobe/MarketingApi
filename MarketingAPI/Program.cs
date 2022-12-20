using System.Data;
using System.Reflection;
using Dapper;
using MarketingAPI;
using Microsoft.Data.SqlClient;
using NetworkMarketingCore.Contracts.Config;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Implementations.Helper;
using NetworkMarketingCore.Implementations.Repositories;
using NetworkMarketingCore.Implementations.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(IDbConnection), factory =>
{
    var conn = new SqlConnection(builder.Configuration.GetSection("Database").GetChildren().ElementAt(0).Value);
    DefaultTypeMap.MatchNamesWithUnderscores = true;
    conn.Open();
    return conn;
});


var assemblies =  Assembly.GetEntryAssembly()?.GetReferencedAssemblies().Select(Assembly.Load);

var registrations = assemblies.SelectMany(i => i.GetExportedTypes())
    .Where(type =>
        type.Namespace != null && (type.Namespace.Contains("Repositories") ||
                                   type.Namespace.Contains("Services"))
                               && (type.Name.EndsWith("Service") || type.Name.EndsWith("Repository"))
                               && type.IsInterface == false);


foreach (var reg in registrations)
{
    builder.Services.AddScoped(reg.GetInterfaces().First(), reg);
}


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<RequiredFieldFilter>();
});


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
