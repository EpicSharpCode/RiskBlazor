using Microsoft.AspNetCore.Components;

namespace NorthstarBlazor.Client
{
    public static class Extensions
    {
        public static string GetClassAnalogName(this object obj) { return obj.ToString().GetClassAnalogName(); }
        public static string GetClassAnalogName(this string str)
        {
            if (str == null) return "";
            if (str.Length > 1)
            {
                if (str.StartsWith('+')) return "achieve";
                if (str.StartsWith('-')) return "waste";
            }
            return "";
        }
        public static void ReloadPage(this NavigationManager manager)
        {
            manager.NavigateTo(manager.Uri, true);
        }
    }
}
