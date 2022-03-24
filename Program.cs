using ShoppingCartApi.ShoppingCart;
using ShoppingCartApi.ShoppingCart.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//builder.Services.AddCors(c =>
//{
//    c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:7256", "http://localhost:5256"));
//});
builder.Services.RegisterApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
//app.UseCors("AllowOrigin");

app.Run();
