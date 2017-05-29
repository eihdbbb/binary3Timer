using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beasts
{
    public class DataSource
    {

        public void GetBeasts(BeastsZoo beasts)
        {

            beasts.AddItem(new Lion("simba"));
            beasts.AddItem(new Foxi("bony"));
            beasts.AddItem(new Wolf("bob"));
            beasts.AddItem(new Elephant("bem"));
            beasts.AddItem(new Bear("michael"));
            beasts.AddItem(new Tiger("too"));

            beasts.AddItem("tom", "tiger",2);
            beasts.AddItem("fe", "foxi", 2);
            beasts.AddItem("El", "Elephant", 2);
            beasts.AddItem("ted", "tiger",1);
            beasts.AddItem("fa", "foxi", 1);
            beasts.AddItem("tar", "TIger", 0);
            beasts.AddItem("Em", "Elephant", 7);
            beasts.AddItem("Bu", "bear", 0);
            beasts.AddItem("Ba", "bear", 2);
            beasts.AddItem("Bi", "bear", 4);
            beasts.AddItem("fu", "foxi", 0);
            beasts.AddItem("fz", "foxi", 3);
            beasts.AddItem("Ed", "Elephant", 0);
            beasts.AddItem("tru", "TIger", 4);
            beasts.AddItem("fi", "foxi", 0);
            return ;
        }

        static public void GroupAllBeastsByType(BeastsZoo beasts)
        {

            var data = beasts.GetAllItems();
            var result = data.GroupBy(x => x.GetType().Name);
            Console.WriteLine("Группировка по типу");
            foreach (var i in result)
            {
                Console.WriteLine(i.Key);
                var result1 = data.Where(x => (i.Key == x.GetType().Name));
                foreach (var j in result1)
                    Console.WriteLine(j);
            }
            Console.WriteLine("=====\n");
            return;
        }

        static public void SelectAllWithStatus(BeastsZoo beasts, string str = "Sick")
        {
            try
            {
                var status = (Status)Enum.Parse(typeof(Status), str, true);
                var data = beasts.GetAllItems();
                Console.WriteLine("показать по состоянию: {0}", status);
                var res2 = data.Where(x => (x.Status == status));
                foreach (var i in res2)
                {
                    Console.WriteLine(i);
                }
               
            }
            catch
            {
                Console.WriteLine("состояние не может быть {0}", str);
            }
            Console.WriteLine("=====\n");

        }


        static public void SelectSickTigers(BeastsZoo beasts)
        {
            Console.WriteLine("показать больных тигров");
            var data = beasts.GetAllItems();
            var res2 = data.Where(x => (x.Status == Status.Sick && String.Compare(x.GetType().Name, "Tiger", true) == 0));
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=====\n");
        }

        static public void SelectElephantNamed(BeastsZoo beasts, string nameE = "bem", string type ="Elephant" )
        {
            Console.WriteLine("показать {1} с кличкой: {0}", nameE, type);
            var data = beasts.GetAllItems();
            var res2 = data.Where(x => ((String.Compare(x.Name, nameE , true) == 0) && String.Compare(x.GetType().Name, type , true) == 0));
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=====\n");
        }

        static public void SelectNamesWhichHungry(BeastsZoo beasts)
        {
            Console.WriteLine("показать список кличек голодных зверей: ");
            var data = beasts.GetAllItems();
            var res3 = data.Where(x => (x.Status == Status.Hungry)).Select(x => x.Name);
            foreach (var i in res3)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=====\n");
        }

        static public void SelectMostHealthyByType(BeastsZoo beasts)
        {
            Console.WriteLine("показать самых здоровых зверей каждого вида (не больше одного): ");
            var data = beasts.GetAllItems();
            var result = data.GroupBy(x => x.GetType().Name);
            foreach (var i in result)
            {
                Console.WriteLine(i.Key);
                var result1 = data.Where(x => (i.Key == x.GetType().Name)).OrderByDescending(x=>x.Health).ThenBy(x=>x.Name).First();
                Console.WriteLine(result1);
            }
            Console.WriteLine("=====\n");
        }


        static public void CountLifelessByType(BeastsZoo beasts)
        {
            Console.WriteLine("показать количество мертвых зверей каждого вида: ");
            var data = beasts.GetAllItems();
            var result = data.GroupBy(x => x.GetType().Name);
            foreach (var i in result)
            {

                var result1 = i.Count(x => (x.Status == Status.Lifeless));
                Console.WriteLine("мертвых зверей вида {0} насчитывается {1} ", i.Key, result1);
            }
            Console.WriteLine("=====\n");
        }

        static public void SelectWolfsBearsHealth(BeastsZoo beasts, int health = 3, string type1="wolf", string type2="bear")
        {
            Console.WriteLine("показать количество {0} и {1} со здоровьем > {2}", type1, type2, health);
            var data = beasts.GetAllItems();
            var res2 = data.Where(x => ((x.Health > health) && ( String.Compare(x.GetType().Name, type1, true) == 0 || 
                        String.Compare(x.GetType().Name, type2, true) == 0) ) ).Select(x => x);
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=====\n");
        }

        static public void SelectBeastsWithMaxMinHelth(BeastsZoo beasts)
        {
            Console.WriteLine("показать ВСЕХ зверей с максимальным и минимальным здоровьем");
            var data = beasts.GetAllItems();
            var res6 = data.OrderByDescending(x => x.Health).
                Where(x => (x.Health == data.OrderByDescending(y => y.Health).First().Health ||
                            x.Health == data.OrderByDescending(z => z.Health).Last().Health)).
                Select(x => x);
            foreach (var i in res6)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=====\n");
        }

        static public void CountAverageHelth(BeastsZoo beasts)
        {
            Console.WriteLine("показать среднее количество  здоровья у всех зверей  в зоопарке");
            var data = beasts.GetAllItems();
            var res7 = data.Average(x => x.Health);
            Console.WriteLine(res7);
            Console.WriteLine("=====\n");
        }

    }
}
