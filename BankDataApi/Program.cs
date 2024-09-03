var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
    "AllowOrigins",
    policy => { policy.AllowAnyOrigin(); policy.AllowAnyHeader(); policy.AllowAnyMethod(); });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigins");
app.Run();
