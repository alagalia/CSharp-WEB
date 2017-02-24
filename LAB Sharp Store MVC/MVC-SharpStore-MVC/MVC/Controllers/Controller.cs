﻿using System.Runtime.CompilerServices;
using MVC.Interfaces;
using MVC.Interfaces.Generic;
using MVC.ViewEngine;
using MVC.ViewEngine.Generic;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace MVC.Controllers
{
    public class Controller
    {
        protected IActionResult View([CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName = string.Format(
               "{0}.{1}.{2}.{3}",
               MvcContext.Current.AssemblyName,
               MvcContext.Current.ViewsFolder,
               controllerName,
               callee);

            return new ActionResult<T>(fullQualifedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifedName, model);
        }

        public void Redirect(HttpResponse response, string location)
        {
            response.Header.Location = location;
            response.StatusCode = ResponseStatusCode.Found;
        }
    }
}
