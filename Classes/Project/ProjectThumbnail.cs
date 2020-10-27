using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Playentry
{
    public class ProjectThumbnail
    {
        public readonly string ProjectId, ProjectName;
        public readonly string UserID, UserName;
        public readonly int Visit, Comment, Like;

        private string Thumbnail;

        internal ProjectThumbnail(JToken json)
        {
            ProjectId = json["project"]["_id"].ToString();
            ProjectName = json["project"]["name"].ToString();

            Visit = int.Parse(json["project"]["visit"].ToString());
            Like = int.Parse(json["project"]["likeCnt"].ToString());
            Comment = int.Parse(json["project"]["comment"].ToString());

            UserID = json["project"]["user"]["_id"].ToString();
            UserName = json["project"]["user"]["username"].ToString();

            Thumbnail = json["project"]["thumb"].ToString();
        }

        public string GetThumbnailURL()
        {
            return $"https://playentry.org/{Thumbnail}";
        }

        public Project GetProject()
        {
            return new Project(ProjectId);
        }
    }
}