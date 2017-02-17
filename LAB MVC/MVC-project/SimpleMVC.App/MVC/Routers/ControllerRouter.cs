using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using SimpleHttpServer.Models;
using SimpleMVC.App.MVC.Attributies.Methods;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.Routers
{
    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private string[] methodParams;

        private string[] controllerActionParams;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        public HttpResponse Handle(HttpRequest request)
        {
            this.ParseRequest(request);
        }

        private void ParseRequest(HttpRequest request)
        {
            //retrive info for controller
            string uri = WebUtility.UrlDecode(request.Url);
            int indexOfparamsInUrlGET = uri.IndexOf('?');

            //get GET params
            if (indexOfparamsInUrlGET != -1)
            {
                this.controllerActionParams =
                    uri.Split('?')[0]
                    .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                string[] variables = uri.Substring(indexOfparamsInUrlGET + 1).Split('&');
                foreach (string variable in variables)
                {
                    if (variable.Contains("="))
                    {
                        string[] kvVariables = variable.Split('=');
                        string key = kvVariables[0];
                        string value = kvVariables[1];
                        getParams[key] = value;
                    }
                }
            }

            //get POST params
            string variableFormPOST = request.Content;
            if (!string.IsNullOrEmpty(variableFormPOST))
            {
                variableFormPOST = WebUtility.UrlDecode(variableFormPOST);
                string[] variables = variableFormPOST.Split('&');
                foreach (string variable in variables)
                {
                    string[] kvVariables = variable.Split('=');
                    string key = kvVariables[0];
                    string value = kvVariables[1];
                    postParams[key] = value;
                }
            }

            //retreive the request method
            this.requestMethod = request.Method.ToString();

            //retreive the controller name
            this.controllerName = ToUpperFirst(this.controllerActionParams[this.controllerActionParams.Length - 2]) + MvcContext.Current.ControllersSuffix;

            //retreive the action name
            this.actionName = ToUpperFirst(this.controllerActionParams[this.controllerActionParams.Length - 1]);

            //Retrieve Method
            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                throw new Exception("'Nos such method");
            }

        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;
            foreach (MethodInfo methodInfo in this.GetSuitableMethod())
            {
                IEnumerable<Attribute> attributes = methodInfo.GetCustomAttributes()
                    .Where(m => m is HttpMethodAttribute);
                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }
            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethod()
        {
            return this.GetControler().GetType().GetMethods().Where(m => m.Name == this.actionName);
        }

        private Controller GetControler()
        {
            var controllerType =
                $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ControllersFolder}.{this.controllerName}";
            var controller = (Controller)Activator.CreateInstance(Type.GetType(controllerType));
            return controller;
        }

        private string ToUpperFirst(string str)
        {
            return str[0].ToString().ToUpper() + str.Substring(1);
        }
    }
}