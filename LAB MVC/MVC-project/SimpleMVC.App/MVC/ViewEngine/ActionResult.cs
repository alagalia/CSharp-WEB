using System;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.ViewEngine
{
    public class ActionResult: IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable) Activator.CreateInstance(Type.GetType(viewFullQualifedName));
        }
        public string Invoke()
        {
            return this.Action.Render();
        }

        public IRenderable Action { get; set; }

        public string Location { get; }
    }
}