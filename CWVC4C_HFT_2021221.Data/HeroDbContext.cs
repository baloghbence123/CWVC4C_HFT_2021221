using Microsoft.EntityFrameworkCore;
using System;
using CWVC4C_HFT_2021221.Models;

namespace CWVC4C_HFT_2021221.Data
{
    public class HeroDbContext : DbContext
    {
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<Ability> Abilities { get; set; }

        public HeroDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conP = @"Data Source=(localDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\localDb.mdf;Integrated Security=True";
                builder.UseLazyLoadingProxies().UseSqlServer(conP);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>(entity =>
            {
                entity.HasOne(hero => hero.Element)
                .WithMany(element => element.Heroes)
                .HasForeignKey(hero => hero.ElementId)
                .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<Ability>(entity =>
            {
                entity.HasOne(Abilities => Abilities.Hero)
                .WithMany(hero => hero.Abilities)
                .HasForeignKey(Abilities => Abilities.HeroId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //ELEMENTS
            Element Fire = new Element() { ElementId = 1, Name = "Fire" };
            Element Water = new Element() { ElementId = 2, Name = "Water" };
            Element Wind = new Element() { ElementId = 3, Name = "Wind" };
            Element Earth = new Element() { ElementId = 4, Name = "Earth" };

            //HEROES
            //Water
            Hero SoulWizard = new Hero() { HeroId = 1, Name = "Soul Wizard", AttackPower = 50, DefensePower = 75, ElementId = Water.ElementId };
            Hero SoulMaster = new Hero() { HeroId = 2, Name = "Soul Master", AttackPower = 80, DefensePower = 140, ElementId = Water.ElementId };
            Hero GrandMaster = new Hero() { HeroId = 3, Name = "Grand Master", AttackPower = 150, DefensePower = 300, ElementId = Water.ElementId };
            //Fire
            Hero DarkKnight = new Hero() { HeroId = 4, Name = "Dark Knight", AttackPower = 70, DefensePower = 50, ElementId = Fire.ElementId };
            Hero BladeKnight = new Hero() { HeroId = 5, Name = "Blade Knight", AttackPower = 140, DefensePower = 70, ElementId = Fire.ElementId };
            Hero BladeMaster = new Hero() { HeroId = 6, Name = "Blade Master", AttackPower = 320, DefensePower = 140, ElementId = Fire.ElementId };
            //Wind
            Hero FairyElf = new Hero() { HeroId = 7, Name = "Fairy Elf", AttackPower = 60, DefensePower = 60, ElementId = Wind.ElementId };
            Hero MuseElf = new Hero() { HeroId = 8, Name = "Muse Elf", AttackPower = 100, DefensePower = 100, ElementId = Wind.ElementId };
            Hero HighElf = new Hero() { HeroId = 9, Name = "High Elf", AttackPower = 200, DefensePower = 200, ElementId = Wind.ElementId };
            //Earth
            Hero RageFighter = new Hero() { HeroId = 10, Name = "Rage Fighter", AttackPower = 170, DefensePower = 20, ElementId = Earth.ElementId };
            Hero FistMaster = new Hero() { HeroId = 11, Name = "Fist Master", AttackPower = 450, DefensePower = 70, ElementId = Earth.ElementId };

            //ABILITIES //SM
            Ability EnergyBall = new Ability() { AbilityId = 1, Name = "Energy Ball", ManaCost = 50, DMG = 50, HeroId = SoulWizard.HeroId };
            Ability WaterBall = new Ability() { AbilityId = 2, Name = "Water Ball", ManaCost = 30, DMG = 30, HeroId = SoulWizard.HeroId };

            Ability IceWave = new Ability() { AbilityId = 3, Name = "Ice Wave", ManaCost = 55, DMG = 80, HeroId = SoulMaster.HeroId };
            Ability Teleport = new Ability() { AbilityId = 4, Name = "Teleport", ManaCost = 15, DMG = 0, HeroId = SoulMaster.HeroId };

            Ability IceStorm = new Ability() { AbilityId = 5, Name = "Ice Storm", ManaCost = 65, DMG = 120, HeroId = GrandMaster.HeroId };
            Ability FreezingEvilSpirits = new Ability() { AbilityId = 6, Name = "Freezing Evil Spirits", ManaCost = 30, DMG = 75, HeroId = GrandMaster.HeroId };

            //BM
            Ability TwistingSlash = new Ability() { AbilityId = 7, Name = "Twisting Slash", ManaCost = 40, DMG = 75, HeroId = DarkKnight.HeroId };
            Ability Uppercut = new Ability() { AbilityId = 8, Name = "Uppercut", ManaCost = 10, DMG = 20, HeroId = DarkKnight.HeroId };

            Ability DeathStab = new Ability() { AbilityId = 9, Name = "Death Stab", ManaCost = 45, DMG = 90, HeroId = BladeKnight.HeroId };
            Ability AlphaStrike = new Ability() { AbilityId = 10, Name = "Alpha Strike", ManaCost = 70, DMG = 100, HeroId = BladeKnight.HeroId };

            Ability RagefulBlow = new Ability() { AbilityId = 11, Name = "Rageful Blow", ManaCost = 50, DMG = 150, HeroId = BladeMaster.HeroId };

            //ELF
            Ability WindArrow = new Ability() { AbilityId = 12, Name = "Wind Arrow", ManaCost = 5, DMG = 30, HeroId = FairyElf.HeroId };
            Ability Heal = new Ability() { AbilityId = 13, Name = "Heal", ManaCost = 20, DMG = 0, HeroId = FairyElf.HeroId };

            Ability TornadeShot = new Ability() { AbilityId = 14, Name = "Tornade Shot", ManaCost = 15, DMG = 60, HeroId = MuseElf.HeroId };
            Ability TripleShot = new Ability() { AbilityId = 15, Name = "Triple Shot", ManaCost = 17, DMG = 25, HeroId = MuseElf.HeroId };

            Ability Penetration = new Ability() { AbilityId = 16, Name = "Penetration", ManaCost = 100, DMG = 150, HeroId = HighElf.HeroId };
            Ability Starfall = new Ability() { AbilityId = 17, Name = "Starfall", ManaCost = 77, DMG = 88, HeroId = HighElf.HeroId };

            //RF
            Ability Earthquake = new Ability() { AbilityId = 18, Name = "Earthquake", ManaCost = 82, DMG = 130, HeroId = RageFighter.HeroId };
            Ability ChainDrive = new Ability() { AbilityId = 19, Name = "Chain Drive", ManaCost = 30, DMG = 76, HeroId = RageFighter.HeroId };

            Ability BeastUpper = new Ability() { AbilityId = 20, Name = "Beast Upper", ManaCost = 30, DMG = 140, HeroId = FistMaster.HeroId };
            Ability Terraform = new Ability() { AbilityId = 21, Name = "Terraform", ManaCost = 100, DMG = 200, HeroId = FistMaster.HeroId };

            modelBuilder.Entity<Element>().HasData(Water, Earth, Fire, Wind);

            modelBuilder.Entity<Hero>().HasData(SoulWizard, SoulMaster, GrandMaster, DarkKnight, BladeKnight,
                BladeMaster, FairyElf, MuseElf, HighElf, RageFighter, FistMaster);

            modelBuilder.Entity<Ability>().HasData(EnergyBall, WaterBall, IceWave, Teleport, IceStorm, FreezingEvilSpirits,
                TwistingSlash, Uppercut, DeathStab, AlphaStrike,
                RagefulBlow, WindArrow, Heal, TornadeShot, TripleShot,
                Penetration, Starfall, Earthquake, ChainDrive, BeastUpper, Terraform);







        }


    }
}