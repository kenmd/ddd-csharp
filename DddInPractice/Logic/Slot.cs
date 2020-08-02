
namespace DddInPractice.Logic
{
    public class Slot : Entity
    {
        public SnackPile SnackPile { get; set; }
        public SnackMachine SnackMachine { get; set; }
        public int Position { get; set; }

        protected Slot() { }

        public Slot(SnackMachine snackMachine, int position) : this()
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = new SnackPile(null, 0, 0);
        }
    }
}
