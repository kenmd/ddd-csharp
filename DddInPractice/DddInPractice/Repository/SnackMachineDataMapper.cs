using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using AutoMapper;
using DddInPractice.Logic;

namespace DddInPractice.Repository
{
    public class SnackMachineRepository : IRepository<SnackMachine>
    {
        private SqlConnection conn;
        private IMapper mapper;

        public SnackMachineRepository(SqlConnection conn)
        {
            if (conn is null)
                throw new ArgumentNullException(nameof(conn));

            this.conn = conn;

            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            mapper = new MapperConfiguration(cfg => cfg.AddProfile<SnackMachineProfile>()).CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        public async Task<SnackMachine> Create(SnackMachine entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            using (var tran = conn.BeginTransaction())
            {
                return await Create(entity, tran).ConfigureAwait(false);
            }
        }

        public async Task<SnackMachine> Update(SnackMachine entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            using (var tran = conn.BeginTransaction())
            {
                return await Update(entity, tran).ConfigureAwait(false);
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var tran = conn.BeginTransaction())
            {
                return await Delete(id, tran).ConfigureAwait(false);
            }
        }

        // ######################################################################

        public async Task<SnackMachine> GetById(int id)
        {
            var snackMachineTable = await conn.GetAsync<SnackMachineDto>(id).ConfigureAwait(false);

            var snackMachine = mapper.Map<SnackMachine>(snackMachineTable);

            // Auto Map MoneyInside but map SnackPile manually for simplicity
            // var snackMap = conn.GetList<SnackDto>()
            //         .ToDictionary(x => x.SnackID, x => new SnackDto());

            var slotTables = conn.GetListAsync<SlotDto>(new { SnackMachineID = id }).Result;

            foreach (var st in slotTables)
            {
                // Note: snackMachine use Position to identify its slot
                // (st.SlotID is used only for DB)
                snackMachine.LoadSnacks(
                    st.Position,
                    new SnackPile(
                        Snack.SnackMap[st.SnackID],
                        st.Quantity,
                        st.Price
                    )
                );
            }

            return snackMachine;
        }

        private async Task<SnackMachine> Create(SnackMachine entity, SqlTransaction tran)
        {
            var snackMachineTable = mapper.Map<SnackMachineDto>(entity);
            var newId = await conn.InsertAsync<SnackMachineDto>(snackMachineTable, tran).ConfigureAwait(false);

            foreach (int position in Enumerable.Range(1, 3))
            {
                var pile = entity.GetSnackPile(position);

                if (pile.Snack.Name == "None")
                    continue;

                var slot = new SlotDto()
                {
                    Quantity = pile.Quantity,
                    Price = pile.Price,
                    SnackID = pile.Snack.Id,
                    SnackMachineID = newId.Value,
                    Position = position
                };

                await conn.InsertAsync<SlotDto>(slot, tran).ConfigureAwait(false);
            }

            tran.Commit();
            entity.Id = newId.Value;

            return entity;
        }

        private async Task<SnackMachine> Update(SnackMachine entity, SqlTransaction tran)
        {
            var snackMachineTable = mapper.Map<SnackMachineDto>(entity);
            var rowsAffected = await conn.UpdateAsync<SnackMachineDto>(snackMachineTable, tran).ConfigureAwait(false);

            if (rowsAffected != 1)
                throw new ApplicationException();

            var slotTables = await conn.GetListAsync<SlotDto>(
                new { SnackMachineID = entity.Id }, tran).ConfigureAwait(false);

            foreach (var slot in slotTables)
            {
                var pile = entity.GetSnackPile(slot.Position);

                if (pile.Snack is null)
                {
                    await conn.DeleteAsync<SlotDto>(slot.SlotID, tran).ConfigureAwait(false);
                }
                else
                {
                    slot.SnackID = pile.Snack.Id;
                    slot.Quantity = pile.Quantity;
                    slot.Price = pile.Price;

                    await conn.UpdateAsync<SlotDto>(slot, tran).ConfigureAwait(false);
                }
            }

            tran.Commit();
            return entity;
        }

        private async Task<bool> Delete(int id, SqlTransaction tran)
        {
            var res = await conn.DeleteAsync<SnackMachineDto>(id, tran).ConfigureAwait(false);

            await conn.DeleteListAsync<SlotDto>(new { SnackMachineID = id }, tran).ConfigureAwait(false);

            tran.Commit();
            return res == 1;
        }

        // common possible methods sample
        // public IReadOnlyList<SnackMachine> GetAllWithSnack(Snack snack) {}
        // public IReadOnlyList<SnackMachine> GetAllWithMoneyInside(Money money) {}
    }
}
