using Microsoft.Extensions.DependencyInjection;
using VirtualPocket.DAL;
using VirtualPocket.DAL.Authentication;
using VirtualPocket.DAL.Collaboration;
using VirtualPocket.DAL.Queries;
using VirtualPocket.Model;
namespace VirtualPocket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           // var service = new ServiceCollection();
            // Add services to the container.

            builder.Services.AddKeyedTransient<IQuery, ParentRegistrationQuery>("ParentRegistrationQuery");
            builder.Services.AddKeyedTransient<IQuery,ChildrenRegistrationQuery>("ChildQuery");
            builder.Services.AddKeyedTransient<IQuery, ParentLoginQuery>("ParentLoginQuery");
            builder.Services.AddKeyedTransient<IQuery, ChildrenGetQuery>("ChildrenGetQUery");
            builder.Services.AddKeyedTransient<IQuery, ChildrenSetQuery>("ChildrenSetQUery");
            //Authentication
            builder.Services.AddKeyedTransient<IConnectionService, ParentLoginProvider>("ParentLoginProvider");
            builder.Services.AddKeyedTransient<IConnectionService, ParentRegistrationProvider>("ParentRegistrationProvider");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenRegistrationProvider>("ChildrenRegistrationProvider");
            builder.Services.AddKeyedTransient<IRegistrationService, ParentRegistrationService>("ParentRegistrationService");
            builder.Services.AddKeyedTransient<ILoginService, ParentLoginService>("ParentAuthenticationService");
            builder.Services.AddKeyedTransient<ILoginService, ChildrenLoginService>("ChildrenAuthenticationService");
            //Collaborate
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenGetProvider>("ChildrenGetProvider");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenSetProvider>("ChildrenSetProvider");

     
            builder.Services.AddTransient<ICartographyService, CartographyService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
