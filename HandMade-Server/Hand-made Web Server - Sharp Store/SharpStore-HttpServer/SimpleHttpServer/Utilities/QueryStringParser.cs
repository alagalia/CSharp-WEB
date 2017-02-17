using System.Collections.Generic;
using System.Net;

namespace SimpleHttpServer.Utilities
{
    public class QueryStringParser
    {
        public static IDictionary<string, string> Parse(string queryString)
        {
            queryString = WebUtility.UrlDecode(queryString);
            IDictionary<string,string> parsedQuery = new Dictionary<string, string>();
            string[] vars = queryString.Split('&');
            foreach (var variable in vars)
            {
                string[] tokens = variable.Split('=');
                parsedQuery.Add(tokens[0], tokens[1]);
            }
            return parsedQuery;
        }
    }
}