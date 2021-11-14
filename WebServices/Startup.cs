using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebService1.Entity1_2.Models;
using WebService1.Entity1_2.Repositories;
using WebService1.Entity3.Commands;
using WebService1.Entity3.Mappers;
using WebService1.Entity3.Repositories;
using WebService1.Entity4.Commands;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.Repositories;
using MassTransit.MultiBus;
using WebService1.Entity4.Mappers;
using WebService1.Entity4.Validators;
using WebService1.Entity3.Validators;
using WebService1.Entity4.Consumers;
using FluentValidation;
using WebService1.Entity3.Models;

namespace WebServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMassTransit();

            services.AddMassTransit(cfg =>
            {
                cfg.UsingRabbitMq((context, factory) =>
                {
                    factory.Host("localhost", "/", hostCfg =>
                    {
                        hostCfg.Username("guest");
                        hostCfg.Password("guest");
                    });
                    factory.ReceiveEndpoint("get_Customer", configuration =>
                    configuration.ConfigureConsumer<CustomerConsumer>(context));
                });
                cfg.AddConsumer<CustomerConsumer>();
            });
            services.AddMassTransitHostedService();


            services.AddDbContext<InfoContext>(options =>
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database = InfoContext;Trusted_Connection=True;"));

            services.AddMemoryCache();
            services.AddControllers();

            services.AddSingleton<IValidator<Book>, BookValidator>();
            services.AddSingleton<IValidator<DbCustomer>, CustomerValidator>();
            services.AddSingleton<IValidator<DbPhoneNumber>, PhoneNumberValidator>();


            services.AddTransient<IBookMapper, BookMapper>();
            services.AddScoped<IBookCommand, BookCommand>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddSingleton<IProductRepository<Stationary>, StationaryRepository>();
            services.AddSingleton<IProductRepository<HouseholdGoods>, HouseholdRepository>();

            services.AddTransient<ICustomerCommand, CustomerCommand>();
            services.AddSingleton<ICustomerMapper, CustomerMapper>();
            services.AddTransient<IPhoneNumberCommand, PhoneNumberCommand>();
            services.AddSingleton<IPhoneNumbersMapper, PhoneNumbersMapper>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InfoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.Migrate();

        }
    }
}
