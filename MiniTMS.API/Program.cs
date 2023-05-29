using MiniTMS.Dominio._Base;
using MiniTMS.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

StartupIoC.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    await next.Invoke();

    var unitOfWork = context.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
    await unitOfWork.Commit();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
