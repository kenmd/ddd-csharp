﻿using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using DddInPractice.Logic;

namespace DddInPractice.Repository
{
    public class SnackMachineDataMapper : IDataMapper<SnackMachine>
    {
        private SqlConnection conn;

        public SnackMachineDataMapper(SqlConnection conn)
        {
            this.conn = conn;
        }

        public async Task<SnackMachine> Create(SnackMachine entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (this.conn.State == ConnectionState.Closed)
                await conn.OpenAsync().ConfigureAwait(false);

            var newId = await conn.InsertAsync<SnackMachineTable>(new SnackMachineTable
            {
                OneCentCount = entity.MoneyInTransaction.OneCentCount,
                TenCentCount = entity.MoneyInTransaction.TenCentCount,
                QuarterCount = entity.MoneyInTransaction.QuarterCount,
                OneDollarCount = entity.MoneyInTransaction.OneDollarCount,
                FiveDollarCount = entity.MoneyInTransaction.FiveDollarCount,
                TwentyDollarCount = entity.MoneyInTransaction.TwentyDollarCount,
            }).ConfigureAwait(false);

            entity.Id = (long)newId;

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            if (this.conn.State == ConnectionState.Closed)
                await conn.OpenAsync().ConfigureAwait(false);

            var res = await conn.DeleteAsync<SnackMachineTable>(id)
                            .ConfigureAwait(false);

            return res == 1;
        }

        public async Task<SnackMachine> GetById(int id)
        {
            if (this.conn.State == ConnectionState.Closed)
                await conn.OpenAsync().ConfigureAwait(false);

            var res = await conn.GetAsync<SnackMachineTable>(id)
                            .ConfigureAwait(false);

            if (res == null)
                return null;

            return new SnackMachine()
            {
                Id = res.SnackMachineID,
                MoneyInTransaction = new Money(
                    res.OneCentCount,
                    res.TenCentCount,
                    res.QuarterCount,
                    res.OneDollarCount,
                    res.FiveDollarCount,
                    res.TwentyDollarCount)
            };
        }

        public async Task<SnackMachine> Update(int id, SnackMachine entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (this.conn.State == ConnectionState.Closed)
                await conn.OpenAsync().ConfigureAwait(false);

            var snackMachine = new SnackMachineTable()
            {
                SnackMachineID = id,
                OneCentCount = entity.MoneyInTransaction.OneCentCount,
                TenCentCount = entity.MoneyInTransaction.TenCentCount,
                QuarterCount = entity.MoneyInTransaction.QuarterCount,
                OneDollarCount = entity.MoneyInTransaction.OneDollarCount,
                FiveDollarCount = entity.MoneyInTransaction.FiveDollarCount,
                TwentyDollarCount = entity.MoneyInTransaction.TwentyDollarCount,
            };

            var res = await conn.UpdateAsync<SnackMachineTable>(snackMachine)
                            .ConfigureAwait(false);

            if (res == 1)
                return entity;
            else
                return null;
        }
    }
}