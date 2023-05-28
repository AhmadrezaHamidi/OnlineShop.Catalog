using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using ShopeWeb.Src;
using ShopWeb.Base.PagedList.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ShopDbCobtext>(opt => opt.UseSqlServer("Server=127.0.0.1,1433;Database=Ahmad;User Id=sa;Password=yourStrong(!)Password;MultipleActiveResultSets=True;"))
//.AddDbContext<BloggingContext>(opt => opt.UseInMemoryDatabase("UnitOfWork"))
                .AddUnitOfWork<ShopDbCobtext>();
                //.AddCustomRepository<Blog, CreateBuilderustomBlogRepository>();

var app = builder.Build();

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

