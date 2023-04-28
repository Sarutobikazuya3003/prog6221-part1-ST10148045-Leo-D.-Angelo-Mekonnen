using System;

namespace RecipeScaler
{
    public enum UnitOfMeasurement
    {
        None = 0,
        kg = 1,
        g = 2,
        ml = 3,
        l = 4,
        tsp = 5,
        tbsp = 6,
        cup = 7
    }

    class MainClass
    {
        public static void Main()
        {
            new Recipe();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }

    class Ingredient
    {
        private string _name;
        private double _quantity;
        private UnitOfMeasurement _unit;

        public string Name
        {
            get => this._name; set => this._name = value;
        } // The name of the ingredient
        public double Quantity
        {
            get => this._quantity; set => this._quantity = value;
        } // The quantity of the ingredient
        public UnitOfMeasurement Unit
        {
            get => this._unit; set => this._unit = value;
        } // The unit of measurement for the ingredient

        public Ingredient(string name, double quantity, UnitOfMeasurement unit) // Constructor for the Ingredient class
        {
            this._name = name;
            this._quantity = quantity;
            this._unit = unit;
        }

        public Ingredient(Ingredient ingredient)
        {
            this.Name = ingredient.Name;
            this.Quantity = ingredient.Quantity;
            this.Unit = ingredient.Unit;
        }

        public void Scale(double scale)
        {
            Quantity *= scale;
            if (this._unit == UnitOfMeasurement.g && this._quantity >= 1000)
            {
                this._unit = UnitOfMeasurement.kg;
                this._quantity /= 100;
            }
        }

        public override string ToString() // Override the ToString method to return a string representation of the ingredient
        {
            return $"{Quantity} {Unit} {Name}";
        }
    }

    class Recipe
    {
        private Ingredient[] _ingredients; // Array of ingredients
        private readonly Ingredient[] _original;
        private string[] _steps; // Array of steps for the recipe

        public Recipe() // Constructor for the Recipe class
        {
            bool mainloop = false;
            do
            {
                Console.Write("Add a new Recipe\nEnter \"e\" to Exit\nEnter the number of ingredients: ");
                string user_in = Console.ReadLine();
                if (user_in.ToUpper() == "E")
                {
                    mainloop = true;
                    break;
                }
                int numIngredients = Convert.ToInt32(user_in);

                _ingredients = new Ingredient[numIngredients]; // Initialize the ingredients array with the number of ingredients specified by the user

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"\nIngredient {i + 1}:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
                    Console.Write("1) Kg\n2) G\n3) Ml\n4) L\n5) Tsp\n6) Tbsp\n7) Cup\nUnit: ");
                    UnitOfMeasurement unit = (UnitOfMeasurement)Convert.ToInt32(Console.ReadLine());

                    _ingredients[i] = new Ingredient(name, quantity, unit); // Create a new ingredient object and add it to the ingredients array
                }

                _original = new Ingredient[numIngredients];

                for (int i = 0; i < _ingredients.Length; i++)
                {
                    _original[i] = new Ingredient(_ingredients[i]);
                }

                Console.Write("\nEnter the number of steps: ");
                int numSteps = Convert.ToInt32(Console.ReadLine());

                _steps = new string[numSteps]; // Initialize the steps array with the number of steps specified by the user

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"\nStep {i + 1}:");
                    Console.Write("Description: ");
                    _steps[i] = Console.ReadLine();
                }

                DisplayRecipe();

                bool apploop = false;
                do
                {
                    Console.WriteLine("1) Scale\n2) Reset\n3) Clear\n4) Exit");
                    Console.Write("Enter option: ");

                    int option;

                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        option = 0;
                    }


                    if (option == 4)
                    {
                        apploop = true;
                        mainloop = true;
                    }
                    else if (option >= 1 && option <= 3)
                    {
                        //Handle the necessary events
                        switch (option)
                        {
                            case (1):
                                bool validfactor = false;
                                double scale = default;
                                do
                                {
                                    Console.WriteLine("Enter the amount you want to scale by:");
                                    try
                                    {
                                        string _scale = Console.ReadLine();
                                        scale = Convert.ToDouble(_scale.Replace('.', ','));
                                        validfactor = true;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Invalid Scale Applied");
                                    }
                                } while (!validfactor);
                                ScaleRecipe(scale);
                                DisplayRecipe();
                                break;

                            case (2):
                                ResetRecipe();
                                Console.WriteLine("Recipe Reset!");
                                DisplayRecipe();
                                break;

                            case (3):
                                ClearRecipe();
                                Console.WriteLine("Recipe Has been cleared!");
                                apploop = true;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option!");
                    }

                } while (!apploop);
            } while (!mainloop);

        }

        public void DisplayRecipe() // Method to display the recipe
        {
            Console.WriteLine("\nIngredients:");

            foreach (Ingredient ingredient in _ingredients) // Loop through each ingredient and display it using the ToString method
            {
                Console.WriteLine(ingredient.ToString());
            }

            Console.WriteLine("\nSteps:");

            for (int i = 0; i < _steps.Length; i++) // Loop through each step and display it
            {
                Console.WriteLine($"{i + 1}. {_steps[i]}");
            }
            Console.WriteLine("\n");
        }

        public void ScaleRecipe(double factor) // Method to scale the recipe by a given factor
        {
            for (int i = 0; i < _ingredients.Length; i++)
            {
                _ingredients[i].Quantity *= factor; // Multiply each ingredient quantity by the scaling factor
            }
        }

        public void ResetRecipe() // Method to reset the recipe to its original values
        {
            for (int i = 0; i < _original.Length; i++)
            {
                _ingredients[i] =  new Ingredient(_original[i]);
            }
        }

        public void ClearRecipe() // Method to clear the recipe
        {
            _ingredients = null; // Set the ingredients array to null
            _steps = null; // Set the steps array to null
        }
    }
}
