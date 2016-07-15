using Microsoft.Practices.Unity;
using DigitalArchitecture.Services;
using System.Linq;
using System.Collections.Generic;
using static System.IO.File;
using static DigitalArchitecture.UnityConfiguration;
using static System.Web.Hosting.HostingEnvironment;
using static Newtonsoft.Json.JsonConvert;


namespace DigitalArchitecture.Helpers
{
    public static class FrontEndPreCacheHelper
    {
        public static void PreCache()
        {
            var appService = GetContainer().Resolve<IAppService>();
            var app = appService.Get().FirstOrDefault();
            var serializedApp = SerializeObject(app);
            var indexHtmlFileName = MapPath(".");
            var indexHtml = ReadAllLines(indexHtmlFileName);
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

            WriteAllLines(indexHtmlFileName, newIndexHtml.ToArray());
        }
    }
}
