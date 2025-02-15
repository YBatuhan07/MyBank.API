using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBank.Repository;
using MyBank.Repository.Accounts;
using MyBank.Repository.Customers;
using MyBank.Repository.Interceptors;
using MyBank.Services;
using MyBank.Services.Accounts;
using MyBank.Services.Accounts.Create;
using MyBank.Services.Customers;
using MyBank.Services.ExceptionHandler;
using MyBank.Services.Mapping;

namespace MyBank.App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<FluentValidationFilter>();
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        });

        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssembly(typeof(CreateAccountRequestValidator).Assembly);

        builder.Services.AddExceptionHandler<CriticalExceptionHandler>();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MyBankDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
            options.AddInterceptors(new AuditDbContextInterceptor());
        });

        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<AccountService>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();

        var app = builder.Build();

        app.UseExceptionHandler(x => { });

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
    }
}