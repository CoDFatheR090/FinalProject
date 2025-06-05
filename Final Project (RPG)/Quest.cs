namespace Final_Project__RPG_
{
    class Quest
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
            Console.WriteLine($"{Title} - {Description}");
        }
    }

}