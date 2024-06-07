namespace Tools.Models
{
    public static class Tool
    {
        #region Field

        public static string Line = "\n______________________________\n";
        public static string Return = "\n\n";

        #endregion

        #region Methods
        public static void AddLine()
        {
            Console.WriteLine(Line);
        }
        public static void AddReturn()
        {
            Console.WriteLine(Return);
        }
        #endregion
    }
}
