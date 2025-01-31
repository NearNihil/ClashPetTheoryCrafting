using System.Text;

namespace ClashPetTheoryCrafting
{
    internal class Program
    {
        private static Dictionary<string, int> summonerPointLimits = new()
        {
            { "Lightspeaker", 100 },
            { "Elementalist", 100 },
            { "Lich", 100 },
            { "Wyrm Master", 100 }
        };

        private static Dictionary<string, int> petGroupLimits = new()
        {
            { "Titan", 1 },
            { "LS-Soldiers", 10 },
            { "LS-Sprites", 5 },
            { "Ele-Cirri", 6 },
            { "Ele-Sylph", 3 },
            { "Ele-Hurricane", 1 },
            { "Ele-Ember", 6 },
            { "Ele-Salamander", 3 },
            { "Ele-Phoenix", 1 },
            { "Ele-Gnome", 6 },
            { "Ele-Golem", 3 },
            { "Ele-Jugg", 1 },
            { "Ele-Naiad", 6 },
            { "Ele-Undine", 3 },
            { "Ele-Hydro", 1 },
            { "Lich-Skelezombies", 10 },
            { "Lich-Lifesteal", 10 },
            { "WM-Soldiers", 15 },
            { "WM-Tentacles", 5 },
        };

        private static List<Pet> pets =
        [
            new("Foo Lion (Male)", "Lightspeaker", 25, 100, 40, 75, .6m, .15m, 12, 10, 1, "Utility", 20, summonerPointLimits["Lightspeaker"]),     // Lots of abilities
            new("Foo Lion (Female)", "Lightspeaker", 25, 100, 40, 75, .6m, .15m, 12, 10, 1, "Utility", 20, summonerPointLimits["Lightspeaker"]),
            new("Judgemaster", "Lightspeaker", 15, 110, 50, 80, .55m, 0m, 12, 2, 2, "LS-Soldiers", 8, summonerPointLimits["Lightspeaker"]),           // AA ability
            new("Wheel of Righteousness", "Lightspeaker", 25, 90, 70, 90, .7m, .15m, 12, 0, 1, "Titan", 50, summonerPointLimits["Lightspeaker"]),
            new("Aethersprite", "Lightspeaker", 7.5m, 90, 40, 20, .4m, .5m, 4, 10, 10, "LS-Sprites", 10, summonerPointLimits["Lightspeaker"]),         // Healing
            new("Cirri", "Elementalist", 10, 70, 30, 15, .55m, .25m, 10, 0, 6, "Ele-Cirri", 16, summonerPointLimits["Elementalist"]),
            new("Sylph", "Elementalist", 20, 80, 40, 45, .6m, .3m, 13, 2, 3, "Ele-Sylph", 33, summonerPointLimits["Elementalist"]),                  // AA
            new("Hurricane", "Elementalist", 25, 100, 50, 60, .7m, .35m, 16, 0, 1, "Ele-Hurricane", 100, summonerPointLimits["Elementalist"]),
            new("Ember", "Elementalist", 10, 70, 30, 15, .45m, .35m, 10, 0, 6, "Ele-Ember", 16, summonerPointLimits["Elementalist"]),
            new("Salamander", "Elementalist", 20, 80, 40, 45, .5m, .4m, 13, 0, 3, "Ele-Salamander", 33, summonerPointLimits["Elementalist"]),
            new("Phoenix", "Elementalist", 25, 100, 50, 65, .6m, .45m, 17, 0, 1, "Ele-Phoenix", 100, summonerPointLimits["Elementalist"]),
            new("Gnome", "Elementalist", 10, 70, 30, 15, .5m, .3m, 10, 0, 6, "Ele-Gnome", 16, summonerPointLimits["Elementalist"]),
            new("Golem", "Elementalist", 20, 80, 40, 45, .55m, .35m, 13, 0, 3, "Ele-Golem", 33, summonerPointLimits["Elementalist"]),
            new("Juggernaut", "Elementalist", 25, 100, 50, 75, .65m, .35m, 17, 0, 1, "Ele-Jugg", 100, summonerPointLimits["Elementalist"]),
            new("Naiad", "Elementalist", 10, 70, 30, 15, .6m, .2m, 11, 0, 6, "Ele-Naiad", 16, summonerPointLimits["Elementalist"]),
            new("Undine", "Elementalist", 20, 80, 40, 45, .65m, .25m, 13, 0, 3, "Ele-Undine", 33, summonerPointLimits["Elementalist"]),
            new("Hydrodragon", "Elementalist", 25, 100, 50, 70, .75m, .35m, 16, 0, 1, "Ele-Hydro", 100, summonerPointLimits["Elementalist"]),
            new("Skeleton", "Lich", 10, 120, 45, 40, .7m, .05m, 13, 0, 15, "Lich-Skelezombies", 15, summonerPointLimits["Elementalist"]),
            new("Ghoul", "Lich", 10, 100, 40, 60, .6m, 0m, 10, 0, 15, "Lich-Skelezombies", 15, summonerPointLimits["Elementalist"]),
            new("Fossil Monstrosity", "Lich", 30, 100, 80, 90, .65m, .10m, 15, 0, 1, "Titan", 50, summonerPointLimits["Elementalist"]),
            new("Necrophage", "Lich", 30, 100, 40, 60, .6m, 0m, 13, 0, 1, "Titan", 50, summonerPointLimits["Lich"]),
            new("Will-o-Wisp", "Lich", 15, 100, 20, 40, .5m, .05m, 6, 0, 10, "Lich-Lifesteal", 10, summonerPointLimits["Lich"]),
            new("Wight", "Lich", 20, 150, 35, 60, .6m, .0m, 12, 0, 15, "Lich-Lifesteal", 20, summonerPointLimits["Lich"]),
            new("Wraith", "Lich", 30, 50, 30, 30, .7m, .15m, 5, 10, 5, "Titan", 20, summonerPointLimits["Lich"]),                        // Spells, independence
            new("Hellhound", "Wyrm Master", 20, 130, 35, 90, .7m, .05m, 9, 0, 7, "WM-Soldiers", 12, summonerPointLimits["Wyrm Master"]),
            new("Horrid Tentacle", "Wyrm Master", 15, 160, 30, 45, .7m, .0m, 8, 5, 7, "WM-Tentacles", 15, summonerPointLimits["Wyrm Master"]),         // AA, MP drain
            new("Imp", "Wyrm Master", 15, 120, 35, 20, .55m, .1m, 5, 10, 7, "WM-Soldiers", 8, summonerPointLimits["Wyrm Master"]),                   // MP drain, abilities
            new("Wrackwyrm", "Wyrm Master", 30, 100, 65, 85, .75m, .1m, 12, 0, 1, "Titans", 50, summonerPointLimits["Wyrm Master"]),
        ];

        static void Main(string[] args)
        {
            StringBuilder sb = new();
            foreach (var pet in pets.OrderBy(x => x.SummonerClass).ThenBy(x => x.SummonCost).ThenBy(x => x.AverageDamagePerHit))
            {
                sb.AppendLine(pet.ToString(false));
                sb.AppendLine();

                Console.WriteLine(pet.ToString(true));
            }

            File.WriteAllText("C:/Temp/Pets.txt", sb.ToString());
        }
    }
}
