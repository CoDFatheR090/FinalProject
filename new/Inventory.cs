namespace Final_Project__RPG_

{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"You found a {item.Name} and added it to your inventory.");
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n--- Your Inventory ---");
            if (items.Count == 0)
            {
                Console.WriteLine("It is empty, save for the echoes of your past.");
                return;
            }
            foreach (var item in items)
            {
                item.ShowInfo();
            }
            Console.WriteLine("--------------------");
        }
    }
}