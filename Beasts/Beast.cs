using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beasts
{
    public abstract class Beast
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        private int _health;
        public int Health 
        { 
            get { return _health; }
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    _health = 0;
                    Status = Status.Lifeless;
                }
                else
                {
              
                    if (_health >= MaxHealth)
                    {
                        _health = MaxHealth; 
                        Status = Status.Hungry;
                    }
                    else
                        Status = Status.Sick;
                }

            }
        }

        private int MaxHealth { get; set; }

        public Beast(string name, int max)
        {
            Name = name;
            MaxHealth = max;
            _health = MaxHealth;
            Status = Status.NonHungry;
        }

        public override string ToString()
        { //this.GetType().ToString()
            return string.Format("кличка:{0}, порода {3} - < состояние: {1}, здоровье:{2} >", Name, Status, Health, this.GetType().Name);
        }
    }

    public enum Status
    {
        Lifeless = 0,
        Sick,
        Hungry,
        NonHungry
    }
}
