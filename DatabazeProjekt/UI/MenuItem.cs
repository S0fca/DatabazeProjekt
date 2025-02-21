namespace Mineraly.UserInterface
{
    /// <summary>
    /// Menu items class, handles menu items and their actions
    /// </summary>
    /// Taken from Moodle
    public class MenuItem
    {
        private string description;
        private Action action;

        public MenuItem(string popis, Action akce)
        {
            description = popis;
            action = akce;
        }

        public override string ToString()
        {
            return description;
        }

        /// <summary>
        /// Executes menu items action
        /// </summary>
        public void Execute()
        {
            action();
        }
    }
}
