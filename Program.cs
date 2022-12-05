global using sdsds.Models;
using Microsoft.EntityFrameworkCore;
using sdsds.Data;
using sdsds.Services.CharaterServices;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services
    .AddEntityFrameworkSqlite()
    .AddDbContext<DataContext>(opt =>
    opt.UseSqlite( connectionString,
        b => b.MigrationsAssembly("sdsds")));
//builder.Services.AddDbContext<DataContext>(options => options.Use(builder.Configure.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICharaterServices, CharacterServices>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
Console.WriteLine(
    "serega"+ connectionString);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
