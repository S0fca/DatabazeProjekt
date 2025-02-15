namespace Mineraly.UserInterface
{
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

        public void Execute()
        {
            action();
        }
    }
}
