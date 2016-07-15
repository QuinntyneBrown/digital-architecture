using Microsoft.Practices.Unity;
using DigitalArchitecture.Services;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace DigitalArchitecture.Helpers
{
    public static class FrontEndPreCacheHelper
    {
        public static void PreCache()
        {
            var appService = UnityConfiguration.GetContainer().Resolve<IAppService>();
            var app = appService.Get().FirstOrDefault();
            var serializedApp = Newtonsoft.Json.JsonConvert.SerializeObject(app);
            var indexHtmlFileName = System.Web.Hosting.HostingEnvironment.MapPath(".");
            var indexHtml = System.IO.File.ReadAllLines(indexHtmlFileName);
            var newIndexHtml = new List<string>();

            var isBetweenStartAndEndTag = false;
            foreach (var line in indexHtml)
            {
                if (line.Contains("start:preCacheData"))
                {
                    isBetweenStartAndEndTag = true;
                    newIndexHtml.Add(line);
                    newIndexHtml.Add(serializedApp);
                    //1. Delete all content between start and end (Do Until end:preCacheData)
                    //2. Write serialized app data into the html, assigning it to local storage
                }
                else if (line.Contains("end:preCacheData"))
                {
                    isBetweenStartAndEndTag = false;
                    newIndexHtml.Add(line);
                }
                else
                {
                    if (isBetweenStartAndEndTag == false)
                        newIndexHtml.Add(line);
                }
            }

            System.IO.File.WriteAllLines(indexHtmlFileName, newIndexHtml.ToArray());
        }
    }
}
