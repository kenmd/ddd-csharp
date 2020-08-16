using System;
using Xunit;
using FluentAssertions;

using Microsoft.Data.SqlClient;

using DddInPractice.Logic;
using static DddInPractice.Logic.Money;
using static DddInPractice.Logic.Snack;
using DddInPractice.Repository;


namespace DddInPractice.Tests
{
    public class DataMapperSpecs
    {
        [Fact]
        public void TestMapper()
        {
            // Given
            var snackMachine = new SnackMachine();
            var snackPile = new SnackPile(Chocolate, 2, 1);
            snackMachine.LoadSnacks(1, snackPile);

            using (SqlConnection conn = Connection.GetConnection())
            {
                var repository = new SnackMachineRepository(conn);

                // When
                snackMachine.InsertMoney(Cent);
                snackMachine.InsertMoney(Dollar);
                var x = repository.Create(snackMachine).Result;

                // Then
                x.Should().NotBe(null);

                // Check DB
                var y = repository.GetById(snackMachine.Id).Result;

                y.MoneyInside.OneCentCount.Should().Be(1);
                y.MoneyInside.TenCentCount.Should().Be(0);
                y.MoneyInside.OneDollarCount.Should().Be(1);
                y.MoneyInside.TwentyDollarCount.Should().Be(0);

                // When
                snackMachine.ReturnMoney();
                snackMachine.InsertMoney(TwentyDollar);
                var x2 = repository.Update(snackMachine).Result;

                // Then
                x2.Should().NotBe(null);

                // Check DB
                var z = repository.GetById(snackMachine.Id).Result;

                z.MoneyInside.OneCentCount.Should().Be(0);
                z.MoneyInside.TenCentCount.Should().Be(0);
                z.MoneyInside.OneDollarCount.Should().Be(0);
                z.MoneyInside.TwentyDollarCount.Should().Be(1);

                // Clean up
                var x3 = repository.Delete(snackMachine.Id).Result;

                x3.Should().Be(true);
            }
        }

        [Fact]
        public void TestSnackMachine()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                // Given
                int snackMachineId = 1;
                int position = 1;
                var repository = new SnackMachineRepository(conn);
                var snackMachine = repository.GetById(snackMachineId).Result;

                // When
                snackMachine.InsertMoney(Dollar);
                snackMachine.InsertMoney(Dollar);
                snackMachine.InsertMoney(Dollar);
                snackMachine.BuySnack(position);
                var res = repository.Update(snackMachine).Result;

                // Then
                snackMachine.MoneyInside.OneDollarCount.Should().Be(4);
                snackMachine.GetSnackPile(position).Quantity.Should().Be(9);

                // Check DB
                var x = repository.GetById(snackMachineId).Result;
                x.MoneyInside.OneDollarCount.Should().Be(4);
                x.GetSnackPile(position).Quantity.Should().Be(9);

                // Clean up
                snackMachine.UnLoadMoney(Dollar * 3);
                snackMachine.LoadSnacks(position, new SnackPile(Chocolate, 10, 3));

                snackMachine.MoneyInside.OneDollarCount.Should().Be(1);
                snackMachine.GetSnackPile(position).Quantity.Should().Be(10);

                var res2 = repository.Update(snackMachine).Result;

                // Check DB
                var x3 = repository.GetById(snackMachineId).Result;
                x3.MoneyInside.OneDollarCount.Should().Be(1);
                x3.GetSnackPile(position).Quantity.Should().Be(10);
            }
        }
    }
}
