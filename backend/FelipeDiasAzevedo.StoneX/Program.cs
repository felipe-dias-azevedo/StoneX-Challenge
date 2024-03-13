using FelipeDiasAzevedo.StoneX.Business.Services.Product;
using FelipeDiasAzevedo.StoneX.Infra.Configuration.Mongo;
using FelipeDiasAzevedo.StoneX.Infra.Repositories.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoSettings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("DefaultConnections:ConnectionString").Value!;
    options.Database = builder.Configuration.GetSection("DefaultConnections:DatabaseName").Value!;
});
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddApiVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
