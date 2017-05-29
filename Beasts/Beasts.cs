using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beasts
{
    public abstract class Beasts
    {
        protected List<Beast> Items = null;

        public abstract void AddItem(Beast beast);
        public abstract void AddItem(string name, string type);
        public abstract void AddItem(string name, string type, int health);
        public abstract void RemoveItem(string name);
    }
}
