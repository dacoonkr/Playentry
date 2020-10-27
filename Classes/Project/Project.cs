using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Playentry
{
    public class Project
    {
        public ProjectCategorySet ProjectCategory;

        public readonly string ProjectId, ProjectName, ProjectDescription;
        public readonly string UserID, UserName;
        public readonly int Visit, Comment, Like;
        public readonly int ChildCnt;

        private string Thumbnail;

        internal Project(string Id)
        {
            string response = Http.RequestGet($"https://playentry.org/api/project/{Id}");

            JObject json = JObject.Parse(response);

            ProjectId = json["_id"].ToString();
            ProjectName = json["name"].ToString();
            ProjectDescription = json["description"].ToString();
            ProjectCategory = new Dictionary<string, ProjectCategorySet>
            {
                ["게임"] = ProjectCategorySet.Game,
                ["애니메이션"] = ProjectCategorySet.Animation,
                ["미디어 아트"] = ProjectCategorySet.MediaArt,
                ["피지컬"] = ProjectCategorySet.Physical,
                ["기타"] = ProjectCategorySet.Other
            }[json["category"].ToString()];

            Visit = int.Parse(json["visit"].ToString());
            Like = int.Parse(json["likeCnt"].ToString());
            Comment = int.Parse(json["comment"].ToString());
            ChildCnt = int.Parse(json["childCnt"].ToString());

            UserID = json["user"]["_id"].ToString();
            UserName = json["user"]["username"].ToString();

            Thumbnail = json["thumb"].ToString();

        }

        public string GetThumbnailURL()
        {
            return $"https://playentry.org/{Thumbnail}";
        }
    }

    public enum ProjectCategorySet : int
    {
        Game = 0,
        Animation = 1,
        MediaArt = 2,
        Physical = 3,
        Other = 4
    }
}