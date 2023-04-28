Function of C# Application. 
 This is a C# console application for scaling and modifying recipes.

There are three classes defined in the application: MainClass, Ingredient, and Recipe.

The MainClass has a single method called Main which creates a new Recipe object and waits for the user to press any key before exiting the application.

The Ingredient class represents an ingredient in a recipe. It has three private fields for the ingredient name, quantity, and unit of measurement. There is a constructor that initializes these fields with the values passed as parameters. There are also two methods called Scale and ToString. The Scale method scales the quantity of the ingredient by a factor passed as a parameter. If the ingredient's unit is grams and the new quantity is 1000 grams or more, the unit is changed to kilograms and the quantity is divided by 100. The ToString method returns a string representation of the ingredient.

The Recipe class represents a recipe. It has three private fields: an array of Ingredient objects, an array of strings for the steps in the recipe, and a read-only copy of the original ingredients array. The constructor for Recipe prompts the user for the number of ingredients and steps in the recipe, then initializes the ingredients and steps arrays with the user's input. There are three methods in the Recipe class: DisplayRecipe, ScaleRecipe, and ResetRecipe. The DisplayRecipe method prints out the list of ingredients and steps. The ScaleRecipe method scales all of the ingredients in the recipe by a factor passed as a parameter. The ResetRecipe method resets the recipe to its original state.



Instructions for how to compile and run the software.

 Make sure you have the necessary software and tools installed on your computer. This may include a programming language compiler, an integrated development environment (IDE), and any dependencies required by the application.
Download or clone the source code of the application from a code repository like GitHub.
Open the project in your IDE and configure any necessary settings, such as the target platform or build configuration.
Build the application by compiling the source code into an executable file or package. This process may involve running a build script or using a tool such as MSBuild on Visual Studio.
Once the build is complete, you can run the application by executing the generated executable file or by using a command or script.


Link to Github Repository:
https://github.com/IIEMSA/prog6221-part1-Sarutobikazuya3003
