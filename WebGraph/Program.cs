using Microsoft.EntityFrameworkCore;
using WebGraph.Abstraction;
using WebGraph.Data;
using WebGraph.Graph.Mutation;
using WebGraph.Graph.Query;
using WebGraph.Mapper;
using WebGraph.Repository;

namespace WebGraph
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<AppContex>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("db")));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
            builder.Services.AddScoped<IStorageRepository, StorageRepository>();
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddMemoryCache();
            builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();
            app.MapGraphQL();
            app.Run();
        }
    }
}
