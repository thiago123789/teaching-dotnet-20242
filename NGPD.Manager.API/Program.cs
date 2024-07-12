using Microsoft.EntityFrameworkCore;
using NGPD.Manager.Data;
using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Data.Contracts.Base;
using NGPD.Manager.Servicesç;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IDisponibilidadeService, DisponibilidadeService>();

builder.Services.AddDbContextPool<ManagerDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ManagerSqlServer"))
);

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

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.Run();
