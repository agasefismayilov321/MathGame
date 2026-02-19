namespace MathGame;
using System.Text;

class Program
{

    static List<GameResult> gameResults = new List<GameResult>();
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        int isRunning = 1;
        string oyunNomre;
        while(isRunning == 1)
        {
            Console.Clear();
            ShowMenu();

            oyunNomre = Console.ReadLine()!;
            switch (oyunNomre)
            {
                case "1":
                    OyunOyna("toplama");
                    break;
                case "2":
                    OyunOyna("cixma");
                    break;
                case "3":
                    OyunOyna("vurma");
                    break;
                case "4":
                    OyunOyna("bolme");
                    break;
                case "5":
                    OyunOyna(randomOyun());
                    break;
                case "6":
                    ShowHistory();
                    break;
                case "7":
                    isRunning = 0;
                    break;
                
                default:
                    Console.WriteLine("Uyğun əməliyyat tapılmadı. Zəhmət olmasa düzgün əməliyyat seçin\n");
                    break;
            }


        }
    }

    static void OyunOyna(string emeliyyat)
    {
        Game game = new Game(emeliyyat);
        GameResult MyGames = game.PlayGame();

        gameResults.Add(MyGames);

        Console.WriteLine("Oyun bitdi!");
        Console.WriteLine($"Oyuna serf olunan zaman: {MyGames.timeSpent} saniye");
        Console.WriteLine($"Score: {MyGames.score}/{MyGames.totalQuestion}");
        Console.WriteLine("Menyuya daxil olmaq üçün istənilən şrifte basın...");
        Console.ReadKey();
        
    }

    static void ShowMenu()
    {
        Console.Write(@"
        *****Math Game*****
        1 - Toplama Əməliyyatı
        2 - Çıxma Əməliyyatı
        3 - Vurma Əməliyyatı
        4 - Bölmə Əməliyyatı
        5 - Random Əməliyyat seçmək
        6 - Oyunların Siyahısı
        7 - Oyundan Çıxmaq
        Oynamaq istediyinz emeliyyatı seçin: ");
    }

    static void ShowHistory()
    {

        Console.Clear();
        Console.WriteLine("*****Oyunların Tarixi*****");

        if(gameResults.Count == 0)
        {
            Console.WriteLine("Heleki hec bir oyun oynanilmayib");
        }
        else
        {
            foreach (var item in gameResults)
            {
                Console.WriteLine($"{item.gameTime} - {item.operation} | Score: {item.score}/{item.totalQuestion}");
                Console.WriteLine($"Oyuna serf olunan zaman: {item.timeSpent} saniye\n");
            }
        }

        Console.WriteLine("Menyuya daxil olmaq üçün istənilən şrifte basın...");
        Console.ReadKey();

    }

    static string randomOyun()
    {
        Random randomIndex = new Random();
        string[] oyunlar = ["toplama","cixma","vurma","bolme"];

        return  oyunlar[randomIndex.Next(oyunlar.Length)];
    }
}
