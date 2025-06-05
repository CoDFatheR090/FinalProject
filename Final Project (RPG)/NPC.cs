namespace Final_Project__RPG_
{
    class NPC
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
            Console.WriteLine($"\n{Name}: \"{Dialogue}\"");
        }
    }

}