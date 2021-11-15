
using CWVC4C_HFT_2021221.Client.MenuItems;
using CWVC4C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CWVC4C_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            //RestService rest = new RestService("http://localhost:29868");

            //rest.Post<Element>(new Element()
            //{
            //    Name = "Darkness"
            //},"element");

            //var elements = rest.Get<Element>("element");
            //var heroes = rest.Get<Hero>("hero");

            //var avgheropwr = rest.GetSingle<double>("stat/avgheropower");

            ;

            
            
            Menu m = new();
            

            MyMethods myMethods = new();

            m.Be += myMethods.Answer;
            m.Ki += myMethods.WriteOut;
            m.Clear += myMethods.Clear;

            m.Start();

        }
    }
    public class MyMethods
    {
        public string Answer()
        {
            return Console.ReadLine();
        }
        public void WriteOut(string wo)
        {
            
            Console.WriteLine(wo);
            
        }
        public void Clear()
        {
            Console.Clear();
        }
    }

}
