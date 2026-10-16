using System;
using System.Collections.Generic;

var story = new Dictionary<string, Scene>
{
  ["start"] = new("You wake up in an empty house, lost and confused. Pick your next steps",
   new() {("Go towards the front door to explore outside", "outside")
   ("Stay inside and explore the house a bit", "inside")})

    ["outside"] = new("you get shot and explode and die", new())
    ["inside"] = new("you get stabbed and then get served a tasty steak dinner that you cant enjoy because youre freaking dead", new())

};

string current = "start";

while (true)
{
    var scene = story[current];
    Console.WriteLine($"\n {scene.Choices}");
    if (scene.Choices.Count == 0) break;
    for (int i = 0; i < scene.Choices.Count; i++) Console.WriteLine($"{i+1}. {scene.Choices[i].Label} ");
    Console.Write("> ");
    if (int.TryParse(Console.ReadLine(), out int pick) &&
        pick >= 1 && pick <= scene.Choices.Count)
    {
        current = scene.Choices[pick - 1].Next;
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}

record Scene (string Text, List<(string Label, string Next)> Choices);

