using AutoMapper;
using PizzaForumApp.BindingModels;
using PizzaForumApp.Models;
using PizzaForumApp.ViewModels.topics;
using SimpleHttpServer;
using SimpleMVC;

namespace PizzaForumApp
{
    class AppStart
    {
        static void Main(string[] args)
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaForumApp");
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                //expression.CreateMap<RegisterUserBindingModel, User>();
                //expression.CreateMap<NewCategoryBindingModel, Category>();
                //expression.CreateMap<Topic, TopicVM>();
                expression.CreateMap<ReplyFormBindingModel, Reply>();
                expression.CreateMap<Topic, TopicDetailsTiopicSectionViewModel>();
                expression.CreateMap<Reply, TopicDetailsReplySectionViewModel>();
                //expression.CreateMap<Topic, ProfileTopicVM>();
            });
        }
    }
}
