var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// IMPLEMENTING MIDDLEWARE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Standard Middleware: Authentication & Authorization
app.UseAuthorization();

// Custom Logging Middleware logic (Built-in)
app.Use(async (context, next) => 
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
});

app.MapControllers();

app.Run();