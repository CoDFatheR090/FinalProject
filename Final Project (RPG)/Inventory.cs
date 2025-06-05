namespace Final_Project__RPG_
{
    class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item) => items.Add(item);

        public void ShowInventory()
        {
            Console.WriteLine("\nInventory:");
            foreach (var item in items)
            {
                item.ShowInfo();
            }
        }
    }

}