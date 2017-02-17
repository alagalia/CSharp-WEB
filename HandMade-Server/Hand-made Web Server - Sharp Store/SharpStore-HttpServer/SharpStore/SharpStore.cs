using System;
using SimpleHttpServer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Razor;
using SharpStore.Services;
using SimpleHttpServer;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Utilities;

namespace SharpStore
{
    class SharpStore
    {
        static void Main(string[] args)
        {
            var routes = RoutesConfig.GetRoutes();

            HttpServer server = new HttpServer(8081, routes);
            server.Listen();

            Thread thread = new Thread(new ThreadStart(server.Listen));
            thread.Start();
        }
    }
}