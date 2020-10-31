using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Playentry
{
    public class ProjectFavoritesGroup
    {
        public readonly string ProjectID;
        public readonly int Count;
        public readonly List<ProjectFavorite> List = new List<ProjectFavorite>();

        internal ProjectFavoritesGroup(string _ProjectID)
        {
            string response = Http.RequestGet($"https://playentry.org/api/project/favorites/{_ProjectID}?&targetSubject=project&targetType=individual");
            JObject json = JObject.Parse(response);
            Count = int.Parse(json["total"].ToString());

            response = Http.RequestGet($"https://playentry.org/api/project/favorites/{_ProjectID}?&rows={Count}&targetSubject=project&targetType=individual");
            json = JObject.Parse(response);

            ProjectID = _ProjectID;

            List.Clear();
            for (int i = 0; i < Count; i++)
                List.Add(new ProjectFavorite(ProjectID, json["favorites"][i]));
        }
    }

    public class ProjectFavorite
    {
        public readonly string FavoriteID;
        public readonly string UserID, UserName;
        public readonly string ProjectID;

        public readonly DateTime Created;

        internal ProjectFavorite(string _ProjectID, JToken json)
        {
            ProjectID = _ProjectID;
            FavoriteID = json["_id"].ToString();

            UserName = json["user"]["username"].ToString();
            UserID = json["user"]["_id"].ToString();

            Created = DateTime.Parse(json["created"].ToString());
        }
    }
}