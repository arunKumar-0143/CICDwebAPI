var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", (HttpContext context) =>
{
    var userAgent = context.Request.Headers["User-Agent"].ToString();

    return Results.Ok(new
    {
        Message = "Hello from Web API",
        UserAgent = userAgent
    });
});

app.Run();
