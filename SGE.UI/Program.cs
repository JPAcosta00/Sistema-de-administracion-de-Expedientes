//directivas using
using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;

var builder = WebApplication.CreateBuilder(args);

//inicializo la base de datos
SGESqlite.Inicializar();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//agrego los servicios al contenedor DI
builder.Services.AddTransient<ExpedienteValidador>();
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoObtenerExpediente>();
builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorio>();

builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();

builder.Services.AddTransient<TramiteValidador>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteListado>();
builder.Services.AddTransient<CasoDeUsoObtenerTramite>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddScoped<ITramiteRepositorio, TramiteRepositorio>();

builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioListar>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddTransient<CasoDeUsoDevuelveUsuario>();
builder.Services.AddTransient<CasoDeUsoUsuarioRegistro>();
builder.Services.AddTransient<CasoDeUsoUsuarioTienePermisos>();
builder.Services.AddTransient<CasoDeUsoDevuelveAdministrador>();
builder.Services.AddTransient<CasoDeUsoInicioSesion>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
//podria agregar un UsuarioValidador donde controle los nombres y contraseñas de cada uno.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
