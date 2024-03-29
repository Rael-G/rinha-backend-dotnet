using Microsoft.EntityFrameworkCore;
using Rinha.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

const string CONNECTION = "Host=127.0.0.1;Port=5432;Database=rinha;Username=rinha;Password=rinha;Maximum Pool Size=45;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(CONNECTION)
);
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

//Migrate
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();