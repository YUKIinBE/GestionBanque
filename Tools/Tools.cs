namespace Tools.Models
{
    public static class Tool
    {
        #region Field

        public static string Line = "______________________________";
        public static string Return = "\n";

        #endregion

        #region Methods
        public static void AddLine()
        {
            AddReturn();
            Console.WriteLine(Line);
            AddReturn();
        }
        public static void AddReturn()
        {
            Console.WriteLine(Return);
            Console.WriteLine(Return);
        }
        public static void AddTitle(string Title)
        {
            Tool.AddReturn();
            Console.WriteLine(Line);
            Console.WriteLine(Title);
            Console.WriteLine(Line);
            Tool.AddReturn();
            AddReturn();
        }
        #endregion
    }
}
