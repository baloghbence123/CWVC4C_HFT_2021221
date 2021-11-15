using System;
using System.Collections;
using System.Collections.Generic;

namespace CWVC4C_HFT_2021221.Client.MenuItems
{
    public class NonCrudMenu
    {

        public void NonCrud(ReadLine Be, WriteLine Ki, Clear clear, RestService rest)
        {
            int response = -1;

            while (response!=0)
            {
                Ki?.Invoke("What Non-CRUD method do you want to run?");
                Ki?.Invoke("0. Previous page");
                Ki?.Invoke("1.The strongest ability with its element");
                Ki?.Invoke("2.Average damage of the heroes by their abilities");
                Ki?.Invoke("3.Average manacost of the heroes by their abilities");
                Ki?.Invoke("4.Average damage of the abilites");
                Ki?.Invoke("5.Average hero defensive point");
                Ki?.Invoke("6.Average hero power point");
                Ki?.Invoke("7.Average hero defensive point by element");
                Ki?.Invoke("8.Average hero power point by element");

                response=int.Parse(Be?.Invoke());
                clear?.Invoke();
                if (response==1)
                {
                    var col=rest.Get<KeyValuePair<string,double>>("stat/thestrongestelementbyability");
                    foreach (var item in col)
                    {
                        Ki?.Invoke(item.ToString());
                    }
                }
                else if(response==2)
                {
                    var col = rest.Get<KeyValuePair<string,double>>("stat/avgdmgbyhsa");
                    foreach (var item in col)
                    {
                        Ki?.Invoke(item.ToString());
                    }
                }
                else if (response == 3)
                {
                    var col = rest.Get<KeyValuePair<string, double>>("stat/avgmanabyhsa");
                    foreach (var item in col)
                    {
                        Ki?.Invoke(item.ToString());
                    }
                }
                else if (response == 4)
                {
                    var col = Convert.ToString(rest.GetSingle<double>("stat/avgdmg"));
                    Ki?.Invoke(col);

                }
                else if (response == 5)
                {
                    var col = Convert.ToString(rest.GetSingle<double>("stat/avgherodef"));
                    Ki?.Invoke(col);
                }
                else if (response == 6)
                {
                    var col = Convert.ToString(rest.GetSingle<double>("stat/avgheropower"));
                    Ki?.Invoke(col);
                }
                else if (response == 7)
                {
                    var col = rest.Get<KeyValuePair<string, double>>("stat/avgherodefbyelements");
                    foreach (var item in col)
                    {
                        Ki?.Invoke(item.ToString());
                    }

                }
                else if (response == 8)
                {
                    var col = rest.Get<KeyValuePair<string, double>>("stat/avgheropowerbyelements");
                    foreach (var item in col)
                    {
                        Ki?.Invoke(item.ToString());
                    }
                }
                else if (response == 0)
                {
                    //Kiugrik a ciklusból.
                }
                else
                {
                    Ki?.Invoke("Maybe try it one more time.");
                }
                if (response != 0)
                {
                    Ki?.Invoke("");
                }
            }
        }
    }
}