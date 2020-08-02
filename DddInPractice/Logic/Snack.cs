
namespace DddInPractice.Logic
{
    public class Snack : AggregateRoot
    {
        public string Name { get; set; }

        protected Snack() { }

        public Snack(string name) : this()
        {
            Name = name;
        }
    }
}
