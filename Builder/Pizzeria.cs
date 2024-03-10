using System;
using System.Collections.Generic;

namespace BuilderPatternPizza
{
    public interface IPizzaBuilder
    {
        void BuildDough();
        void BuildSauce();
        void BuildToppings();
    }

    public class MargheritaPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza;

        public MargheritaPizzaBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._pizza = new Pizza();
        }

        public void BuildDough()
        {
            this._pizza.Add("Regular Dough");
        }

        public void BuildSauce()
        {
            this._pizza.Add("Tomato Sauce");
        }

        public void BuildToppings()
        {
            this._pizza.Add("Mozzarella Cheese");
        }

        public Pizza GetPizza()
        {
            Pizza result = this._pizza;
            this.Reset();
            return result;
        }
    }

    public class Pizza
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;
            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);
            return "Pizza parts: " + str + "\n";
        }
    }

    public class PizzaDirector
    {
        private IPizzaBuilder _builder;

        public IPizzaBuilder Builder
        {
            set { _builder = value; }
        }

        public void MakePizza()
        {
            this._builder.BuildDough();
            this._builder.BuildSauce();
            this._builder.BuildToppings();
        }
    }

    class Pizzeria
    {
        static void Main(string[] args)
        {
            var director = new PizzaDirector();
            var builder = new MargheritaPizzaBuilder();

            director.Builder = builder;

            Console.WriteLine("Margherita Pizza:");
            director.MakePizza();
            Console.WriteLine(builder.GetPizza().ListParts());
        }
    }
}
