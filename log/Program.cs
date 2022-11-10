

using Serilog;

namespace changer
{
    class Program
    {
        static void Main(string[] args)
        {
            var com =0.0;
            var money = 0.0;
            var curs = 60;
            Console.WriteLine("Курс: " + curs);

            Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Information()
                   .Enrich.WithProperty("Курс доллара:", curs)
                     .WriteTo.Seq("http://localhost:5341/", apiKey: "kxHtPHc6onrtfNjJDq8D")
                     .CreateLogger();


            Console.WriteLine("Введите деньги которые нужно перевести в доллары ");
            money = Convert.ToDouble(Console.ReadLine());

            if (money < 1)
           {
           Log.Error("Введено некорректное значение");
            }

         if (money <= 500)
            {
                money -= 8;
            }
            else
            {

                com= money;
                com *= 0.37;
                money -= com;
                Console.WriteLine(money);
            }



            money *= curs;

            Log.Information($"Вы получите:{money}");
            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}