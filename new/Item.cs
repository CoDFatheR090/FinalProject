namespace Final_Project__RPG_

{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"- {Name}: {Description}");
        }
    }
}