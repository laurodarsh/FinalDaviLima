using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetofinalPedroLima.Classes
{
    public class Product
    {
        int id = 0;
        string name = "";
        float price = 0;
        Category category;
        bool active;

        public Product(string name, float price,Category category, bool active)
        {
            this.Name = name;
            this.Price = price;
            this.Active = active;
            this.Category = category;
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

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public Category Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
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
