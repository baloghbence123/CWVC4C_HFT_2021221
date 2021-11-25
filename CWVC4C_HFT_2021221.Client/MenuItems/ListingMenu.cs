using CWVC4C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Client.MenuItems
{
    public class ListingMenu
    {
        

        public void List(ReadLine Be, WriteLine Ki, Clear clear, RestService rest)
        {
            

            int resp = -1;
            

            while (resp!=0)
            {
                Ki?.Invoke("--What would you like to list?--");
                Ki?.Invoke("0.Preivous page");
                Ki?.Invoke("1.Elements");
                Ki?.Invoke("2.Hero");
                Ki?.Invoke("3.Ability");
                Ki?.Invoke("Choose a number:");
                try
                {
                    resp = int.Parse(Be?.Invoke());
                }
                catch (System.Exception)
                {
                    resp = -1;

                }

                clear?.Invoke();
                if (resp==1)
                {
                    var elements = rest.Get<Element>("element");
                    foreach (var item in elements)
                    {
                        Ki?.Invoke(item.ToString());
                        
                    }
                }
                else if (resp == 2)
                {
                    var heroes = rest.Get<Hero>("hero");
                    foreach (var item in heroes)
                    {
                        Ki?.Invoke(item.ToString());

                    }
                    
                    
                }
                else if (resp == 3)
                {
                    var abilites = rest.Get<Ability>("ability");
                    foreach (var item in abilites)
                    {
                        Ki?.Invoke(item.ToString());

                    }

                }
                else if(resp ==0)
                {
                  //Kiugrik a ciklusból.
                }
                else
                {
                    Ki?.Invoke("Maybe try it one more time.");
                    
                }
                if (resp!=0)
                {
                    Ki?.Invoke("");
                }
                

            }

        }
        public ListingMenu()
        {
            
        }

    }
}
