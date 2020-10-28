using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Playentry
{
    public class ProjectLikesGroup
    {
        public readonly string ProjectID;
        public readonly int Count;
        public readonly List<ProjectLike> List = new List<ProjectLike>();

        internal ProjectLikesGroup(string _ProjectID, int _LikeCnt)
        {
            string response = Http.RequestGet($"https://playentry.org/api/project/likes/{_ProjectID}?&rows={_LikeCnt}&targetSubject=project&targetType=individual");

            JObject json = JObject.Parse($"{{\"value\":{response}}}");

            Count = _LikeCnt;
            ProjectID = _ProjectID;

            List.Clear();
            for (int i = 0; i < _LikeCnt; i++)
                List.Add(new ProjectLike(ProjectID,
                                         json["value"][i]["user"]["username"].ToString(),
                                         json["value"][i]["user"]["_id"].ToString(),
                                         json["value"][i]["_id"].ToString()));
        }
    }

    public class ProjectLike
    {
        public readonly string LikeID;
        public readonly string UserID, UserName;
        public readonly string ProjectID;

        internal ProjectLike(string _ProjectID, string _UserName, string _UserID, string _LikeID)
        {
            ProjectID = _ProjectID;
            UserName = _UserName;
            UserID = _UserID;
            LikeID = _LikeID;
        }
    }
}