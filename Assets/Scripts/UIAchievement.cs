using System.Reflection;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIAchievement
    {
        public string title { set; get; }
        public string description { set; get; }

        public Image icon { set; get; }

        public UIAchievement(string title, string description, Image icon)
        {
            this.title = title;
            this.description = description;
            this.icon = icon;
        }
    }
}