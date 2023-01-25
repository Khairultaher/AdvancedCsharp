/*
 * it is a structural pattern that is used to minimize the number of objects created, 
 * to decrease memory footprint and increase performance.
*/

using static BurgerMeal;

var mealFactory = new MealFactory();
mealFactory.PrintMeals();

var mediumBurgerMeal = mealFactory.GetMeal("Burger Meal");
mediumBurgerMeal.Serve("medium");
var mediumPizzaMeal = mealFactory.GetMeal("Pizza Meal");
mediumPizzaMeal.Serve("medium");

var largeBurgerMeal = mealFactory.GetMeal("Burger Meal");
largeBurgerMeal.Serve("large");
var largePizzaMeal = mealFactory.GetMeal("Pizza Meal");
largePizzaMeal.Serve("large");

mealFactory.PrintMeals();

public interface IMeal
{
    string Name { get; }
    void Serve(string size);
}

public class PizzarMeal : IMeal
{
    public PizzarMeal()
    {
        Name = "Pizza Meals";
    }

    public string Name { get; }

    public void Serve(string size)
    {
        Console.WriteLine($"Served {Name} - {size}");
    }
}

public class BurgerMeal : IMeal
{
    private List<string> _partsOfMeal;

    public BurgerMeal()
    {
        Name = "Burger Meals";
        _partsOfMeal = new List<string> { "Burger", "Fries", "Coke" };
    }

    public string Name { get; }

    public void Serve(string size)
    {
        Console.WriteLine($"Served {Name} - {size}");
    }

    public class MealFactory
    {
        private readonly Dictionary<string, IMeal> _meals = new Dictionary<string, IMeal>();

        public IMeal GetMeal(string key)
        {
            IMeal meal;

            if (_meals.ContainsKey(key))
            {
                return _meals[key];
            }

            switch (key)
            {
                case "Burger Meal":
                    meal = new BurgerMeal();
                    Thread.Sleep(1300);
                    break;

                case "Pizza Meal":
                    meal = new PizzarMeal();
                    Thread.Sleep(1300);
                    break;

                default:
                    throw new ArgumentException("Unknown meal");
            }

            _meals.Add(key, meal);

            return meal;
        }

        public void PrintMeals()
        {
            Console.WriteLine($"{_meals.Count} meals have been added to the cache.");
            Console.WriteLine("The following meals are available:");

            foreach (var meal in _meals)
            {
                Console.WriteLine($"{meal.Value.Name}");
            }
        }
    }
}