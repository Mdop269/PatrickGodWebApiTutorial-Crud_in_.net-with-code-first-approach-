using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PatrickGodWebApiTutorial.Data;

// args is a built-in array that represents the command-line arguments passed 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//it's enabling the framework to use controllers for handling HTTP requests and returning responses. 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//This method adds the API Endpoints Explorer service to the IServiceCollection
//An API endpoint is a digital location where an application programming interface (API)
//receives API calls, also known as API requests, for resources on its server. 
builder.Services.AddEndpointsApiExplorer();

//Swagger is a popular API documentation framework that provides a user-friendly interface for exploring and interacting with APIs
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
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

app.Run();

 