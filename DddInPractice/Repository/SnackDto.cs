using System;

using Dapper;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DddInPractice.Logic;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes

namespace DddInPractice.Repository
{
    [Table("Snack")]
    [AutoMap(typeof(Snack), ReverseMap = true)]
    internal class SnackDto
    {
        [Key]
        [SourceMember("Id")]
        public int SnackID { get; set; }
        public string Name { get; set; }
    }
}
