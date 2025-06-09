

namespace Final_Project__RPG_
{
    public class Quest
    {
        public string Title { get; }
        public string Description { get; }

        public Quest(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void DisplayQuest()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nQuest: {Title}");
            Console.ResetColor();
            Console.WriteLine($"Description: {Description}");
        }
    }
}
