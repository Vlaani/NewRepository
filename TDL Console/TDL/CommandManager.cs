namespace TDL
{
    internal static class CommandManager
    {
        public static string MakeCommand(string text)
        {
           return text.IndexOf(' ') > 0 ? text.Remove(text.IndexOf(' ')) : text;
        }
        public static string DeleteCommand(string text)
        {
            return text.IndexOf(' ') > 0 ? text.Remove(0, text.IndexOf(' ') + 1) : "";
        }
    }
}