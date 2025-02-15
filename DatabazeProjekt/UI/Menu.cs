namespace Mineraly.UserInterface
{
    public class Menu
    {
        private string menuCaption { get; init; }
        private List<MenuItem> menuItems = new List<MenuItem>();

        public Menu(string menuCaption)
        {
            this.menuCaption = menuCaption;
        }
        public void WriteMenuItems()
        {
            Console.WriteLine(menuCaption);
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
            }
        }

        public MenuItem? GetSelection()
        {
            int selectionID;
            string input = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(input, out selectionID))
            {
                Console.Error.WriteLine($"Invalid input: '{input}'. Please enter a number.");
                return null;
            }

            if (selectionID < 1 || selectionID > menuItems.Count)
            {
                Console.Error.WriteLine($"Invalid choice: {selectionID}. Please select a number between 1 and {menuItems.Count}.");
                return null;
            }

            return menuItems[selectionID - 1];
        }

        public MenuItem GetMenuItem()
        {
            MenuItem item = null;
            do
            {
                WriteMenuItems();
                item = GetSelection();
            } while (item == null);

            return item;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            menuItems.Add(menuItem);
        }
    }
}
