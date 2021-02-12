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
    }
}