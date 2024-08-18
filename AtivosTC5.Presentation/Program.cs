using ApiUsuarios.Services.Extensions;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Interfaces.Services;
using AtivosTC5.Domain.Services;
using AtivosTC5.Infra.Data.Contexts;
using AtivosTC5.Infra.Data.Repositories;
using AtivosTC5.Services.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TechChallengeConection");

builder.Services.AddDbContext<SqlServerContext>(
    o => o.UseSqlServer(connectionString)
    );

// Add services to the container.

builder.Services.AddRouting(map => map.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();
builder.Services.AddDependencyInjection();
builder.Services.AddJwtBearer();
builder.Services.AddCorsPolicy();
builder.Services.AddMvc(); 

var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCorsPolicy();
app.Run();

