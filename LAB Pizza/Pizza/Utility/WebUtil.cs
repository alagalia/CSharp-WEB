using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using Utility.Interfeces;

namespace Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            var environmentVariable = Environment.GetEnvironmentVariable(Constants.RequestMethod);
            return environmentVariable != null && environmentVariable.ToLower() == "post";
        }

        public static bool IsGet()
        {
            var environmentVariable = Environment.GetEnvironmentVariable(Constants.RequestMethod);
            if (environmentVariable == null) return false;
            return environmentVariable.ToLower() == "get";
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string parametersString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Constants.QueryString));
            Logger.Log("GET>variables:-----------  " + parametersString);
            return RetrieveRequestParameters(parametersString);
        }


        public static IDictionary<string, string> RetrievePostParameters()
        {
            string parametersString = WebUtility.UrlDecode(Console.ReadLine());
            Logger.Log("POST>variables:-----------  " + parametersString);
            return RetrieveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrieveRequestParameters(string variables)
        {
            IDictionary<string, string> resultParameters = new Dictionary<string, string>();
            string[] variablesSplited = variables.Split('&');


            foreach (var param in variablesSplited)
            {
                var pair = param.Split('=');
                var name = pair[0];
                string value = null;
                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                resultParameters.Add(name, value);
            }

            return resultParameters;
        }
        public static ICookieCollection GetCookies()
        {
            ICookieCollection cookieCollection = new CookieCollection();
            string cookies = Environment.GetEnvironmentVariable(Constants.CookieGet);
            if (string.IsNullOrEmpty(cookies)) return cookieCollection;
            string[] cookiesPair = cookies.Split(';');
            foreach (string kv in cookiesPair)
            {
                string[] cookiePair = kv.Split('=').Select(x => x.Trim()).ToArray();
                string name = cookiePair[0];
                string value = cookiePair[1];
                Cookie cookie = new Cookie(name, value);
                cookieCollection.AddCookie(cookie);
            }
            return cookieCollection;
        }

        public static Session GetSession()
        {
            ICookieCollection cookies = GetCookies();
            if (!cookies.ContainsKey(Constants.SessionIdKey)) return null;
            Cookie sessionIdCookie = cookies[Constants.SessionIdKey];
            PmContext context = new PmContext();
            Session session = context.Sessions.FirstOrDefault(s => s.Id == sessionIdCookie.Value);
            return session;
        }

        public static void PageNotAllowed()
        {
            PrintFileContent("./game/index.html");
        }

        public static void PrintFileContent(string path)
        {
            string readDataFormFile = File.ReadAllText(path);
            //Logger.Log(readDataFormFile);
            Console.WriteLine(readDataFormFile);
        }


        

       
    }
}