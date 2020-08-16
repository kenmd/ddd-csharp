using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using AutoMapper;
using DddInPractice.Logic;


namespace DddInPractice.Repository
{
    public class SnackRepository : IRepository<Snack>
    {
        private SqlConnection conn;
        private IMapper mapper;

        public SnackRepository(SqlConnection conn)
        {
            if (conn is null)
                throw new ArgumentNullException(nameof(conn));

            this.conn = conn;

            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            // mapping config using Attribute Mapping (c.f. SnackDto class)
            mapper = new MapperConfiguration(cfg => cfg.AddMaps("DddInPractice"))
                    .CreateMapper();
        }

        public async Task<Snack> GetById(int id)
        {
            var snackTable = await conn.GetAsync<SnackDto>(id).ConfigureAwait(false);

            return mapper.Map<Snack>(snackTable);
        }

        public async Task<Snack> Create(Snack entity)
        {
            var snackTable = mapper.Map<SnackDto>(entity);

            var newId = await conn.InsertAsync<SnackDto>(snackTable).ConfigureAwait(false);

            if (entity != null)
                entity.Id = newId.Value;

            return entity;
        }

        public async Task<Snack> Update(Snack entity)
        {
            var snackTable = mapper.Map<SnackDto>(entity);

            var rowsAffected = await conn.UpdateAsync<SnackDto>(snackTable).ConfigureAwait(false);

            return (rowsAffected == 1) ? entity : null;
        }

        public async Task<bool> Delete(int id)
        {
            var rowsAffected = await conn.DeleteAsync<SnackDto>(id).ConfigureAwait(false);

            return rowsAffected == 1;
        }
    }
}
