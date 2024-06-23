using Employee_API.Model;
using Employee_API.Repository;
using Employee_API.Repository.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//DI
builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
builder.Services.AddScoped<ApiResponseHelper>();


//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));  

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Allow requests from this origin
              .AllowAnyMethod()                   // Allow any HTTP method (GET, POST, etc.)
              .AllowAnyHeader();                  // Allow any header in the request
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

app.MapControllers();
app.UseCors("policy");
app.Run();
