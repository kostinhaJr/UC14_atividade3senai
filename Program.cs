using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddScoped<ExoContext, ExoContext>();
builder.Services.AddControllers();
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();

// Autorização (caso esteja usando [Authorize])
builder.Services.AddAuthorization();
// Se usar autenticação, adicione também:
// builder.Services.AddAuthentication(...);

var app = builder.Build();

app.UseRouting();

// ⚠️ Middleware de autorização (necessário para [Authorize])
app.UseAuthorization();

// Se tiver autenticação:
// app.UseAuthentication(); ← isso viria antes do UseAuthorization

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
