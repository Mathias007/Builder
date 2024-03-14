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

    public class PepperoniPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza;

        public PepperoniPizzaBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._pizza = new Pizza();
        }

        public void BuildDough()
        {
            this._pizza.Add("Pan Dough");
        }

        public void BuildSauce()
        {
            this._pizza.Add("Marinara Sauce");
        }

        public void BuildToppings()
        {
            this._pizza.Add("Pepperoni");
            this._pizza.Add("Sliced Onion");
            this._pizza.Add("Bell Pepper");
        }

        public Pizza GetPizza()
        {
            Pizza result = this._pizza;
            this.Reset();
            return result;
        }
    }

    public class VegetarianPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza;

        public VegetarianPizzaBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._pizza = new Pizza();
        }

        public void BuildDough()
        {
            this._pizza.Add("Whole Wheat Dough");
        }

        public void BuildSauce()
        {
            this._pizza.Add("Pesto Sauce");
        }

        public void BuildToppings()
        {
            this._pizza.Add("Mushrooms");
            this._pizza.Add("Sliced Tomato");
            this._pizza.Add("Black Olives");
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

            Console.WriteLine("Margherita Pizza:");
            var margheritaBuilder = new MargheritaPizzaBuilder();
            director.Builder = margheritaBuilder;
            director.MakePizza();
            Console.WriteLine(margheritaBuilder.GetPizza().ListParts());

            Console.WriteLine("Pepperoni Pizza:");
            var pepperoniBuilder = new PepperoniPizzaBuilder();
            director.Builder = pepperoniBuilder;
            director.MakePizza();
            Console.WriteLine(pepperoniBuilder.GetPizza().ListParts());

            Console.WriteLine("Vegetarian Pizza:");
            var vegetarianBuilder = new VegetarianPizzaBuilder();
            director.Builder = vegetarianBuilder;
            director.MakePizza();
            Console.WriteLine(vegetarianBuilder.GetPizza().ListParts());
        }
    }
}
