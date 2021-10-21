using CWVC4C_HFT_2021221.Data;
using CWVC4C_HFT_2021221.Logic;
using CWVC4C_HFT_2021221.Models;
using CWVC4C_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CWVC4C_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        IAbilityLogic abilityLogic;
        IHeroLogic heroLogic;
        IElementLogic elementLogic;

        

        [SetUp]
        public void Init()
        {
            var mockAbilityRepository = new Mock<IAbilityRepository>();
            var mockHeroRepository = new Mock<IHeroRepository>();
            var mockElementRepository = new Mock<IElementRepository>();

            

            var fakeElement = new List<Element>() 
            {
                new Element() { ElementId = 1, Name = "Light"},
                new Element() { ElementId=2, Name = "Physical"}
            }.AsQueryable();

            var fakeHeros = new List<Hero>() 
            {
                new Hero() { Name = "Frédi", AttackPower = 2, DefensePower = 2, Element = fakeElement.ElementAt(0), ElementId = 1, HeroId = 1 },
                new Hero() { Name = "Béni",AttackPower=10, DefensePower=6, Element=fakeElement.ElementAt(1), ElementId=1, HeroId=2 }           
            }.AsQueryable();

            fakeElement.ElementAt(0).Heroes.Add(fakeHeros.ElementAt(0));
            fakeElement.ElementAt(1).Heroes.Add(fakeHeros.ElementAt(1));

            var fakeAbility = new List<Ability>()
            {
                new Ability(){Name="UpperCut", DMG=20 , ManaCost=10, HeroId=1 , Hero=fakeHeros.ElementAt(0), AbilityId=1},
                new Ability(){Name="PunchInTheFace", DMG=99, ManaCost=1, HeroId=2, Hero=fakeHeros.ElementAt(1), AbilityId=2}
            }.AsQueryable();
            
            fakeHeros.ElementAt(0).Abilities.Add(fakeAbility.ElementAt(0));
            fakeHeros.ElementAt(1).Abilities.Add(fakeAbility.ElementAt(1));



            mockAbilityRepository.Setup((t) => t.ReadAll()).Returns(fakeAbility);
            mockHeroRepository.Setup((t) => t.ReadAll()).Returns(fakeHeros);
            mockElementRepository.Setup((t) => t.ReadAll()).Returns(fakeElement);


            abilityLogic = new AbilityLogic(mockAbilityRepository.Object);
            heroLogic = new HeroLogic(mockHeroRepository.Object);
            elementLogic = new ElementLogic(mockElementRepository.Object);

            

            

        }

        [Test]
        public void AVGpowerofHerosTest()
        {
            var result = heroLogic.AvgHeroPower();

            Assert.That(result, Is.EqualTo(6));

        }
        [Test]
        public void AVGdefofHeroesTest()
        {
            var result = heroLogic.AvgHeroDef();

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void AVGHeroDefByElementsTest()
        {
            var result = heroLogic.AVGHeroDefByElements();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Light",2),
                new KeyValuePair<string, double>("Physical",6)
            };


            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AVGHeroPowerByElementsTest()
        {
            var result = heroLogic.AVGHeroPowerByElements();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Light",2),
                new KeyValuePair<string, double>("Physical",10)
            };

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TheStrongestElementByAbilityTest()
        {
            var result = abilityLogic.TheStrongestElementByAbility();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Physical",99) 
            };

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void CreatAbilityTest()
        {
            //no name miatt eldobja
            var uppercut = new Ability() {DMG = 20, ManaCost = 10, HeroId = 1, AbilityId = 1 };

            Assert.Throws<ArgumentException>(() => abilityLogic.Create(uppercut));

        }
        [Test]
        public void CreateHeroTest()
        {
            var Smasher = new Hero() {AttackPower=15,DefensePower=3,HeroId=3, };  
            
            Assert.Throws<ArgumentException>(()=>heroLogic.Create(Smasher));

        }
        [Test]
        public void CreateElementTest()
        {
            var Darkness = new Element() { ElementId = 1, };

            Assert.Throws<ArgumentException>(() => elementLogic.Create(Darkness));
        }
        [Test]
        public void AvgManaCostByHeroes()
        {
            var result = abilityLogic.AVGManaByHsA();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Frédi",10),
                new KeyValuePair<string, double>("Béni",1)
            };

            Assert.That(result, Is.EqualTo(expected));


        }

        [Test]
        public void AvgDmgByHeroes()
        {
            var result = abilityLogic.AVGdmgByHsA();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Frédi",20),
                new KeyValuePair<string,double>("Béni",99)
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        //20 99
        



    }
}
