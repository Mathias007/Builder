## ``Pizzeria.cs`` - pseudocode.
```
interface IPizzaBuilder:
    method BuildDough()
    method BuildSauce()
    method BuildToppings()

class MargheritaPizzaBuilder implements IPizzaBuilder:
    - _pizza: Pizza

    constructor MargheritaPizzaBuilder():
        this.Reset()

    method Reset():
        this._pizza = new Pizza()

    method BuildDough():
        this._pizza.Add("Regular Dough")

    method BuildSauce():
        this._pizza.Add("Tomato Sauce")

    method BuildToppings():
        this._pizza.Add("Mozzarella Cheese")

    method GetPizza() -> Pizza:
        Pizza result = this._pizza
        this.Reset()
        return result

class PepperoniPizzaBuilder implements IPizzaBuilder:
    - _pizza: Pizza

    constructor PepperoniPizzaBuilder():
        this.Reset()

    method Reset():
        this._pizza = new Pizza()

    method BuildDough():
        this._pizza.Add("Pan Dough")

    method BuildSauce():
        this._pizza.Add("Marinara Sauce")

    method BuildToppings():
        this._pizza.Add("Pepperoni")
        this._pizza.Add("Sliced Onion")
        this._pizza.Add("Bell Pepper")

    method GetPizza() -> Pizza:
        Pizza result = this._pizza
        this.Reset()
        return result

class VegetarianPizzaBuilder implements IPizzaBuilder:
    - _pizza: Pizza

    constructor VegetarianPizzaBuilder():
        this.Reset()

    method Reset():
        this._pizza = new Pizza()

    method BuildDough():
        this._pizza.Add("Whole Wheat Dough")

    method BuildSauce():
        this._pizza.Add("Pesto Sauce")

    method BuildToppings():
        this._pizza.Add("Mushrooms")
        this._pizza.Add("Sliced Tomato")
        this._pizza.Add("Black Olives")

    method GetPizza() -> Pizza:
        Pizza result = this._pizza
        this.Reset()
        return result

class Pizza:
    - _parts: List<string>

    constructor Pizza():
        this._parts = new List<string>()

    method Add(part: string):
        this._parts.Add(part)

    method ListParts() -> string:
        string str = ""
        foreach part in this._parts:
            str += part + ", "
        str = str.Remove(str.Length - 2)
        return "Pizza parts: " + str + "\n"

class PizzaDirector:
    - _builder: IPizzaBuilder

    property Builder:
        set(value: IPizzaBuilder):
            this._builder = value

    method MakePizza():
        this._builder.BuildDough()
        this._builder.BuildSauce()
        this._builder.BuildToppings()

class Pizzeria:
    static method Main(args: string[]):
        PizzaDirector director = new PizzaDirector()
        MargheritaPizzaBuilder builder = new MargheritaPizzaBuilder()

        director.Builder = builder

        Output("Margherita Pizza:")
        director.MakePizza()
        Output(builder.GetPizza().ListParts())
```
