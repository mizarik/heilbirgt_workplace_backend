using heilbrigt_workplace_backend_v01.EntityFramework.Context;
using heilbrigt_workplace_backend_v01.EntityFramework.Manager;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigin = "_allowedOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrigin,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region EntityFramework
// Context
builder.Services.AddDbContext<HeilbrigtContext>();

builder.Services.AddTransient<IUserManager, UserManager>();


#endregion EntityFramework

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
app.UseCors(allowedOrigin);
app.Run();
