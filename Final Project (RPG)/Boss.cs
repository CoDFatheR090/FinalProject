namespace Final_Project__RPG_
{
    class Boss
    {
        public string Name { get; }
        public int Health { get; private set; }
        private Random random = new Random();

        public Boss(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"\n{Name} unleashes a devastating attack!");
            player.TakeDamage(40);
        }

        public void TakeDamage(int baseDamage)
        {
            int finalDamage = baseDamage;
            if (random.Next(1, 6) == 1)
            {
                finalDamage *= 3;
                Console.WriteLine("\nDivine Judgment! The echoes of fate unleash spectral annihilation!");
            }

            Health -= finalDamage;
            Console.WriteLine($"{Name} suffers {finalDamage} damage. Remaining health: {Health}");
        }
    }

}