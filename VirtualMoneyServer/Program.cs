using Microsoft.Extensions.DependencyInjection;
using VirtualPocket.DAL;
using VirtualPocket.DAL.ApiCenter;
using VirtualPocket.DAL.Authentication;
using VirtualPocket.DAL.Collaboration;
using VirtualPocket.DAL.Market;
using VirtualPocket.DAL.PocketPlace;
using VirtualPocket.DAL.Queries;
using VirtualPocket.DAL.Queries.ApiCenter;
using VirtualPocket.DAL.Queries.Authentication;
using VirtualPocket.DAL.Queries.Collaboration;
using VirtualPocket.DAL.Queries.Market;
using VirtualPocket.DAL.Queries.Pocket;
using VirtualPocket.DAL.Queries.Tasks;
using VirtualPocket.DAL.Tasks;
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
            builder.Services.AddKeyedTransient<IQuery, ChildrenLoginQuery>("ChildrenLoginQuery");
            builder.Services.AddKeyedTransient<IQuery, ChildrenGetQuery>("ChildrenGetQuery");
            builder.Services.AddKeyedTransient<IQuery, CollaborateSetQuery>("CollaborateSetQuery");
            builder.Services.AddKeyedTransient<IQuery, ChildrenRegistrationQuery>("ChildrenRegistrationQuery");
            builder.Services.AddKeyedTransient<IQuery, CollaborateRemoveQuery>("CollaborateRemoveQuery");
            //Authentication
            builder.Services.AddKeyedTransient<IConnectionService, ParentLoginProvider>("ParentLoginProvider");
            builder.Services.AddKeyedTransient<IConnectionService, ParentRegistrationProvider>("ParentRegistrationProvider");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenRegistrationProvider>("ChildrenRegistrationProvider");
            builder.Services.AddKeyedTransient<IRegistrationService, ParentRegistrationService>("ParentRegistrationService");
            builder.Services.AddKeyedTransient<IRegistrationService, ChildrenRegistrationService>("ChildrenRegistrationService");
            builder.Services.AddKeyedTransient<ILoginService, ParentLoginService>("ParentAuthenticationService");
            builder.Services.AddKeyedTransient<ILoginService, ChildrenLoginService>("ChildrenAuthenticationService");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenLoginProvider>("ChildrenLoginProvider");
            //Collaborate
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenGetProvider>("ChildrenGetProvider");
            builder.Services.AddKeyedTransient<IConnectionService, CollaborateSetProvider>("CollaborateSetProvider");
            builder.Services.AddKeyedTransient<IConnectionService, CollaborateRemoveProvider>("CollaborateRemoveProvider");
            builder.Services.AddKeyedTransient<ICollaborateSetService, CollaborateSetService>("CollaborateSetService");
            builder.Services.AddKeyedTransient<ICollaborateRemoveService, CollaborateRemoveService>("CollaborateRemoveService");
            builder.Services.AddKeyedTransient<ICollaborateGetService, ChildrenGetService>("CollaborateGetService");
            //Tasks
            builder.Services.AddKeyedTransient<ITaskGetService, ChildrenTaskGetService>("ChildrenTaskGetService");
            builder.Services.AddKeyedTransient<ITaskCategoryService, TaskCategoryGetService>("TaskCategoryGetService");
            builder.Services.AddKeyedTransient<ITaskStatusService, StartTaskStatusService>("StartTaskStatusService");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenTaskGetProvider>("ChildrenTaskGetProvider");
            builder.Services.AddKeyedTransient<ITaskSetService, ChildrenTaskSetService>("ChildrenTaskSetService");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenTaskSetProvider>("ChildrenTaskSetProvider");
            builder.Services.AddKeyedTransient<IConnectionService, StartTaskStatusProvider>("StartTaskStatusProvider");
            builder.Services.AddKeyedTransient<IConnectionService, TaskCategoryGetProvider>("TaskCategoryGetProvider");
            builder.Services.AddTransient<ICartographyService, CartographyService>();
            builder.Services.AddKeyedTransient<IQuery, ChildrenTaskSetQuery>("ChildrenTaskSetQuery");
            builder.Services.AddKeyedTransient<IQuery, ChildrenTaskGetQuery>("ChildrenTaskGetQuery");
            builder.Services.AddKeyedTransient<IQuery, StartTaskStatusQuery>("StartTaskStatusQuery");
            builder.Services.AddKeyedTransient<IQuery, TaskCategoryGetQuery>("TaskCategoryGetQuery");




            //Market
            builder.Services.AddKeyedTransient<IQuery, ChildrenMarketGetQuery>("ChildrenMarketGetQuery");
            builder.Services.AddKeyedTransient<IQuery, ChildrenMarketSetQuery>("ChildrenMarketSetQuery");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenMarketGetProvider>("ChildrenMarketGetProvider");
            builder.Services.AddKeyedTransient<IPurchaseGetService, ChildrenMarketGetService>("ChildrenMarketGetService");
            builder.Services.AddKeyedTransient<IConnectionService, ChildrenMarketSetProvider>("ChildrenMarketSetProvider");
            builder.Services.AddKeyedTransient<IPurchaseSetService, ChildrenMarketSetService>("ChildrenMarketSetService");
            //Pocket
            builder.Services.AddKeyedTransient<IQuery, CollectRewardQuery>("CollectRewardQuery");
            builder.Services.AddKeyedTransient<IConnectionService, CollectRewardProvider>("CollectRewardProvider");
            builder.Services.AddKeyedTransient<ICollectRewardService, CollectRewardService>("CollectRewardService");

            builder.Services.AddKeyedTransient<IQuery, GetPocketQuery>("GetPocketQuery");
            builder.Services.AddKeyedTransient<IConnectionService, GetPocketProvider>("GetPocketProvider");
            builder.Services.AddKeyedTransient<IGetPocketService, GetPocketService>("GetPocketService");

            //ApiCenter
            builder.Services.AddKeyedTransient<IQuery, GetApiCommandsQuery>("GetApiCommandsQuery");
            builder.Services.AddKeyedTransient<IGetApiCommandsService, GetApiCommandsService>("GetApiCommandsService");
            builder.Services.AddKeyedTransient<IConnectionService, GetApiCommandsProvider>("GetApiCommandsProvider");
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
