using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Interfaces.Services;
using AtivosTC5.Domain.Services;
using AtivosTC5.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Configurando o CORS

builder.Services.AddCors(cors => cors.AddPolicy("DefaultPolicy",
    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

#endregion

#region Configurando as injeção de dependência do projeto

builder.Services.AddTransient<IAtivoRepository, AtivoRepository>();
builder.Services.AddTransient<IAtivoTipoRepository, AtivoTipoRepository>();
builder.Services.AddTransient<IPortifolioRepository, PortifolioRepository>();
builder.Services.AddTransient<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddTransient<IAtivoDomainService, AtivoDomainService>();
builder.Services.AddTransient<IAtivoTipoDomainService, AtivoTipoDomainService>();
builder.Services.AddTransient<IPortifolioDomainService, PortifolioDomainService>();
builder.Services.AddTransient<ITransacaoDomainService, TransacaoDomainService>();
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
