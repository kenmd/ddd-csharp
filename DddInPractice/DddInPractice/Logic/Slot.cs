
namespace DddInPractice.Logic
{
    public class Slot : Entity
    {
        public SnackPile SnackPile { get; set; }
        public SnackMachine SnackMachine { get; }
        public int Position { get; }

        protected Slot() { }

        public Slot(SnackMachine snackMachine, int position) : this()
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = SnackPile.Empty;
        }
    }
}
