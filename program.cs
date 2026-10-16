using System;
using System.Collections.Generic;

var story = new Dictionary<string, Scene>
{
  ["start"] = new("You wake up in an empty house, lost and confused. Pick your next steps",
   new() {("Go towards the front door to explore outside", "outside")
   ("Stay inside and explore the house a bit", "inside")})

    ["outside"] = new("you get shot and explode and die")
    ["inside"] = new("you get stabbed and then get served a tasty steak dinner that you cant enjoy because youre freaking dead")

};

string current = "start";

while (true)
{
    var Scene = story[current];
    Console.WriteLine("working up to here?");
    if (Scene.Choices.Count == 0) break;
    for (int i = 0; i < Scene.Choices.Count; i++) Console.WriteLine("hi");
};

record Scene (string Text, List<(string Label, string Next)> Choices);

