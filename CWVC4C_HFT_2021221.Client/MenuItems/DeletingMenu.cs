using CWVC4C_HFT_2021221.Models;

namespace CWVC4C_HFT_2021221.Client.MenuItems
{
    public class DeletingMenu
    {

        public void Delete(ReadLine Be, WriteLine Ki, Clear clear, RestService rest)
        {
            int resp = -1;


            while (resp != 0)
            {
                Ki?.Invoke("--What would you like to delte?--");
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
                if (resp == 1)
                {
                    var elements = rest.Get<Element>("element");
                    foreach (var item in elements)
                    {
                        Ki?.Invoke(item.ToString());

                    }
                    Ki?.Invoke("Which element do you want to delete? (Type ID)");

                    int id = int.Parse(Be?.Invoke());
                    rest.Delete(id,"element");
                    clear?.Invoke();


                }
                else if (resp == 2)
                {
                    var heroes = rest.Get<Hero>("hero");
                    foreach (var item in heroes)
                    {
                        Ki?.Invoke(item.ToString());

                    }

                    Ki?.Invoke("Which hero do you want to delete? (Type ID)");

                    int id = int.Parse(Be?.Invoke());
                    rest.Delete(id, "hero");
                    clear?.Invoke();

                }
                else if (resp == 3)
                {
                    var abilites = rest.Get<Ability>("ability");
                    foreach (var item in abilites)
                    {
                        Ki?.Invoke(item.ToString());

                    }
                    Ki?.Invoke("Which ability do you want to delete? (Type ID)");

                    int id = int.Parse(Be?.Invoke());
                    rest.Delete(id, "ability");
                    clear?.Invoke();

                }
                else if (resp == 0)
                {
                    //Kiugrik a ciklusból.
                }
                else
                {
                    Ki?.Invoke("Maybe try it one more time.");
                    
                }
                if (resp != 0)
                {
                    Ki?.Invoke("");
                }
                

            }
        }

    }
}