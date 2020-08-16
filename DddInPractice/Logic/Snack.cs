using System.Collections.Generic;


namespace DddInPractice.Logic
{
    /// <summary>
    /// Snack data is predefined (called Reference Data)
    /// </summary>
    public class Snack : AggregateRoot
    {
        public static readonly Snack None = new Snack(0, "None");
        public static readonly Snack Chocolate = new Snack(1, "Chocolate");
        public static readonly Snack Soda = new Snack(2, "Soda");
        public static readonly Snack Gum = new Snack(3, "Gum");

        public static Dictionary<int, Snack> SnackMap => new Dictionary<int, Snack>{
            {1, Chocolate},
            {2, Soda},
            {3, Gum},
        };

        public string Name { get; set; }

        protected Snack() { }

        private Snack(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
