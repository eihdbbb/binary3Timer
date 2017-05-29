using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Beasts
{
    public class BeastsZoo:Beasts
    {
        private static Random rand2 = new Random();
        public BeastsZoo() 
        {
            Items = new List<Beast>();
        }

        public BeastsZoo(IEnumerable<Beast> data)
        {
            Items = (List<Beast>) data;
        }

        public static void EmptyZooRandom(object obj)
        {
            var beasts = (BeastsZoo)obj;
            int j = 0;

            if (beasts.Items.Count > 0)
            {
                j = rand2.Next(beasts.Items.Count);
                beasts.DoBadly(beasts.Items[j].Name);
            }
            else
            {
                Console.WriteLine("Зоопарк уничтожен с таймером. Программа завершена");
                Environment.Exit(0);
            }

        }

        public void PrintAll()
        {
            Console.WriteLine("\n Список животных в зоопарке :");
            foreach (Beast b in Items)
                Console.WriteLine(b.ToString());
            Console.WriteLine("-----------------");
        }

        public IEnumerable<Beast> GetAllItems()
        {
            return Items;
        }

        public override void AddItem(Beast beast)
        { 
            Items.Add(beast);
            Console.WriteLine("Добавили животное: "+ beast.ToString());
        }

        public override void AddItem(string name, string type, int health)
        {
            Beast beast=null;

            if (String.Compare(type, "Lion", true) == 0)
                {                beast = new Lion(name);            }
            if (String.Compare(type, "Foxi", true) == 0)
                {                beast = new Foxi(name);            }
            if (String.Compare(type, "Bear", true) == 0)
                { beast = new Bear(name); }
            if (String.Compare(type, "Tiger", true) == 0)
                { beast = new Tiger(name); }
            if (String.Compare(type, "Elephant", true) == 0)
                { beast = new Elephant(name); }
            if (String.Compare(type, "Wolf", true) == 0)
                { beast = new Wolf(name); }
            if (beast != null)
            {
                beast.Health = health; 
                AddItem(beast);
            }
            else
            {
                Console.WriteLine("не добавили животное <{0}>, ошибка в типе его: <{1}>) ", name, type);
            }
        }

        public override void AddItem(string name, string type)
        {

            AddItem(name, type, Int32.MaxValue);

        }


        public override void RemoveItem(string name)
        {
            foreach (Beast beast in Items)
            {
                if (String.Compare(beast.Name, name, true) == 0 && beast.Status == Status.Lifeless)
                {
                    Items.Remove(beast);
                    Console.WriteLine("Животное {0} удалили из зоопарка ", beast.ToString());
                    return;
                }
                else
                if (String.Compare(beast.Name, name, true) == 0 )
                {
                    Console.WriteLine("Животное {0} живое, не удаляли ", beast.ToString());
                    return;
                }
            }
            Console.WriteLine("Животное по кличке {0} не найдено, ничего не делали ", name);
            return;

        }

        public void DoBadly(string name)
        {

            foreach (Beast b in Items)
            {
                if (String.Compare(b.Name, name, true) != 0)
                    continue;
                if (b.Status == Status.Lifeless)
                {
                    RemoveItem(b.Name); return;
                }
                if (b.Status == Status.Sick)
                {
                    b.Health = b.Health - 1;
                }
                if (b.Status == Status.Hungry)
                {
                    b.Status = Status.Sick; 
                    b.Health--;
                }
                if (b.Status == Status.NonHungry)
                {
                    b.Status = Status.Hungry;
                }
                Console.WriteLine("Состояние зверя {0} ухудшилось", b.ToString());
                return;
            }
            Console.WriteLine("Зверь по кличке {0} не найден, ничего не делали ", name);
        }

        public void DoEat(string name)
        {

            foreach (Beast b in Items)
            {
                if (String.Compare(b.Name, name, true) != 0)
                    continue;
                if (b.Status == Status.Hungry)
                {
                    b.Status = Status.NonHungry;
                    Console.WriteLine("Покормили зверя {0}", b.ToString());
                    return;
                }
                Console.WriteLine("Зверь {0} не хочет/не может есть", b.ToString());
                return;
            }
            Console.WriteLine("Зверь по кличке {0} не найден, ничего не делали ", name);
        }

        public void DoHealth(string name)
        {

            foreach (Beast b in Items)
            {
                if (String.Compare(b.Name, name, true) != 0)
                    continue;
                if (b.Status == Status.Sick)
                {
                    b.Health = b.Health +1;
                    Console.WriteLine("Полечили зверя {0}", b.ToString());
                    return;
                }
                Console.WriteLine("Зверь {0} не нуждается в лечении", b.ToString());
                return;
            }
            Console.WriteLine("Зверь по кличке {0} не найден, ничего не делали ", name);
        }

        public void EmptyZoo()
        {
            Random rand = new Random();
            int j = 0;

            while ( Items.Count > 0 )
            {
                j = rand.Next(Items.Count); 
                DoBadly(Items[j].Name);
                PrintAll();
                Thread.Sleep(5000);
            }
        }



    }
}
