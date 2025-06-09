namespace Final_Project__RPG_
{
    public class Player
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int AttackPower { get; }
        public int MadnessLevel { get; private set; } 
        public Inventory Inventory { get; } 

        
        public Player(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            MadnessLevel = 0; 
            Inventory = new Inventory();
        }

        public void Attack(Boss boss)
        {
            Console.WriteLine($"\n{Name} strikes {boss.Name}, dealing {AttackPower} damage!");
            boss.TakeDamage(AttackPower);
        }

        
        public void ConsumeForbiddenFlesh()
        {
            MadnessLevel += 10;
            Health += 10; 
            Console.WriteLine($"\n{Name} devours forbidden flesh... Health slightly recovers. Madness level rises to {MadnessLevel}!");

            if (MadnessLevel >= 50)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Madness overwhelms you! Reality fractures, and your mind reels from the echoes!");
                Console.ResetColor();
                TakeDamage(20); 
            }
        }

        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} now has {Health} health remaining.");
            if (Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} has been consumed by the echoes of the Fallen Gods...");
                Console.ResetColor();
            }
        }
    }
}
