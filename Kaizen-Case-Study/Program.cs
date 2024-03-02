using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Lütfen görmek istediğiniz sorunun numarsını giriniz. (1 / 2 )");
            Console.ForegroundColor = ConsoleColor.Gray;

            string selection = Console.ReadLine();

            if (selection == "1")
                Func1();
            else if (selection == "2")
                Func2();
            else
                Console.Clear();
        }

        //Random class will generate same numbers since calling in Static Main class. 
    }

    #region First Question

    public static void Func1()
    {
        int numberOfPasswords = 10;
        int passwordLength = 8;

        Random random = new Random();
        object syncLock = new object();

        for (int i = 0; i < numberOfPasswords; i++)
        {
                string password = GeneratePassword(passwordLength, random, i);
                Console.WriteLine(password);
        }
    }

    public static string GeneratePassword(int length, Random random, int seed)
    {
        const string validChars = "ACDEFGHKLMNPRTXYZ234579";
        char[] password = new char[length];

        random = new Random(seed);

        for (int i = 0; i < length; i++)
        {
                password[i] = validChars[random.Next(validChars.Length)];
        }

        return new string(password);
    }


    #endregion

    #region Second Question
    public static void Func2()
    {
        string descriptionPart = string.Empty;
        using (StreamReader r = new StreamReader("response.json"))
        {
            string json = r.ReadToEnd();
            List<JsonObject> items = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            descriptionPart = items.FirstOrDefault()?.description;
        }
        Console.WriteLine(descriptionPart);
    }


    #region Json Object

    public class JsonObject
    {
        public string locale { get; set; }
        public string description { get; set; }
        public Boundingpoly boundingPoly { get; set; }
    }

    public class Boundingpoly
    {
        public Vertex[] vertices { get; set; }
    }

    public class Vertex
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    #endregion


    #endregion

}