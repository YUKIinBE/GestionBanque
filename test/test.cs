
DateTime DateNaiss = new DateTime(2023,5,6);

TimeSpan temp = DateTime.Now - DateNaiss;
    int age = (int)(temp.TotalDays  / 365.25);
Console.WriteLine(age);
