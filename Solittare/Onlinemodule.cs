using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Firebase.Storage;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Firebase.Auth;
using System.Net.Sockets;
using System.Threading;

namespace Solittare
{
    internal class Onlinemodule
    {
        public string username { get; set; }
        public string password { get;  set; }
        public bool logged { get; set; }

        public string img { get; set; }

        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
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
            try 
            { 
                client.Set(username + "/winstat", ((client.Get(username + "/wins").ResultAs<int>()) / (client.Get(username + "/played").ResultAs<int>() / 100)));
            }
            catch
            { }      
        }

        public void reset()
        {
            client.Set(username + "/wins", 0);
            client.Set(username + "/played", 0);
            client.Set(username + "/winstat", 0);
            client.Set(username + "/best_time", 1000);
        }

        public async void newacount(string name, string passw, string imuges = @"D:\testfolder\1200px-Penrose-dreieck.svg.png")
        {
            FileStream stream = null;
            try
            {
                stream = File.Open(imuges, FileMode.Open);
            }
            catch
            {
                MessageBox.Show("The file is unaccesable");
            }

            var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyCETk5LvYzOqb2yfVmTsq3K6O2cHOnSeYE"));
            var a = await auth.SignInWithEmailAndPasswordAsync("admi@more.com", "123456");

            string pic = "";
            
                var task = new FirebaseStorage(
                    "solitare-56915.appspot.com",
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child(name + ".png")
                    .PutAsync(stream);

                pic = await task;
            

            client.Set(name + "/name", name);
            client.Set(name + "/pass", passw);

            client.Set(name + "/img", pic);

            client.Set(name + "/best_time", 1000);
            client.Set(name + "/played", 0);
            client.Set(name + "/wins", 0);
            client.Set(name + "/winstat", 100);
        }

        // save na cloudu budou chlapče
    }
}
