using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beasts;
using Menu;
using System.Threading;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            TopMenu menu = new TopMenu();
            
            BeastsZoo beasts = new BeastsZoo();
            DataSource dataSource = new DataSource();
            dataSource.GetBeasts( beasts );

            TimerCallback tm = new TimerCallback(BeastsZoo.EmptyZooRandom);
            Timer timer = new Timer(tm, beasts, 5000, 5000);


            beasts.PrintAll();
            do
            {
                
            } while (menu.MakeChoice(beasts) != 0);


            Console.ReadKey();
        }


    }
}
