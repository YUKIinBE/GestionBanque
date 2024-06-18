//Usine<Neko> usine = new();

//var production = usine.Fabriquer();

//Console.WriteLine();

//class Lait
//{

//}

//class Neko
//{

//}

//class UsineLait
//{
//    public List<Lait> Fabriquer()
//    {
//        List<Lait> result = new List<Lait>();
//        Random random = new Random();
//        int qty = random.Next(5, 10);
//        for (int i = 0; i < qty; i++)
//        {
//            result.Add(new Lait());
//        }

//        return result;
//    }
//}

//class UsineChat
//{
//    public List<Neko> Fabriquer()
//    {
//        List<Neko> result = new List<Neko>();
//        Random random = new Random();
//        int qty = random.Next(5, 10);
//        for (int i = 0; i < qty; i++)
//        {
//            result.Add(new Neko());
//        }

//        return result;
//    }
//}

//class Usine<T>
//    where T : class, new()
//{
//    public List<T> Fabriquer()
//    {
//        List<T> result = new List<T>();
//        Random random = new Random();
//        int qty = random.Next(5, 10);
//        for (int i = 0; i < qty; i++)
//        {
//            result.Add(new T());
//        }

//        return result;
//    }
//}



