using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Dominio.Servicios.AtributosProducto;
using Atributos.Dominio.Servicios.Localizaciones;
using Atributos.Dominio.Servicios.Parametros;
using Atributos.Dominio.Servicios.TiposDocumento;
using Atributos.Infraestructura.RepositorioGenerico;
using Atributos.Infraestructura.Repositorios;
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
        Version = "V.1.2.1",
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
builder.Services.AddTransient<ITipoDocumentoRepositorio, TiposDocumentoRepositorio>();
builder.Services.AddTransient<ILocalizacionRepositorio, LocalizacionRepositorio>();
builder.Services.AddTransient<IZonaRepositorio, ZonaRepositorio>();

//Capa Dominio - Servicios
builder.Services.AddTransient<ConsultarAtributos>();
builder.Services.AddTransient<ConsultarParametros>();
builder.Services.AddTransient<ListadoTiposDocumento>();
builder.Services.AddTransient<LocalizarCiudad>();
builder.Services.AddTransient<LocalizarZona>();
builder.Services.AddTransient<LocalizarPais>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
