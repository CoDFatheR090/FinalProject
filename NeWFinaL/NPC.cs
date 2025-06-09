

namespace Final_Project__RPG_
{
    public class NPC
    {
        public string Name { get; }
        public string Dialogue { get; }

        public NPC(string name, string dialogue)
        {
            Name = name;
            Dialogue = dialogue;
        }

        public void Speak()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n{Name}: \"{Dialogue}\"");
            Console.ResetColor();
        }
    }
}
