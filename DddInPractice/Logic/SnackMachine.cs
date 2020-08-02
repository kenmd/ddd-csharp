using System;
using System.Collections.Generic;
using System.Linq;
using static DddInPractice.Logic.Money;


namespace DddInPractice.Logic
{
    /// <summary>
    /// Entity in DDD
    /// </summary>
    public sealed class SnackMachine : AggregateRoot
    {
        // note this is mutable
        public Money MoneyInside { get; set; }
        public decimal MoneyInTransaction { get; set; }
        private IList<Slot> Slots { get; }

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = 0;

            Slots = new List<Slot>{
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3),
            };
        }

        public SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public void InsertMoney(Money money)
        {
            if (money is null)
                throw new ArgumentNullException(nameof(money));

            Money[] coinsAndNotes = {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };

            // stop using more than one coint at a time
            // inserting money need to be one of these coinsAndNotes
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public void ReturnMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public void BuySnack(int position)
        {
            Slot slot = GetSlot(position);

            if (slot.SnackPile.Price > MoneyInTransaction)
                throw new InvalidOperationException();

            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);

            if (change.Amount < MoneyInTransaction - slot.SnackPile.Price)
                throw new InvalidOperationException();

            MoneyInside -= change;
            MoneyInTransaction = 0;
        }

        public void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}
