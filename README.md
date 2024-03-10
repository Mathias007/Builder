## ``Pizzeria.cs`` - pseudocode.
```
interface IPizzaBuilder:
    void BuildDough()
    void BuildSauce()
    void BuildToppings()

class MargheritaPizzaBuilder implements IPizzaBuilder:
    private Pizza _pizza

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

    method GetPizza():
        Pizza result = this._pizza
        this.Reset()
        return result

class Pizza:
    private List<string> _parts

    constructor Pizza():
        this._parts = new List<string>()

    method Add(part: string):
        this._parts.Add(part)

    method ListParts() -> string:
        string str = ""
        for i in range(0, this._parts.Count):
            str += this._parts[i] + ", "
        str = str.Remove(str.Length - 2)
        return "Pizza parts: " + str + "\n"

class PizzaDirector:
    private IPizzaBuilder _builder

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
