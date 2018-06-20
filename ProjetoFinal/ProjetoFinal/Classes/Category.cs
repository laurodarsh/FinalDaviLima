using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Classes
{
    class Category
    {
        private int id;
        private string name;
        private bool active;


        public Category()
        {

        }

        public Category(string name, bool active)
        {
            this.name = name;
            this.active = active;
        }

        public Category(int id, string name, bool active)
        {
            this.id = id;
            this.name = name;
            this.active = active;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }
    }
}
