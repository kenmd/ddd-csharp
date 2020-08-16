using Xunit;
using FluentAssertions;

using Microsoft.Data.SqlClient;

using DddInPractice.Logic;
using DddInPractice.Repository;


namespace DddInPractice.Tests
{
    public class SnackRepositorySpecs
    {
        [Fact(Skip = "this test is for demo AutoMapper")]
        public void Snack_CRUD_Test()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                var repo = new SnackRepository(conn);

                // Given
                var snack = Snack.SnackMap[1];
                // a little hack for private Snack constructor
                snack.Id = 0; // 0 is required to insert with new ID
                snack.Name = "Foo";

                // When
                var created = repo.Create(snack).Result;

                // Then
                created.Id.Should().Be(snack.Id);
                created.Name.Should().Be("Foo");

                var snackInDB = repo.GetById(created.Id);
                snackInDB.Result.Name.Should().Be("Foo");

                // When 2
                snack.Name = "Bar";
                var updated = repo.Update(snack).Result;

                // Then 2
                updated.Id.Should().Be(snack.Id);
                updated.Name.Should().Be("Bar");

                var snackInDB2 = repo.GetById(created.Id);
                snackInDB2.Result.Name.Should().Be("Bar");

                // Clean up
                var res = repo.Delete(created.Id);
                res.Result.Should().Be(true);
            }
        }
    }
}
