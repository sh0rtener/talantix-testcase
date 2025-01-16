using Talantix.Presenters.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.UseEfContext(builder.Configuration);

var app = builder.Build();
app.Services.InitializeDbByEf();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<AuditRequestDataMiddleware>();
app.MapControllers();

app.Run();
