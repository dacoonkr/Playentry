using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Playentry
{
    public class User
    {
        public readonly string UserID;
        public readonly string Username;
        public readonly string Description;

        public readonly bool IsBlocked;
        public readonly bool IsEmailAuthed;

        public string GetAvatarURL()
        {
            return $"https://playentry.org/uploads/profile/{UserID.Substring(0, 2)}/{UserID.Substring(2, 2)}/avatar_{UserID}.png";
        }

        internal User(string Username)
        {
            string response = Http.RequestGet($"https://playentry.org/api/getUserByUsername/{Username}");
            if (response == "null")
            {
                UserID = null;
                return;
            }

            JObject json = JObject.Parse(response);

            UserID = json["_id"].ToString();
            this.Username = Username;
            Description = json["description"].ToString();

            IsBlocked = json["isBlocked"].ToString() == "true";
            IsEmailAuthed = json["isEmailAuth"].ToString() == "true";
        }

        public List<ProjectThumbnail> GetAllProjects()
        {
            List<ProjectThumbnail> projects = new List<ProjectThumbnail>();

            string response = Http.RequestGet($"https://playentry.org/api/project/find?option=list&sort=updated&user={UserID}");

            JObject json = JObject.Parse(response);
            int count = int.Parse(json["count"].ToString());

            for (int i = 0; i < count; i++)
                projects.Add(new ProjectThumbnail(json["data"][i]));

            return projects;
        }
    }
}