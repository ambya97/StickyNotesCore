using Microsoft.OpenApi.Models;
using StickyNotesCore.Configurations;
using StickyNotesCore.Domain.Logic.Repository;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notes", Version = "v1" });
//});
builder.Services.AddNoteServices(builder.Configuration);
builder.Services.AddInfrastructureDependencies(builder.Configuration);
builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(builder.Configuration.GetConnectionString("defaultcon")));
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);
var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddlewares();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
