using System;
using Xunit;
using FluentAssertions;

using Microsoft.Data.SqlClient;

using DddInPractice.Logic;
using static DddInPractice.Logic.Money;
using DddInPractice.Repository;


namespace DddInPractice.Tests
{
    public class DataMapperSpecs
    {
        [Fact]
        public void TestMapper()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Cent);
            snackMachine.InsertMoney(Dollar);

            using (SqlConnection conn = Connection.GetConnection())
            {
                var mapper = new SnackMachineDataMapper(conn);
                var x = mapper.Create(snackMachine).Result;

                x.Should().NotBe(null);

                var y = mapper.GetById((int)x.Id).Result;

                y.MoneyInside.OneCentCount.Should().Be(1);

                y.ReturnMoney();
                y.InsertMoney(TwentyDollar);

                var z = mapper.Update((int)y.Id, y).Result;

                z.MoneyInside.OneCentCount.Should().Be(0);
                z.MoneyInside.TwentyDollarCount.Should().Be(1);

                var zz = mapper.Delete((int)z.Id).Result;

                zz.Should().Be(true);
            }
        }
    }
}
