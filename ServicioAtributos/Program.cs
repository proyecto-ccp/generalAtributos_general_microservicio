using Atributos.Aplicacion.Consultas.Ciudades;
using Atributos.Aplicacion.Consultas.TiposDocumento;
using Atributos.Aplicacion.Consultas.Zonas;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Dominio.Servicios.Ciudades;
using Atributos.Dominio.Servicios.TiposDocumento;
using Atributos.Dominio.Servicios.Zonas;
using Atributos.Infraestructura.RepositorioGenerico;
using Atributos.Infraestructura.Repositorios.Ciudades;
using Atributos.Infraestructura.Repositorios.TiposDocumento;
using Atributos.Infraestructura.Repositorios.Zonas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Ciudades
builder.Services.AddDbContext<CiudadesDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CiudadesDBContext")));
// Registrar repositorios específicos
builder.Services.AddTransient(typeof(IRepositorioBaseCiudades<>), typeof(RepositorioBaseCiudades<>));
builder.Services.AddTransient<ICiudadRepositorio, CiudadRepositorio>();
builder.Services.AddScoped<IConsultasCiudades, ManejadorConsultasCiudad>();
builder.Services.AddScoped<ObtenerCiudad>();
builder.Services.AddScoped<ListadoCiudades>();
builder.Services.AddScoped<ListadoCiudadesPorRegion>();

// Zonas
builder.Services.AddDbContext<ZonasDBContext>(options2 =>
    options2.UseNpgsql(builder.Configuration.GetConnectionString("ZonasDBContext")));
// Registrar repositorios específicos
builder.Services.AddTransient(typeof(IRepositorioBaseZonas<>), typeof(RepositorioBaseZonas<>));
builder.Services.AddTransient<IZonaRepositorio, ZonaRepositorio>();
builder.Services.AddScoped<IConsultasZonas, ManejadorConsultasZona>();
builder.Services.AddScoped<ObtenerZona>();
builder.Services.AddScoped<ListadoZonas>();
builder.Services.AddScoped<ListadoZonasPorCiudad>();

// TiposDocumento
builder.Services.AddDbContext<TiposDocumentoDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TiposDocumentoDBContext")));
// Registrar repositorios específicos
builder.Services.AddTransient(typeof(IRepositorioBaseTiposDocumento<>), typeof(RepositorioBaseTiposDocumento<>));
builder.Services.AddTransient<ITipoDocumentoRepositorio, TiposDocumentoRepositorio>();
builder.Services.AddScoped<IConsultasTiposDocumento, ManejadorConsultasTipoDocumento>();
builder.Services.AddScoped<ListadoTiposDocumento>();

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
