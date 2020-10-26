using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playentry
{
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