namespace Final_Project__RPG_
{
    class Game //List of items
    {
        static Player hero;
        static List<NPC> npcs = new List<NPC>();
        static List<Boss> bosses = new List<Boss>();
        static List<Quest> quests = new List<Quest>();

        static void Main()
        {
            Console.WriteLine("Echoes of the Fallen Gods");
            Console.WriteLine("A war beyond time shattered the divine order...\n");

            hero = new Player("Last Herald", 100, 25);
            SetupGameWorld();

            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Explore the ruins");
                Console.WriteLine("2. Talk to an NPC");
                Console.WriteLine("3. Fight a Fallen Lord");
                Console.WriteLine("4. Check inventory");
                Console.WriteLine("5. Consume forbidden flesh");
                Console.WriteLine("6. View quests");
                Console.WriteLine("7. Exit game");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ExploreRuins(); break;
                    case "2": SpeakWithNPC(); break;
                    case "3": FightBoss(); break;
                    case "4": hero.Inventory.ShowInventory(); break;
                    case "5": hero.ConsumeForbiddenFlesh(); break;
                    case "6": ViewQuests(); break;
                    case "7": Console.WriteLine("You Pathetic Human..."); return;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }
            }
        }

        static void SetupGameWorld()
        {
            npcs.Add(new NPC("Prophet of Echoroot", "The gods were never meant to rule..."));
            npcs.Add(new NPC("Priest of the Lost Pantheon", "You are already one of them. You just don’t remember."));

            bosses.Add(new Boss("Valkhazar, the God-Eater", 300));
            bosses.Add(new Boss("Severed King Anukor", 250));
            bosses.Add(new Boss("Ishra, the Burning Oracle", 220));

            quests.Add(new Quest("The Maw's Echo", "Find the Echoing Shards and uncover the truth of the imprisoned deity."));
            quests.Add(new Quest("The Severed Prophecy", "Recover the lost prophecy fragments to rewrite destiny."));
            quests.Add(new Quest("The Betrayed Architect", "Unmask the unknown traitor who orchestrated the Fall."));

            hero.Inventory.AddItem(new Item("Fragment of Nyxfang", "A shard from the ruins where the Last Herald awoke."));
            hero.Inventory.AddItem(new Item("Severed King's Crown", "The shattered remains of Anukor's cursed monarchy."));
        }

        static void ExploreRuins()
        {
            Console.WriteLine("\nYou wander through the ruins...");
            Console.WriteLine("Shattered temples whisper the echoes of fallen gods.");
            Console.WriteLine("You find a Burning Oracle's Ember.");
            hero.Inventory.AddItem(new Item("Burning Oracle's Ember", "A smoldering ember, still whispering prophecies."));
        }

        static void SpeakWithNPC()
        {
            Console.WriteLine("\nChoose an NPC:");
            for (int i = 0; i < npcs.Count; i++)
                Console.WriteLine($"{i + 1}. {npcs[i].Name}");

            int index;
            if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= npcs.Count)
                npcs[index - 1].Speak();
            else
                Console.WriteLine("Invalid choice.");
        }

        static void FightBoss()
        {
            Console.WriteLine("\nChoose a Fallen Lord to battle:");
            for (int i = 0; i < bosses.Count; i++)
                Console.WriteLine($"{i + 1}. {bosses[i].Name}");

            int index;
            if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= bosses.Count)
            {
                Boss boss = bosses[index - 1];
                while (hero.Health > 0 && boss.Health > 0)
                {
                    hero.Attack(boss);
                    if (boss.Health > 0) boss.Attack(hero);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void ViewQuests()
        {
            Console.WriteLine("\nCurrent quests:");
            foreach (var quest in quests)
                quest.DisplayQuest();
        }
    }

}