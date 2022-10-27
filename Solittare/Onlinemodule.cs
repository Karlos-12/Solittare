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

    }
}
