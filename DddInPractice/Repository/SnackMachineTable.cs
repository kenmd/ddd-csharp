using System;

using Dapper;

namespace DddInPractice.Repository
{
    [Table("SnackMachine")]
    public class SnackMachineTable
    {
        [Key]
        public long SnackMachineID { get; set; }
        public int OneCentCount { get; set; }
        public int TenCentCount { get; set; }
        public int QuarterCount { get; set; }
        public int OneDollarCount { get; set; }
        public int FiveDollarCount { get; set; }
        public int TwentyDollarCount { get; set; }
    }
}
