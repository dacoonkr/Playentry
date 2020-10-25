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

        public static List<ProjectThumnail> getStaffPicks()
        {
            string response = Http.RequestGet(Domain + "/api/rankProject?type=staff&limit=3");

            List<ProjectThumnail> staffPicks = new List<ProjectThumnail>();

            JObject json = JObject.Parse($"{{\"value\":{response}}}");

            staffPicks.Add(new ProjectThumnail(json["value"][0]));
            staffPicks.Add(new ProjectThumnail(json["value"][1]));
            staffPicks.Add(new ProjectThumnail(json["value"][2]));

            return staffPicks;
        }
    }

    public class ProjectThumnail
    {
        public string ProjectId, ProjectName;

        public int Visit, Comment, Like;

        public string UserID, UserName;
        public string ThumbnailUrl;

        internal ProjectThumnail(JToken json)
        {
            ProjectId = json["project"]["_id"].ToString();
            ProjectName = json["project"]["name"].ToString();

            Visit = int.Parse(json["project"]["visit"].ToString());
            Like = int.Parse(json["project"]["likeCnt"].ToString());
            Comment = int.Parse(json["project"]["comment"].ToString());

            UserID = json["project"]["user"]["_id"].ToString();
            UserName = json["project"]["user"]["username"].ToString();

            ThumbnailUrl = $"https://playentry.org{json["project"]["thumb"]}";
        }
    }
}