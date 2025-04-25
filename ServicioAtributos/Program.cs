using Atributos.Aplicacion.Consultas.Ciudades;
using Atributos.Aplicacion.Consultas.TiposDocumento;
using Atributos.Aplicacion.Consultas.Zonas;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;
using Atributos.Infraestructura.Repositorios.Ciudades;
using Atributos.Infraestructura.Repositorios.TiposDocumento;
using Atributos.Infraestructura.Repositorios.Zonas;
using Clientes.Infraestructura.RepositorioGenerico;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Ciudades
builder.Services.AddDbContext<CiudadesDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBaseCiudades<>));
builder.Services.AddTransient<ICiudadRepositorio, CiudadRepositorio>();
builder.Services.AddScoped<IConsultasCiudades, Atributos.Aplicacion.Consultas.Ciudades.ManejadorConsultas>();

//Zonas
builder.Services.AddDbContext<ZonasDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBaseZonas<>));
builder.Services.AddTransient<IZonaRepositorio, ZonaRepositorio>();
builder.Services.AddScoped<IConsultasZonas, Atributos.Aplicacion.Consultas.Zonas.ManejadorConsultas>();

//TiposDocumento
builder.Services.AddDbContext<TiposDocumentoDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBaseTiposDocumento<>));
builder.Services.AddTransient<ITipoDocumentoRepositorio, TiposDocumentoRepositorio>();
builder.Services.AddScoped<IConsultasTiposDocumento, Atributos.Aplicacion.Consultas.TiposDocumento.ManejadorConsultas>();

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
