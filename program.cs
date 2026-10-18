using System;
using System.Collections.Generic;

var story = new Dictionary<string, Scene>
{
  ["start"] = new Scene("You wake up in an empty house, lost and confused. Pick your next steps",
   new List<(string Label, string Next)>
    {
    ("Go towards the front door to explore outside", "outside"),
    ("Stay inside and explore the house a bit", "inside")
    }),

    ["outside"] = new Scene("you get shot and explode and die", new List<(string Label, string Next)>()),

    ["inside"] = new Scene("you get stabbed and then get served a tasty steak dinner that you cant enjoy because youre freaking dead", new List<(string Label, string Next)>()
    {
        ("Do you want to revive and go outside", "outside"),
        ("Stay Dead", "start")
    }),

};

string current = "start";

while (true)
{
    var scene = story[current];
    Console.WriteLine($"\n {scene.Text}");
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

