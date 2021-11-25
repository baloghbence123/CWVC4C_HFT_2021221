using CWVC4C_HFT_2021221.Models;

namespace CWVC4C_HFT_2021221.Client.MenuItems
{
    public class CreatingMenu
    {


        public void Create(ReadLine Be, WriteLine Ki, Clear clear, RestService rest)
        {

            int resp = -1;


            while (resp != 0)
            {
                Ki?.Invoke("--What would you like to create?--");
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
                    Ki?.Invoke("Create your Element.");
                    Ki?.Invoke("Name it somehow.");
                    string name = Be?.Invoke();
                    Element element = new Element() { Name = name };

                    rest.Post<Element>(element, "element");
                    Ki?.Invoke("Your element is ready.");



                }
                else if (resp == 2)
                {
                    Ki?.Invoke("Create your Hero.");
                    Ki?.Invoke("Name it somehow.");
                    string name = Be?.Invoke();
                    Ki?.Invoke("Customize it's power.");
                    int pwr = int.Parse(Be?.Invoke());
                    Ki?.Invoke("Customize it's defense.");
                    int def = int.Parse(Be?.Invoke());
                    Ki?.Invoke("Add an element id:");
                    int elementid = int.Parse(Be?.Invoke());

                    Hero hero = new Hero() { Name = name, AttackPower = pwr, DefensePower = def ,ElementId=elementid};
                    rest.Post<Hero>(hero, "hero");

                    Ki?.Invoke("Your hero is ready.");

                }
                else if (resp == 3)
                {

                    Ki?.Invoke("Create your Ability");
                    Ki?.Invoke("Name it somehow");
                    string name = Be?.Invoke();
                    Ki?.Invoke("Customize it's damage.");
                    int dmg = int.Parse(Be?.Invoke());
                    Ki?.Invoke("Customize it's manacost.");
                    int mana = int.Parse(Be?.Invoke());
                    Ki?.Invoke("Add a hero id:");
                    int heroid = int.Parse(Be?.Invoke());

                    Ability ability = new Ability() { Name = name, DMG = dmg, ManaCost = mana,HeroId=heroid };
                    rest.Post<Ability>(ability, "ability");

                    Ki?.Invoke("Your ability is ready.");

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