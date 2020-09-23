using CES.Core.Plugin;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;


namespace UI.CESPlugin_BM
{
    
    public class CESPlugins : IPlugin
    {
        public string Name
        {
            get { return "CESPlugin_BM"; }
        }

        public void Initialize()
        {          
            var routes = RouteTable.Routes.ToList();
            RouteTable.Routes.Clear();
            RouteTable.Routes.MapRoute(
                this.Name,
               "{plugin}/{controller}/{action}/{id}",
                new { controller = "", action = "", id = UrlParameter.Optional, pluginName = this.Name },
                new { plugin = this.Name }
             );
            foreach (var item in routes) RouteTable.Routes.Add(item);
        }



        public void Unload()
        {
            RouteTable.Routes.Remove(RouteTable.Routes[this.Name]);
        }
    }
}