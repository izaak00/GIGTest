Focused more on an object oriented approach to make sure that this code is future proof.

Added the following classes:

RefrigiratedItems.cs
SpecialItems.cs
RegularItems.cs

Each class inherits from Item.cs

In program.cs, Each time an item is added, now I am specifying each time the type of item.

For example: new RefrigiratedItems{}

Each class overrides UpdateValue() with the necessary functionalities required.

I also opted to implement a .gitignore file to eliminate any uneccessary commits and junk to the git repository.

Thanks for your feedback, it is much appreciated.