using System.Collections.Generic;
using System.IO;
using System.Linq;
using Razor;
using SharpStore.Data.Models;
using SharpStore.Services;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace SharpStore
{
    public static class RoutesConfig
    {
        public static IList<Route> GetRoutes()
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/home.*$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = new HomePage().ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "Contacts",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/contacts.*$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = new ContactPage().ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "About us",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/about.*$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = new AboutPage().ToString()
                        };
                    }
                },

                new Route()
                {
                    Name = "Products",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/products.*$",
                    Callable = (request) =>
                    {
                        int startIndexOfVars = request.Url.IndexOf('?');
                        IList<Knife> products = Data.Data.Context.Knives.ToList();

                        if (startIndexOfVars != -1)
                        {
                            string vars = request.Url.Substring(startIndexOfVars);
                            string knifeName = vars.Split('=')[1].ToLower();
                            products = products.Where(k => k.Name.ToLower().Contains(knifeName)).ToList();
                        }
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = new ProductsPage(products).ToString()
                        };
                    }
                },

                new Route()
                {
                    Name = "Contact POST",
                    Method = RequestMethod.POST,
                    UrlRegex = "^/contacts.*$",
                    Callable = (request) =>
                    {
                        var query = request.Content;
                        IDictionary<string, string> variablesFormQuery = QueryStringParser.Parse(query);
                        MessageService service = new MessageService();
                        service.AddMessageFromContactForm(variablesFormQuery);
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = new ContactPage().ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/content/css/carousel.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Pngs",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/images/.+\.png",
                    Callable = (request) =>
                        {
                            var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/')+1);
                            var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/images/{nameOfFile}")
                        };
                            response.Header.ContentType = "image/jpeg";
                            //response.Header.ContentLength = response.Content.Length.ToString();
                            return response;

                        }
                },
                new Route()
                {
                    Name = "Jpgs",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/images/.+\.jpg",
                    Callable = (request) =>
                        {
                            var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/')+1);
                            var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/images/{nameOfFile}")
                        };
                            response.Header.ContentType = "image/jpeg";
                            //response.Header.ContentLength = response.Content.Length.ToString();
                            return response;

                        }
                },
                 new Route()
                {
                    Name = "Bootstrap.min.css",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/css/bootstrap.min.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
            };
            return routes;
        }
    }
}