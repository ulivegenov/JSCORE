namespace _01EventImplementation.Models
{
    using Contracts;

    public class Dispatcher : INameChangeable, INameble
    {
        private string name;

        public Dispatcher(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            
            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public event NameChangeEventHandler NameChange;

        public void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
            {
                this.NameChange.Invoke(this, args);
            }
        }
    }
}
