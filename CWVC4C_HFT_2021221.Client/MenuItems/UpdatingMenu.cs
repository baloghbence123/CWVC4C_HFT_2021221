using CWVC4C_HFT_2021221.Models;

namespace CWVC4C_HFT_2021221.Client.MenuItems
{
    public class UpdatingMenu
    {

        public void Update(ReadLine Be, WriteLine Ki, Clear clear, RestService rest)
        {

            int resp = -1;


            while (resp != 0)
            {
                Ki?.Invoke("--What would you like to update?--");
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
                    Ki?.Invoke("");
                    Ki?.Invoke("What is the ID of the Element?");
                    int id = int.Parse(Be?.Invoke());
                    Ki?.Invoke("What should be the name of the Element?");
                    string name = Be?.Invoke();

                    Element element = new Element() { ElementId = id, Name = name };

                    rest.Put<Element>(element, "element");
                }
                else if (resp == 2)
                {
                    var heroes = rest.Get<Hero>("hero");
                    foreach (var item in heroes)
                    {
                        Ki?.Invoke(item.ToString());

                    }
                    Ki?.Invoke("");
                    Ki?.Invoke("");
                    Ki?.Invoke("What is the ID of the Hero?");
                    int id = int.Parse(Be?.Invoke());
                    Ki?.Invoke("What should be the name of the Hero?");
                    string name = Be?.Invoke();
                    Ki?.Invoke("How much power should the Hero have?");
                    int pwr = int.Parse(Be?.Invoke());
                    Ki?.Invoke("How much defense should the Hero have?");
                    int def = int.Parse(Be?.Invoke());
                    Ki?.Invoke("Which Element should be the owner of this Hero?");
                    int elementid = int.Parse(Be?.Invoke());

                    Hero hero = new Hero() { HeroId = id, Name = name, AttackPower = pwr, DefensePower = def, ElementId = elementid };
                    rest.Put<Hero>(hero, "hero");
                }
                else if (resp == 3)
                {
                    var abilites = rest.Get<Ability>("ability");
                    foreach (var item in abilites)
                    {
                        Ki?.Invoke(item.ToString());

                    }
                    Ki?.Invoke("");

                    Ki?.Invoke("What is the ID of the Ability?");
                    int id = int.Parse(Be?.Invoke());
                    Ki?.Invoke("What should be the name of the Ability?");
                    string name = Be?.Invoke();
                    Ki?.Invoke("How much damage should the Ability have");
                    int damage = int.Parse(Be?.Invoke());
                    Ki?.Invoke("How much should the manacost of the Ability?");
                    int mc = int.Parse(Be?.Invoke());
                    Ki?.Invoke("Which Hero should be the owner of this Ability?");
                    int heroid = int.Parse(Be?.Invoke());

                    Ability ability = new Ability() { AbilityId = id, Name = name, DMG = damage, ManaCost = mc, HeroId = heroid };
                    rest.Put<Ability>(ability, "ability");
                }
                else if (resp == 0)
                {
                    //Kiugrik a ciklusból.
                }
                
                if (resp != 0)
                {
                    Ki?.Invoke("");
                }
                
            }


        }
    }
}