using SimpleMVC.App.MVC.Attributes.Methods;

namespace SimpleMVC.App.MVC.Attributies.Methods
{
    public class HttpPostAttribute :HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod == "POST")
            {
                return true;
            }
            return false;
        }
    }
}