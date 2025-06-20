using CausaViva.Services.Distrito;
using CausaViva.Services.InscripcionVoluntariado;
using CausaViva.Services.Organizacion;
using CausaViva.Services.SeguridadLoginUsuario;
using CausaViva.Services.Usuario;
using CausaViva.Services.Voluntariado_Requisito;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDistritoService, DistritoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IOrganizacionService, OrganizacionService>();
builder.Services.AddScoped<IVoluntariado_RequisitoService, Voluntariado_RequisitosService>();
builder.Services.AddScoped<IInscripcionVoluntariado, InscripcionVoluntariado>();
builder.Services.AddScoped<ISeguridadLoginRepository, SeguridadLoginRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Tu frontend Vite/Vue
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
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
app.UseCors("PermitirFrontend");
app.MapControllers();

app.Run();
