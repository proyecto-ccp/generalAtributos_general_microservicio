using Atributos.Aplicacion.Consultas.Ciudades;
using Atributos.Aplicacion.Consultas.TiposDocumento;
using Atributos.Aplicacion.Consultas.Zonas;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Dominio.Servicios.AtributosProducto;
using Atributos.Dominio.Servicios.Ciudades;
using Atributos.Dominio.Servicios.Parametros;
using Atributos.Dominio.Servicios.TiposDocumento;
using Atributos.Dominio.Servicios.Zonas;
using Atributos.Infraestructura.RepositorioGenerico;
using Atributos.Infraestructura.Repositorios;
using Atributos.Infraestructura.Repositorios.Ciudades;
using Atributos.Infraestructura.Repositorios.TiposDocumento;
using Atributos.Infraestructura.Repositorios.Zonas;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V.1.0.1",
        Title = "Servicio Atributos",
        Description = "Administración de atributos y parámetros"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            Array.Empty<string>()
            }
        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Atributos.Aplicacion")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Capa Infraestructura
builder.Services.AddDbContext<AtributosDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("AtributosDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IAtributosProductoRepositorio, AtributosProductoRepositorio>();
builder.Services.AddTransient<IParametroRepositorio, ParametroRepositorio>();
//Capa Dominio - Servicios
builder.Services.AddTransient<ConsultarAtributos>();
builder.Services.AddTransient<ConsultarParametros>();

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
