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
        public readonly int Visit, Comment, Like, Favorite;
        public readonly int ChildrenCount;

        public readonly DateTime CreatedUTC, LastEditedUTC;

        private string Thumbnail;

        internal Project(string Id)
        {
            string response = Http.RequestGet($"https://playentry.org/api/project/favorites/{Id}?&targetSubject=project&targetType=individual");
            JObject json = JObject.Parse(response);
            Favorite = int.Parse(json["total"].ToString());

            response = Http.RequestGet($"https://playentry.org/api/project/{Id}");
            json = JObject.Parse(response);

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
            ChildrenCount = int.Parse(json["childCnt"].ToString());

            UserID = json["user"]["_id"].ToString();
            UserName = json["user"]["username"].ToString();

            Thumbnail = json["thumb"].ToString();

            CreatedUTC = DateTime.Parse(json["created"].ToString());
            LastEditedUTC = DateTime.Parse(json["updated"].ToString());
        }

        public string GetThumbnailURL()
        {
            return $"https://playentry.org/{Thumbnail}";
        }

        public ProjectLikesGroup GetProjectLikesGroup()
        {
            return new ProjectLikesGroup(ProjectId, Like);
        }

        public ProjectFavoritesGroup GetProjectFavoritesGroup()
        {
            return new ProjectFavoritesGroup(ProjectId);
        }

        public ProjectCommentGroup GetProjectCommentsGroup()
        {
            return new ProjectCommentGroup(ProjectId);
        }
    }

    public enum ProjectCategorySet : uint
    {
        Game = 0,
        Animation = 1,
        MediaArt = 2,
        Physical = 3,
        Other = 4
    }
}