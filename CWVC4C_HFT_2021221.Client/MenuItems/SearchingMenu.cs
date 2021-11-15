using CWVC4C_HFT_2021221.Models;

namespace CWVC4C_HFT_2021221.Client.MenuItems
{
    public class SearchingMenu
    {
        public void Search(ReadLine Be, WriteLine Ki, Clear clear, RestService rest)
        {

            int resp = -1;


            while (resp != 0)
            {
                Ki?.Invoke("--What would you like to search?--");
                Ki?.Invoke("0.Preivous page");
                Ki?.Invoke("1.Elements");
                Ki?.Invoke("2.Hero");
                Ki?.Invoke("3.Ability");
                Ki?.Invoke("Choose a number:");
                resp = int.Parse(Be?.Invoke());
                clear?.Invoke();
                if (resp == 1)
                {
                    Ki?.Invoke("Which element do you search for? (Type ID)");
                    
                    
                        var elements = rest.GetSingle<Element>("element/" + Be?.Invoke());
                        
                        
                    if (elements!=null)
                    {
                        Ki?.Invoke(elements.ToString());
                    }
                    else
                    {  
                        Ki?.Invoke("There is no such element.");
                    }
                    
                }
                else if (resp == 2)
                {
                    Ki?.Invoke("Which hero do you search for? (Type ID)");
                    
                        var heroes = rest.GetSingle<Hero>("hero/" + Be?.Invoke());
                    if (heroes!=null)
                    {
                        Ki?.Invoke(heroes.ToString());
                    }
                    else
                    {
                        Ki?.Invoke("There is no such hero.");
                    }
                        
                   
                    
                        
                    
                    

                }
                else if (resp == 3)
                {
                    
                    Ki?.Invoke("Which ability do you search for? (Type ID)");
                    var abilites = rest.GetSingle<Ability>("ability/" + Be?.Invoke());
                    if (abilites!=null)
                    {
                        Ki?.Invoke(abilites.ToString());
                    }
                    else
                    {
                        Ki?.Invoke("There is no such ability.");
                    }
                    

                }
                else if (resp == 0)
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


    }
}