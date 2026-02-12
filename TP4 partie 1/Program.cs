using APIfilms.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using TP4_partie_1.Models.DataManager;
using TP4_partie_1.Models.EntityFramework;
using TP4_partie_1.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FilmRatingsDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("FilmRatingsDBContext")));
builder.Services.AddScoped<IDataRepository<Utilisateur>, UtilisateurManager>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
