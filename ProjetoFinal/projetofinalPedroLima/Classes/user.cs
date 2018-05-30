using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetofinalPedroLima.Classes
{
    public class User
    {
        private int id;
        private string name;
        private string password;
        private string email;
        private UserProfile userprofile;
        private bool active;

        public User(string name, string password, string email, UserProfile userprofile, bool active)
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;
            this.Userprofile = userprofile;
            this.Active = active;
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

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public UserProfile Userprofile
        {
            get
            {
                return userprofile;
            }

            set
            {
                userprofile = value;
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
