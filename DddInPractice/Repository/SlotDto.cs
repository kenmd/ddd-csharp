using System;

using Dapper;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes

namespace DddInPractice.Repository
{
    [Table("Slot")]
    internal class SlotDto
    {
        [Key]
        public int SlotID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SnackID { get; set; }
        public int SnackMachineID { get; set; }
        public int Position { get; set; }
    }
}
