using TestProject.Interfaces;
using TestProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;//JsonSerialize methodunu null yapt�m. ��nk� Property isimleri yazd���m �ekilde g�nderilsin istiyorum.
                });

builder.Services.AddScoped<ITestRepository, TestRepository>();//Dependency Injection �o�u projede s�kl�kla kullan�lan bir �zellik.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
