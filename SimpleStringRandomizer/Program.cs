using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleStringRandomizer
{
    class Program
    {
        static List<string> StringList = new List<string>();

        static List<Result> ResultList = new List<Result>();
        static void Main(string[] args)
        {
            
            if(args == null)
            {
                Console.Write("Program in read argument data mode!!\n");
                DataOnArgs();
            }
            else
            {
                Console.Write("Program in read from console data mode!!\n");
                Console.Write("Do you want to maybe load txt file with string or just write new ones?\n Press [Y] if you want that or something else if you dont. Choose wisely...\n");
                WorkWithRead();
            }
                
           
        }

        

        private static void DataOnArgs()
        {
            Console.Write("Not implemented XDDD");
            Console.ReadKey();
        }

        private static void ReadFromArgs()
        {
            throw new NotImplementedException();
        }

        private static void WorkWithRead()
        {
            
            if (ConsoleKey.Y == Console.ReadKey().Key)
                ReadFromFile();
            else
                ReadFromConsole();
            
        }

        private static void ReadFromFile()
        {
            Console.Write("Not implemented XDDD");
            Console.ReadKey();
        }

        private static void ReadFromConsole()
        {
            Console.Write("\nOkay now write some lines of strings what i will randomize\nif you have enough just let empty space and press enter!\n");
            string tmp = "x";
            while (tmp != "")
            {
                tmp = Console.ReadLine();
                if(tmp != null)
                StringList.Add(tmp);
            }
            //Corect list, delete last
            if (StringList.Last() == "" || StringList.Last() == null)
                StringList.Remove(StringList.Last());

            //Preapre Results

            foreach(var i in StringList)
            {
                ResultList.Add(new Result() { S = i, Count = 0 });
            }

            NowWork();
        }

        private static void NowWork()
        {
            
            Console.Write("\n" + ResultList.Count + " strings to randomize!\n\n");
            Console.Write("Okay, how many times youy want to randomize that? Write int value!\n");

            int x = 0;
            while(x <= 0)
            if(int.TryParse(Console.ReadLine(),out  x))
            {
                if(x <= 0)
                    {
                        Console.Write("Dude above 0!!!");
                    }
            }
                else
                    Console.Write(x + "is not a int value!!! Try Again!\n");

            Console.Write("Sooo i will randomize " + x + " times. Want to see logs when randomizing??\nPress [Y] if you want or something else if you don't!! ");


            if (ConsoleKey.Y == Console.ReadKey().Key)
                LetsRandom(true, x);
            else
                LetsRandom(false, x);

           
        }

        private static void LetsRandom(bool v, int x)
        {
            if (v)
                Console.Write("\nThis is when the fun begins...\n");

            Random rnd = new Random();
            
            for (int i =0; i < x; i++)
            {
                
                int y = rnd.Next(ResultList.Count);
                ResultList[y].Count++;

                if(v)
                    Console.Write("Draw: " + ResultList[y].S + "\n");


            }

            Results();
            

        }

        private static void Results()
        {
            Console.Write("\nHere are your results:\n\n");

            foreach (var i in ResultList)
            {
                Console.WriteLine(i.S + " was drawn " + i.Count + " times");
            }

            List<Result> after = CheckThereWasDraw();
            if (after.Count > 1)
            {
                Console.WriteLine("\nHmm seems like there are few draws with same count!\n");





            }
                else
            {

                Console.WriteLine("\n" + after[0].S + " won with " + after[0].Count + " drwas!!\n");


            }

            Console.WriteLine("Want to randnomize again?[Y] for completly new, [S] for same again, [Q] quit...");


            Console.ReadKey();
        }

        private static List<Result> CheckThereWasDraw()
        {
            List<Result> tmp = new List<Result>();

            int highest = 0;
            //znajdz najwieksze
            foreach (var i in ResultList)
            {
                if (i.Count > highest) highest = i.Count;
            }
            //czy sa remisy
            foreach (var i in ResultList)
            {
                if (i.Count == highest) tmp.Add(i);
            }


            return tmp;
        }
    }



    internal class Result
    {
        public string S { get; internal set; }
        public int Count = 0;
    }
}
