using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Playentry
{
    public class ProjectCommentGroup
    {
        public readonly string ProjectID;
        public readonly int Count;
        public readonly List<ProjectComment> List = new List<ProjectComment>();

        internal ProjectCommentGroup(string _ProjectID)
        {
            string response = Http.RequestGet($"https://playentry.org/api/comment/project/count/{_ProjectID}?targetType=individual");
            Count = int.Parse(response);

            for (int i = 1; (i - 1) * 5 < Count; i++)
            {
                response = Http.RequestGet($"https://playentry.org/api/comment/project/list/{_ProjectID}/{i}?targetType=individual");
                List<JToken> json = JArray.Parse(response).ToList();

                foreach (var j in json) List.Add(new ProjectComment(j));
            }

            ProjectID = _ProjectID;
        }
    }

    public class ProjectComment
    {
        public readonly string CommentID;
        public readonly string UserID, UserName;
        public readonly string ProjectID;

        public readonly string Content;
        public readonly DateTime CreatedUTC;

        internal ProjectComment(JToken json)
        {
            CommentID = json["_id"].ToString();

            UserID = json["user"]["_id"].ToString();
            UserName = json["user"]["username"].ToString();

            ProjectID = json["target"].ToString();

            Content = json["content"].ToString();

            CreatedUTC = DateTime.Parse(json["created"].ToString());
        }
    }
}