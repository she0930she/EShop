using ApplicationCore.Repository;
using ApplicationCore.Services;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// attach it to connectionstring
builder.Services.AddDbContext<CustomerDbContext>(option =>
{
    //option.UseSqlServer(Environment.GetEnvironmentVariable("CustomerDB")); 
    // comment dev
    option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDB"));
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
    // for contextDb not to track single instance of one entity
});
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>(); // in controller
builder.Services.AddScoped<ICustomerRepoAsync, CustomerRepoAsync>(); // in service
builder.Services.AddScoped<IUserServiceAsync, UserServiceAsync>(); // in controller
builder.Services.AddScoped<IUserRepoAsync, UserRepoAsync>(); // in service
//builder.IServices.AddScoped<JwtTokenHandler>();
builder.Services.AddSingleton<JwtTokenHandler>();

// JWT
builder.Services.AddCustomJwtAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthentication(); // jwtHandler
app.UseAuthorization();

app.MapControllers();

app.Run();