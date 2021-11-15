using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Client.MenuItems
{
    public delegate string ReadLine();
    public delegate void WriteLine(string ki);
    public delegate void Clear();

    public class Menu
    {
        public event ReadLine Be;
        public event WriteLine Ki;
        public event Clear Clear;

        public void Start()
        {
            int response=-1;

            RestService rest = new RestService("http://localhost:29868");

            ListingMenu lm = new();
            SearchingMenu sm = new();
            CreatingMenu cm = new();
            UpdatingMenu um = new();
            DeletingMenu dm = new();
            NonCrudMenu nm = new();


            while (response!=0)
            {
                Ki?.Invoke("--Welcome to my menu!--");
                Ki?.Invoke("1. Listing");
                Ki?.Invoke("2. Search");
                Ki?.Invoke("3. Creating");
                Ki?.Invoke("4. Updating");
                Ki?.Invoke("5. Delete");
                Ki?.Invoke("6. Non-CRUD");
                Ki?.Invoke("0. Exit");

                Ki?.Invoke("Choose a number:");
                response = int.Parse(Be?.Invoke());
                if (response==1)
                {
                    Clear?.Invoke();

                    lm.List(Be,Ki,Clear,rest);
                    
                }
                else if (response==2)
                {
                    Clear?.Invoke();


                    sm.Search(Be, Ki, Clear, rest);
                    
                }
                else if (response==3)
                {
                    Clear?.Invoke();
                    cm.Create(Be, Ki, Clear, rest);
                    
                }
                else if (response==4)
                {
                    Clear?.Invoke();
                    um.Update(Be, Ki, Clear, rest);
                }
                else if (response==5)
                {
                    Clear?.Invoke();
                    dm.Delete(Be, Ki, Clear, rest);
                }
                else if (response==6)
                {
                    Clear?.Invoke();
                    nm.NonCrud(Be, Ki, Clear, rest);
                }
                


            }


            

            
        }


    }
}
