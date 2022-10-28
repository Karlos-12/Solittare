using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Solittare
{
    internal class Onlinemodule
    {
        public string username { get; set; }
        public string password { get;  set; }
        public bool logged { get; set; }

        public string img { get; set; }

        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://solitare-56915-default-rtdb.europe-west1.firebasedatabase.app/users/",
            AuthSecret = "zQmSN9g7qKvJBWnI4Gx4QjQBPaSoWdlEKFH0BA8G"
        };
        IFirebaseClient client; 

        public Onlinemodule(string usernam, string passw)
        {
            client = new FirebaseClient(config);
            username = usernam;
            password = passw;

            if(passw == client.Get(usernam + "/pass").ResultAs<string>())
            {
                MessageBox.Show("user logged in sucsefull!");
                logged = true;

                try
                {
                    img = client.Get(usernam + "/img").ResultAs<string>();
                }
                catch
                { }
            }
            else
            {
                MessageBox.Show("There wass an error loging in");
                usernam = "";
                passw = "";
                logged = false;
            }
        }

        public int getwins()
        {
            return (client.Get(username + "/wins").ResultAs<int>());
        }

        public int gettotal()
        {
            return client.Get(username + "/played").ResultAs<int>();
        }

        public int gettime()
        {
            return client.Get(username + "/best_time").ResultAs<int>();
        }

        public void gamewrite(bool won, int time)
        {
            if(won == true)
            {
                client.Set(username + "/wins", client.Get(username + "/wins").ResultAs<int>() + 1); 
                if(time < client.Get(username + "/best_time").ResultAs<int>())
                {
                    client.Set(username + "/best_time", time);
                }
            }

            client.Set(username + "/played", client.Get(username + "/played").ResultAs<int>() + 1);
            client.Set(username + "/winstat", ((client.Get(username + "/wins").ResultAs<int>()) / (client.Get(username + "/played").ResultAs<int>() / 100)));
        
        }

    }
}
