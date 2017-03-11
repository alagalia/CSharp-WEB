using SimpleHttpServer;
using SimpleMVC;

namespace ExamApp
{
    class AppStart
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "ExamApp");
        }
    }
}
