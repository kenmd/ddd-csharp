using System;

using Dapper;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes

namespace DddInPractice.Repository
{
    [Table("SnackMachine")]
    internal class SnackMachineDto
    {
        [Key]
        public int SnackMachineID { get; set; }
        public int OneCentCount { get; set; }
        public int TenCentCount { get; set; }
        public int QuarterCount { get; set; }
        public int OneDollarCount { get; set; }
        public int FiveDollarCount { get; set; }
        public int TwentyDollarCount { get; set; }
    }
}
