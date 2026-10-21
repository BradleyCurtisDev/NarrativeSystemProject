using System;
using System.Collections.Generic;

var story = new Dictionary<string, Scene>
{
  ["start"] = new Scene("Years ago, you signed up to be a backup lighthouse keeper as a joke but you recently got a call asking you to go and check on the lighthouse just offshore of your home town. The current keeper hasnt responded to calls and checkins for the last week. (Pick your choices, the story changes based on your decisions) ",
   new List<(string Label, string Next)>
    {
    ("Accept the call, pack your bags and head to the lighthouse tomorrow afternoon", "accept"),
    ("Refuse the offer. It was meant as a joke after all.", "decline")
    }),

    ["accept"] = new Scene("You have arrived at the lighthouse. The air is cold and visibility is low but you see that the lamp is still lit.", new List<(string Label, string Next)>()
    {
        ("Go inside.", "inside"),
        ("Look around outside", "outside")
    }),

    ["decline"] = new Scene("You refuse the offer request given to you on the phone but you cant help but think what could have happened to the current keeper.", new List<(string Label, string Next)>()
    {
        ("Make your way to the lighthouse anyway and check it out.", "accept"),
        ("Try forget about it and move on with your life", "ending1")
    }),

     ["ending1"] = new Scene("Every now and then before you fall asleep you look over and see the lighthouse flashing in the distance, assuming they got someone else to go instead of you. But it still doesn't feel right...", new List<(string Label, string Next)>()),

     ["outside"] = new Scene("A lap around the lighthouse doesnt show anything out of the ordinary but as you get back to the front door you see some loose papers next to a nearby rock.", new List<(string Label, string Next)>()
    {
        ("Inspect the papers", "outside papers"),
        ("Ignore them and go inside", "inside")
    }),

    ["outside papers"] = new Scene("Its pages from a diary, each page with different dates on them. They seem to be notes of what the keeper did that day.", new List<(string Label, string Next)>()
    {
        ("Pick them up and go inside", "inside"),
    }),

    ["inside"] = new Scene("The door opens with a deep creak and you step inside. The air is cold. You pack your bags down inside the room on the 2nd floor.", new List<(string Label, string Next)>()
    {
        ("Look around the room", "bedroom1"),
        ("Go up to the office to see if you can find the keeper", "office1")
    }),

        ["bedroom1"] = new Scene("The room is weirdly empty. The bed is made like nobody has ever slept in it, the closets are empty and there's no dust on any surface. Under the bed you see a page of what looks like a dated diary entry.", new List<(string Label, string Next)>()
    {
        ("Reach out under the bed and read the diary entry", "diary1"),
        ("Ignore it and go check out the office", "office1")
    }),

    ["diary1"] = new Scene("The page has yesterdays date on it but the writing is illegible, seems like the page was just scribbled on.", new List<(string Label, string Next)>()
    {
        ("Put the page down and go up to the office", "office1"),
    }),

    ["office1"] = new Scene("You go upstars to the office, it's also empty. Everything is neatly arranged and packed away except for a ledger, lying open on the desk.", new List<(string Label, string Next)>()
    {
        ("Inspect the ledger", "ledger1"),
    }),

        ["ledger1"] = new Scene("Its open on todays date, with writing on the page already. 'Today I finally arrived at the lighthouse but I haven't found anyone here YET...' ", new List<(string Label, string Next)>()
    {
        ("Continue reading", "ledger1.1"),
        ("Close the ledger", "endofdemo")
    }),

        ["ledger1.1"] = new Scene("The next line seems to be something that hasnt happened yet. 'I went down to the Engine Room but the fuel tank was still nearly full.'", new List<(string Label, string Next)>()
    {
        ("Check the Engine Room", "endofdemo"),
        ("Close the ledger", "endofdemo")
    }),

    ["endofdemo"] = new Scene("Thank you for playing my short narrative demo. I might add more in the future but since this was a short project I have left it here.", new List<(string Label, string Next)>()
    {
        ("Play Again", "start"),
        ("Close Game", "close")
    }),

    ["ending1"] = new Scene("Goodbye", new List<(string Label, string Next)>()),
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

