using TaskSphere.Application;
using TaskSphere.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------
// 1️⃣ Configure Serilog for logging
// ---------------------------------------------------------
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// ---------------------------------------------------------
// 2️⃣ Add Services from each layer
// ---------------------------------------------------------

builder.Services.AddInfrastructureServices(builder.Configuration); // <-- from TaskSphere.Infrastructure
builder.Services.AddApplicationServices();      // <-- from TaskSphere.Application

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();     // for Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", p =>
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// ---------------------------------------------------------
// 3️⃣ Middleware Pipeline
// ---------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
