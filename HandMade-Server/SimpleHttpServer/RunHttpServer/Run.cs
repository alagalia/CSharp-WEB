﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace RunHttpServer
{
    class Run
    {
        static void Main(string[] args)
        {
            var route = new List<Route>()
            {
                new Route()
                {
                    Name = "Hello for the first time",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = (HttpRequest request) => new HttpResponse()
                    {
                        ContentAsUTF8 = File.ReadAllText("../../content/home.html"),
                        StatusCode = ResponseStatusCode.OK
                    }
                }
            };
            HttpServer httpServer = new HttpServer(8081, route);
            httpServer.Listen();
        }
    }
}
