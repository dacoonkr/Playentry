using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Playentry
{
    class Http
    {
        public static string RequestGet(string url)
        {
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }
            return responseText;
        }
    }

    public class PlayentryClient
    {
        const string Domain = "https://playentry.org";

        public static List<ProjectThumbnail> getStaffPicks(int limit = 3)
        {
            string response = Http.RequestGet(Domain + $"/api/rankProject?type=staff&limit={limit}");

            List<ProjectThumbnail> staffPicks = new List<ProjectThumbnail>();

            JObject json = JObject.Parse($"{{\"value\":{response}}}");
            for (int i = 0; i < limit; i++)
                staffPicks.Add(new ProjectThumbnail(json["value"][i]));

            return staffPicks;
        }

        public static List<ProjectThumbnail> getBestProjects(int limit = 9)
        {
            string response = Http.RequestGet(Domain + $"/api/rankProject?type=best&limit={limit}");

            List<ProjectThumbnail> bestProjects = new List<ProjectThumbnail>();

            JObject json = JObject.Parse($"{{\"value\":{response}}}");
            for (int i = 0; i < limit; i++)
                bestProjects.Add(new ProjectThumbnail(json["value"][i]));

            return bestProjects;
        }
    }
}