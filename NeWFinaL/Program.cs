

namespace Final_Project__RPG_
{

   
    class Game
    {
        static Player hero; 
        static List<NPC> npcs = new List<NPC>(); 
        static List<Boss> bosses = new List<Boss>(); 
        static List<Quest> quests = new List<Quest>(); 

       
        static void Main()
        {
            Console.Title = "Echoes of the Fallen Gods";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--- Echoes of the Fallen Gods ---");
            Console.ResetColor();
            Console.WriteLine("A war beyond time shattered the divine order...\n");

            
            hero = new Player("Last Herald", 100, 25);
            SetupGameWorld();
           
            while (hero.Health > 0) 
            {
                Console.WriteLine("\n--- Choose your next action: ---");
                Console.WriteLine("1. Explore the Ruins (Find items)");
                Console.WriteLine("2. Talk to an NPC (Gather lore and hints)");
                Console.WriteLine("3. Fight a Fallen Lord (Engage in battle)");
                Console.WriteLine("4. Check Inventory (View your possessions)");
                Console.WriteLine("5. Consume Forbidden Flesh (Gain power, but at a cost)");
                Console.WriteLine("6. View Quests (Remember your purpose)");
                Console.WriteLine("7. Exit Game (End your journey)");

                Console.Write("Your choice: ");
                string choice = Console.ReadLine();
                Console.Clear(); 

                switch (choice)
                {
                    case "1": ExploreRuins(); break;
                    case "2": SpeakWithNPC(); break;
                    case "3": FightBoss(); break;
                    case "4": hero.Inventory.ShowInventory(); break;
                    case "5": hero.ConsumeForbiddenFlesh(); break;
                    case "6": ViewQuests(); break;
                    case "7":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You Pathetic Human... The echoes will consume you regardless.");
                        Console.ResetColor();
                        return; 
                    default:
                        Console.WriteLine("Invalid choice, Cinderborn. Your mind wanders.");
                        break;
                }
            }
            Console.WriteLine("\n--- Game Over ---");
            Console.WriteLine("Press any key to close the console.");
            Console.ReadKey();
        }

       
        static void SetupGameWorld()
        {
            
            npcs.Add(new NPC("Prophet of Echoroot", "The gods were never meant to rule, merely to exist. Their ambition shattered more than just the veil."));
            npcs.Add(new NPC("Priest of the Lost Pantheon", "You are already one of them, a shard of divinity. You just don’t remember... yet."));
            npcs.Add(new NPC("Scribe of the Undying Texts", "The true history is written in blood and silence. Seek the ancient tablets."));

            
            bosses.Add(new Boss("Valkhazar, the God-Eater", 300));
            bosses.Add(new Boss("Severed King Anukor", 250));
            bosses.Add(new Boss("Ishra, the Burning Oracle", 220));
            bosses.Add(new Boss("The Blighted Colossus", 350));
            bosses.Add(new Boss("Whispering Wraith Lord", 180));
            bosses.Add(new Boss("Corrupted Architect", 280));


           
            quests.Add(new Quest("The Maw's Echo", "Find the Echoing Shards and uncover the truth of the imprisoned deity. The whispers grow louder with each shard."));
            quests.Add(new Quest("The Severed Prophecy", "Recover the lost prophecy fragments to rewrite destiny, before the threads of fate unravel completely."));
            quests.Add(new Quest("The Betrayed Architect", "Unmask the unknown traitor who orchestrated the Fall of the Pantheon. Their shadow still lingers."));
            quests.Add(new Quest("The Verdant Rot", "Cleanse the ancient groves of the Bleakwood where the blight first took root."));
            quests.Add(new Quest("Echoes of the Elder Runes", "Decipher the cryptic inscriptions found in forgotten tombs to unlock a hidden path."));
            quests.Add(new Quest("The Sunken City's Lament", "Retrieve the tears of the forgotten sea god from the abyssal depths, guarded by maddened leviathans."));


            
            hero.Inventory.AddItem(new Item("Fragment of Nyxfang", "A sharp shard from the ruins where the Last Herald awoke, humming with residual power."));
            hero.Inventory.AddItem(new Item("Tattered Codex Page", "A brittle page, speaking of forbidden knowledge and ancient rituals."));
        }

        
        static void ExploreRuins()
        {
            Console.WriteLine("\nYou wander through the desolate ruins, dust motes dancing in the fractured light.");
            Console.WriteLine("Shattered temples whisper the echoes of fallen gods, their despair palpable.");
            Console.WriteLine("Amidst the debris, you find a smoldering ember.");
            hero.Inventory.AddItem(new Item("Burning Oracle's Ember", "A smoldering ember, still whispering prophecies of a fiery end."));
        }

        
        static void SpeakWithNPC()
        {
            Console.WriteLine("\n--- Who will you seek counsel from? ---");
            for (int i = 0; i < npcs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {npcs[i].Name}");
            }
            Console.Write("Enter the number of the NPC: ");

            
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= npcs.Count)
            {
                npcs[index - 1].Speak(); 
            }
            else
            {
                Console.WriteLine("Invalid choice, the voices you sought remain silent.");
            }
        }

        
        static void FightBoss()
        {
            Console.WriteLine("\n--- Choose a Fallen Lord to challenge: ---");
            for (int i = 0; i < bosses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {bosses[i].Name} (Health: {bosses[i].Health})");
            }
            Console.Write("Enter the number of the Fallen Lord: ");

            
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= bosses.Count)
            {
                Boss boss = bosses[index - 1]; 
                Console.WriteLine($"\nYou stand before {boss.Name}. The air crackles with ancient power!");

                
                while (hero.Health > 0 && boss.Health > 0)
                {
                    Console.WriteLine($"\n--- Combat Round ---");
                    Console.WriteLine($"{hero.Name} Health: {hero.Health} | {boss.Name} Health: {boss.Health}");
                    Console.Write("Press Enter to attack: ");
                    Console.ReadLine(); 

                    hero.Attack(boss); 

                   
                    if (boss.Health > 0)
                    {
                        boss.Attack(hero);
                    }
                }

                
                if (hero.Health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{boss.Name} is defeated! The echoes of their power fade into the void.");
                    Console.ResetColor();
                }
                else
                {
                    
                    Console.WriteLine("\nYou have fallen. Your journey ends here.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice, Cinderborn. The Fallen Lords remain undisturbed.");
            }
        }

        
        static void ViewQuests()
        {
            Console.WriteLine("\n--- Your Current Quests ---");
            if (quests.Count == 0)
            {
                Console.WriteLine("No quests burden your soul. Perhaps you've forgotten your purpose?");
                return;
            }
            foreach (var quest in quests)
            {
                quest.DisplayQuest();
            }
            Console.WriteLine("--------------------------");
        }
    }
}
