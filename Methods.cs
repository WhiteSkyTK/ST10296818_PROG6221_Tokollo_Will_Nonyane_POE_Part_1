﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10296818_PROG6221_Tokollo_Will_Nonyane_POE_Part_1
{
    public class Methods
    {
        //(Declearation) Arraylist added to store Ingredient and orginal values enteredm
        private static List<Recipe> recipes = new List<Recipe>();
        private static List<Ingredient> ingredients = new List<Ingredient>();
        private static List<Step> steps = new List<Step>();
        private static List<Ingredient> originalQuantities = new List<Ingredient>();

        //Method used to input recipe
        public static void add()
        {
            //Used for the interface and declearyion
            string dash = "------------------------------------------------------------";
            int numRecipes; //DEcleartion

            //Do loop to handle errors
            do
            {
                Console.Write("Please enter the number of recipes to add: ");
                if (!int.TryParse(Console.ReadLine(), out numRecipes) || numRecipes <= 0) //input
                {
                    Console.ForegroundColor = ConsoleColor.Red; //set the color to red
                    Console.WriteLine("Invalid input. Please enter a valid integer greater then 0.");
                    Console.ResetColor(); //reset the color
                }
            }
            while (numRecipes <= 0);

            //handle human error
            try
            {
                //for loop for number of recipes needed
                for (int i = 0; i < numRecipes; i++)  
                {
                    Console.WriteLine(); //line break
                    Console.Write($"Enter the name for recipe {i + 1}: ");
                    string recipeName = Console.ReadLine().Trim(); //input for name
                    Console.WriteLine(); //line break
                    Recipe newRecipe = new Recipe();
                    newRecipe.Name = recipeName; //set the name

                    int numIngredints; //decleartion
                    //Do loop which ensure that the user enters the correct vaule
                    do
                    {
                        Console.Write("Please enter the number of ingredients needed: ");
                        if (!int.TryParse(Console.ReadLine(), out numIngredints) || numIngredints <= 0) //input for the number of ingredients needed
                        {
                            Console.ForegroundColor = ConsoleColor.Red; //set color
                            Console.WriteLine("Invalid input. Please enter a vaild integer.");
                            Console.ResetColor(); //reset color 
                        }
                    }
                    while (numIngredints <= 0);

                    //Try and catch to handle human errors
                    try
                    {
                        //For loop for the number of ingredients needed
                        for (int x = 0; x < numIngredints; x++)
                        {
                            string Name; //decleartion
                            //Do loop which checks for whitespaces
                            do
                            {
                                //Name of ingredints
                                Console.WriteLine(); // line break
                                Console.Write($"Enter the name of ingredient {x + 1}: ");
                                Name = Console.ReadLine(); //input for the name of the ingredient 
                                if (string.IsNullOrWhiteSpace(Name))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; //set color
                                    Console.WriteLine("Ingredient name cannot be blank. Please enter a valid name.");
                                    Console.ResetColor(); //reset color
                                }
                            }
                            while (string.IsNullOrWhiteSpace(Name));

                            double Calories; //decleartion
                            do
                            {
                                // Calories
                                Console.Write("\nEnter the number of calories for " + Name + ": ");
                                if (!double.TryParse(Console.ReadLine(), out double calories) || calories < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; //set color
                                    Console.WriteLine("Invalid input. Please enter a valid positive number for calories.");
                                    Console.ResetColor(); //reset color 
                                }
                                else
                                {
                                    Calories = calories;
                                    break;
                                }
                            }
                            while (true);

                            // Food group menu
                            Console.WriteLine("\nPlease select the food group for " + Name + ": " +
                                "\n1. Starchy foods" +
                                "\n2. Vegetables and fruits" +
                                "\n3. Dry beans, peas, lentils and soya" +
                                "\n4. Chicken, fish, meat and eggs" +
                                "\n5. Milk and dairy products" +
                                "\n6. Fats and oil" +
                                "\n7. Water");

                            string FoodGroup; //decleartions
                            int foodGroupChoice;
                            do
                            {
                                Console.Write("Option: ");
                                if (!int.TryParse(Console.ReadLine(), out foodGroupChoice) || foodGroupChoice < 1 || foodGroupChoice > 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; //set color
                                    Console.WriteLine("Invalid input. Please enter a valid food group option (1-7).");
                                    Console.ResetColor(); //reset color
                                }
                                else
                                {
                                    switch (foodGroupChoice) //options
                                    {
                                        case 1:
                                            FoodGroup = "Starchy foods";
                                            break;
                                        case 2:
                                            FoodGroup = "Vegetables and fruits";
                                            break;
                                        case 3:
                                            FoodGroup = "Dry beans, peas, lentils and soya";
                                            break;
                                        case 4:
                                            FoodGroup = "Chicken, fish, meat and eggs";
                                            break;
                                        case 5:
                                            FoodGroup = "Milk and dairy products";
                                            break;
                                        case 6:
                                            FoodGroup = "Fats and oil";
                                            break;
                                        case 7:
                                            FoodGroup = "Water";
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red; //set color
                                            Console.WriteLine("Please pick a vaild value");
                                            Console.ResetColor(); //reset color
                                            throw new ArgumentOutOfRangeException();
                                    }
                                    break;
                                }
                            }
                            while (true);

                            string Unit; //declearation for unit
                                         //Do loop which loop on error
                            do
                            {
                                //Unit of measure
                                Console.WriteLine(); //line break
                                Messages.Unit(); //calling display menu for the units of measure
                                int pick;
                                if (int.TryParse(Console.ReadLine(), out pick) && pick >= 1 && pick <= 4) //input for unit option
                                {
                                    switch (pick) //switch for unit options
                                    {
                                        case 1:
                                            Unit = "Teaspoons";
                                            break;
                                        case 2:
                                            Unit = "Tablespoons";
                                            break;
                                        case 3:
                                            Unit = "Cups";
                                            break;
                                        case 4:
                                            Console.WriteLine("Please enter a unit of measurement");
                                            Unit = Console.ReadLine();
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red; //set color
                                            Console.WriteLine("Please pick a vaild value");
                                            Console.ResetColor(); //reset color
                                            throw new ArgumentOutOfRangeException(); //
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; //set color
                                    Console.WriteLine("Invalid input. Please enter a valid option (1-4).");
                                    Console.ResetColor(); //reset color
                                    Unit = null; //Set unit to null so it can loop
                                }
                            }
                            while (Unit == null);

                            double Quantity; //decleartion
                            //Do loop which loops on error
                            do
                            {
                                //Quantity
                                Console.Write("\nEnter the quantity for " + Name + " (Only a interger): ");
                                if (!double.TryParse(Console.ReadLine(), out Quantity) || Quantity <= 0) //input for quantity
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; //set color
                                    Console.WriteLine("Invalid input. Please enter a valid positive number.");
                                    Console.ResetColor(); //reset color 
                                }
                            }
                            while (Quantity <= 0);

                            Ingredient ingredient = new Ingredient(Name, Quantity, Unit, Calories, FoodGroup);
                            newRecipe.Ingredients.Add(ingredient);
                            ingredients.Add(ingredient); //adds to the arraylist
                            originalQuantities.Add(new Ingredient(Name, Quantity, Unit, Calories, FoodGroup)); // Add original quantities to the arraylist
                            Console.ForegroundColor = ConsoleColor.Cyan; //set color
                            Console.WriteLine(dash);
                            Console.ResetColor(); //reset color
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("Ingredient " + (x + 1) + " Has Been Saved"); //interface layout
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Cyan; //set color
                            Console.WriteLine(dash);
                            Console.ResetColor(); //reset color
                        }

                        int numStep; //decleartion
                                     //Do loop which loops on error
                        do
                        {
                            //number of steps
                            Console.Write("\nPlease enter the number of steps: ");
                            if (!int.TryParse(Console.ReadLine(), out numStep) || numStep <= 0)  //input for number of steps 

                            {
                                Console.ForegroundColor = ConsoleColor.Red; //set color
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Console.ResetColor(); //reset color
                            }
                        }
                        while (numStep <= 0);

                        //For loop to enter the number of steps required
                        for (int y = 0; y < numStep; y++)
                        {
                            string description; //decleartion
                                                //Do loop on error
                            do
                            {
                                //Description for the steps
                                Console.Write($"\nPlease enter the description of what to do in step {y + 1}: ");
                                description = Console.ReadLine().Trim(); //input and trim method to remove extra whitespaces
                                if (string.IsNullOrWhiteSpace(description))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; //set color
                                    Console.WriteLine("Step description cannot be blank. Please enter a valid description.");
                                    Console.ResetColor(); //reset color
                                }
                            }
                            while (string.IsNullOrWhiteSpace(description));

                            Console.WriteLine(); //line break
                            Step step = new Step(description);
                            newRecipe.Steps.Add(step);
                            steps.Add(step);

                            //Show user which step they are on
                            Console.ForegroundColor = ConsoleColor.Cyan; // Set color
                            Console.WriteLine(dash);
                            Console.ResetColor(); // Reset color
                            Console.ForegroundColor = ConsoleColor.Green; //set color
                            Console.WriteLine("Step " + (y + 1) + " Has Been Saved");
                            Console.ResetColor(); //reset color
                        }
                        //add the new recipe list
                        recipes.Add(newRecipe);

                        //Write line statement to notify user that every is good
                        Console.ForegroundColor = ConsoleColor.Cyan; // Set color
                        Console.WriteLine(dash);
                        Console.ResetColor(); // Reset color
                        Console.ForegroundColor = ConsoleColor.Green; // Set color
                        Console.WriteLine("Recipe " + (i + 1) + " Has Been Saved"); // Interface layout
                        Console.ResetColor(); // Reset color
                        
                    }
                    //This catchs invalid inputs for integers
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //set color
                        Console.WriteLine("Invaild input. Please enter a valid number.");
                        Console.ResetColor(); //reset color
                    }
                    catch (ArgumentException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //set color
                        Console.WriteLine(e.Message);
                        Console.ResetColor(); //reset color
                    }
                    //This catchs all types of errors
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //set color
                        Console.WriteLine("Something went wrong.");
                        Console.ResetColor(); //reset color
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; //set color
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor(); //reset the color
            }
        }
            
        //Display method used to display all values
        public static void Display()
        {
            //Dash string used for the interface of the program
            string dash = "------------------------------------------------------------";
            
            //
            List<string> recipeNames = recipes.Select(r => r.Name).OrderBy(n => n).ToList();
            // If statement used to check if any values in the array
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set color
                Console.WriteLine("No recipes available to display.");
                Console.ResetColor();
                return;
            }

            //Display menu for selecting a recipe
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipe List:");
            Console.ResetColor();

            for (int i = 0; i < recipeNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipeNames[i]}");
            }

            //option for recipe
            Console.Write("\nChoose a recipe by entering its number (or 0 to go back): ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > recipeNames.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid recipe number.");
                Console.ResetColor();
                return;
            }
            else if (choice == 0)
            {
                return;
            }

            Recipe chosenRecipe = recipes.FirstOrDefault(recipe => recipe.Name == recipeNames[choice - 1]);
            double totalCalories = chosenRecipe.Ingredients.Sum(i => i.Calories);

            if (totalCalories >= 0)
            {
                NotifyExceedingCalories?.Invoke(chosenRecipe.Name, totalCalories);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nRecipe Details for '{chosenRecipe.Name}':");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nIngredients:");
            Console.ResetColor();
            foreach (var ingredient in chosenRecipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nSteps:");
            Console.ResetColor();
            for (int i = 0; i < chosenRecipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {chosenRecipe.Steps[i].Description}");
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nTotal Calories: {totalCalories}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nClick any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        //Scaling method to scale up or down the recipes ingredeint
        public static void Scale()
        {
            //if statement which check for recipes
            if (ingredients.Count == 0 && steps.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; //set color
                Console.WriteLine("No recipes available to scale.");
                Console.ResetColor();
                return;
            }

            //Calling the display menu for the scales
            Methods.scaleOption();

            //Declearation
            double factor;
            int scaling = Convert.ToInt32(Console.ReadLine()); //input for selecting the option of scaling needed

            //switch method to choose a scale
            switch (scaling)
            {
                case 1:
                    factor = 2.0; //double the value
                    break;
                case 2:
                    factor = 3.0; // triple the value
                    break;
                case 3:
                    factor = 0.5; // half the value
                    break;
                case 4:
                    //Back button
                    factor = 1.0;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; //set color
                    Console.WriteLine("Invalid scaling factor."); //invalid option
                    Console.ResetColor();
                    return;
            }

            // For each ingredient, adjust the quantity and unit based on the scaling factor
            foreach (Ingredient ingredient in ingredients)
            {
                // If unit is Teaspoons
                if (ingredient.Unit == "Teaspoons")
                {
                    ingredient.Quantity *= factor;
                    if (factor >= 2.0 && ingredient.Quantity >= 3.0)
                    {
                        // Convert to Tablespoons
                        ingredient.Quantity /= 3.0;
                        ingredient.Unit = "Tablespoons";
                    }
                }
                // If unit is Tablespoons
                else if (ingredient.Unit == "Tablespoons")
                {
                    ingredient.Quantity *= factor;
                    if (factor >= 2.0 && ingredient.Quantity >= 16.0)
                    {
                        // Convert to Cups
                        ingredient.Quantity /= 16.0;
                        ingredient.Unit = "Cups";
                    }
                    else if (factor == 0.5 && ingredient.Quantity < 1.0)
                    {
                        // Convert to Teaspoons
                        ingredient.Quantity *= 3.0;
                        ingredient.Unit = "Teaspoons";
                    }
                }
                // If unit is Cups
                else if (ingredient.Unit == "Cups")
                {
                    ingredient.Quantity *= factor;
                    if (factor == 0.5 && ingredient.Quantity < 1.0)
                    {
                        // Convert to Tablespoons
                        ingredient.Quantity *= 16.0;
                        ingredient.Unit = "Tablespoons";
                    }
                }
                // For other units, simply scale the quantity
                else
                {
                    ingredient.Quantity *= factor;
                }
            }

            //if statement which the case with the scaling up or down displays the message
            if (scaling == 1 || scaling == 2 || scaling == 3)
            {
                //write line statement which tells the user that everything is good
                Console.ForegroundColor = ConsoleColor.Green; //set color
                Console.WriteLine($"Recipe scaled by a factor of {factor}.");
                Console.ResetColor(); //reset color
            } 
        }

        //Delete recipe method used to delete a recipe(COMING SOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOON)
        public static void DeleteRecipe()
        {
            //if statemant which checks if the are any values in the arraylist
            if (ingredients.Count == 0 && steps.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; //set color
                Console.WriteLine("No recipes available to delete.");
                Console.ResetColor(); //reset color
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green; //set color
            Console.WriteLine("Feature is not available (Coming Soon)");
            Console.ResetColor(); //reset color
        }

        //Method to delete all recipes 
        public static void DeleteAll()
        {
            //if statement to check if there is any values in the arraylist
            if (ingredients.Count == 0 && steps.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; //set color
                Console.WriteLine("No recipes available to delete");
                Console.ResetColor(); //reset color
                return;
            }

            //Are you sure message
            Console.Write("Are you sure you want to delete all recipe\n" +
                "1. Yes\n" +
                "2. No\n" +
                "Option: ");
            int num = Convert.ToInt32(Console.ReadLine()); //input
            switch(num)
            {
                case 1:
                    //Clears all the values in a arraylist
                    ingredients.Clear();
                    steps.Clear();
                    originalQuantities.Clear();
                    recipes.Clear();
                    Console.ForegroundColor = ConsoleColor.Green; //set color
                    Console.WriteLine("\nAll recipes have been deleted.");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green; //set color
                    Console.WriteLine("\nNot action has been taken.");
                    Console.ResetColor();
                    break;
            }
        }

        //Reset scale method
        public static void resetScale()
        {
            //if statement that check if there any values in the arraylist
            if(ingredients.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; //set color
                Console.WriteLine("No recipe available to reset scale.");
                Console.ResetColor();
                return;
            }

            //Loop that resets scales all quantities
            for(int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i].Quantity; //assigning orginal values to the default arraylist
                ingredients[i].Unit = originalQuantities[i].Unit; // assigning original values to the default ones (as user entered)
            }
            //tells the user that everything is fine.
            Console.ForegroundColor = ConsoleColor.Green; //set color
            Console.WriteLine("Scale reset to original values.");
            Console.ResetColor(); //reset color
        }
        
        //method used to close the program
        public static void close()
        {
            Console.ForegroundColor= ConsoleColor.Green; //set color
            Console.WriteLine("Thank you for using the system\n");
            Console.ResetColor(); //reset color
        }

        //Methods to start the program and contains all the methods
        public static void Start()
        {
            Methods.Option(); //option menu
        }

        //Method to display the main option menu
        public static void Option()
        {
            //Used for the interface
            string dash = "------------------------------------------------------------";
            Console.ForegroundColor = ConsoleColor.Cyan; //set color
            Console.WriteLine(dash);
            Console.ResetColor(); //reset color
            Console.Write("What would you like to do:" + "\n" +
                "1. Add a new recipe" + "\n" +
                "2. Display recipe" + "\n" +
                "3. Scale recipe" + "\n" +
                "4. Original scale" + "\n" +
                "5. Delete recipe" + "\n" +
                "6. Clear all data" + "\n" +
                "7. Close the program" + "\n" +
                "Option: ");
        }

        //Method to display the option menu for the scaling
        public static void scaleOption()
        {
            //used for the interface 
            string dash = "------------------------------------------------------------";

            Console.ForegroundColor = ConsoleColor.Cyan; //set color
            Console.WriteLine(dash);
            Console.ResetColor(); //reset color
            Console.Write("What would you like to do:" + "\n" +
                "1. Factor of 2 (Double)" + "\n" +
                "2. Factor of 3 (Triple)" + "\n" +
                "3. Factor of 0.5 (Half)" + "\n" +
                "4. Back" + "\n" +
                "Option: ");
        }
        // Delegate to handle notification when a recipe exceeds 300 calories
        public delegate void ExceedingCaloriesHandler(string recipeName, double totalCalories);
        public static event ExceedingCaloriesHandler NotifyExceedingCalories;
    }

    //Class which stores messasges and menu options
    class Messages
    {
        //method of the welcome screen
        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.White; //set color
            Console.WriteLine("Welcome user to recipez!!!!" + 
                "\nA place where you can find all types of recipes");
            Console.ResetColor(); //reseting the color
        }

        //method of the display menu for the unit of measure
        public static void Unit()
        {
            Console.Write("Please pick a unit of measure:" + "\n" +
                "1. Teaspoons (tsp)" + "\n" +
                "2. Tablespoons (tbsp)" + "\n" +
                "3. Cups" + "\n" +
                "4. Others" + "\n" +
                "Option: ");
        }
    }
    //Class which stores the ingredients name, quantity, unit (Using getters and setters)
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
    //Class which store the steps description (Using getters and setters)
    public class Step
    {
        public string Description { get; set; }
        public Step(string description)
        {
            Description = description; 
        }
    }
    // Define Recipe class to hold ingredients and steps
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }
    }
}