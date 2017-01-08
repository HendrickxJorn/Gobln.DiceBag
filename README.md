# Gobln.DiceBag

A C# custom dice library.

### License: Apache License 2.0

### Features
* Support 4.0 and higher
* Use most common dice
* Create your own dice
* Group dice together

```csharp
// single D6 dice
var dice = new Dice(DiceTypes.d6);

//roll the dice
dice.Roll();


// 2 D6 dice and a + 5 modifier
 var dice2 = new Dice(DiceTypes.d6, 2, 5);
 
//roll the dice
dice2.Roll();


// multiple dice
var cb = new DicesCup();
cb.Add(new Dice(DiceTypes.d6, 2));
cb.Add(new Dice(DiceTypes.d6));
cb.Add(new Dice(DiceTypes.d6));
cb.Add(new Dice(DiceTypes.d6));
cb.Add(new Dice(DiceTypes.d6));
cb.Add(new Dice(DiceTypes.d6));
cb.Add(new Dice(10000));

// roll the cup
cb.Roll();


```