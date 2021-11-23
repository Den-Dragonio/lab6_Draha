using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6._3__1_
{
    abstract class Card
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public int Value { get; set; }

        public Card(string name, string rarity, int value)
        {
            Name = name;
            Value = value;
            Rarity = rarity;
        }

        public abstract void Display();
    }

    class Troop : Card
    {
        public int Attack { get; set; }
        public int Health { get; set; }

        public Troop(string name, string rarity, int value, int attack, int health)
            : base(name, rarity, value)
        {
            Attack = attack;
            Health = health;
        }

        public override void Display()
        {
            Console.WriteLine($"Card {Name} with rarity {Rarity} has attack = {Attack}, health = {Health} and costs: {Value}!");
        }
    }

    class Spell : Card
    {
        public int Damage { get; set; }

        public Spell(string name, string rarity, int value, int damage)
            : base(name, rarity, value)
        {
            Damage = damage;
        }
        
        public override void Display()
        {
            Console.WriteLine($"Card {Name} with rarity {Rarity} can deal damage {Damage} and costs: {Value}!");
        }
    }

    interface ICount
    {
        void Count();
    }

    class DeckCost : ICount
    {
        public void Count()
        {
            Console.WriteLine("Deck avarage elixir trade: ");
        }
    }

    class Program
    {
        static void Action(ICount deck)
        {
            deck.Count();
        }

        public static void Main()
        {
            Troop t = new Troop("knight", "common", 3, 100, 2000);
            Spell s = new Spell("Lightning", "Epic", 7, 500);
            DeckCost dc = new DeckCost();
            t.Display();
            s.Display();
            Action(dc);
            Console.ReadLine();
        }
    }
}
