using System;
using System.Collections.Generic;

namespace Backend.Business.Dashboard.Models
{
    public class BasicUserInfoComparer : IEqualityComparer<BasicUserInfo>
    {
        public bool Equals(BasicUserInfo x, BasicUserInfo y)
        {
            return x.UserId == y.UserId;
        }

        public int GetHashCode(BasicUserInfo obj)
        {
            return obj.UserId.GetHashCode();
        }
    }

    public class UserActivitiesContainer : BasicUserInfo
    {
        public UserActivitiesContainer(BasicUserInfo user, int unseenActivities, IEnumerable<BasicActivityInfo> activities) : base(user.UserId, user.UserName, user.UserAvatar)
        {
            Activities = activities;
            UnseenActivities = unseenActivities;
        }

        public int UnseenActivities { get; set; }
        public IEnumerable<BasicActivityInfo> Activities { get; set; }
    }

    public class BasicActivityInfo
    {
        public BasicActivityInfo()
        {
        }

        public BasicActivityInfo(Guid id, ActivityType type, DateTime date, string message, string jsonEntity, bool seen)
        {
            Id = id;
            Type = type;
            Date = date;
            Message = message;
            JsonEntity = jsonEntity;
            Seen = seen;
        }

        public Guid Id { get; set; }
        public bool Seen { get; set; }
        public ActivityType Type { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; } // some kind of payload.. depending on type.. can be null
        public string JsonEntity { get; set; }
    }

    public class BasicUserInfo
    {
        public BasicUserInfo()
        {
        }

        public BasicUserInfo(Guid userId, string username, string avatar)
        {
            UserId = userId;
            UserName = username;
            UserAvatar = avatar;
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; } // read this as Name not Username
        public string UserAvatar { get; set; }
    }

    public class Activity
    {
        public Activity(BasicUserInfo userInfo, BasicActivityInfo activityInfo)
        {
            UserInfo = userInfo;
            ActivityInfo = activityInfo;
        }

        public BasicUserInfo UserInfo { get; set; }
        public BasicActivityInfo ActivityInfo { get; set; }
    }

    public enum ActivityType
    {
        Training,
        MediaFile,
        Bodyweight,
        PersonalBest
    }
}