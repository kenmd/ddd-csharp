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

        public IReadOnlyList<SnackPile> GetAllSnackPiles()
        {
            return Slots.OrderBy(x => x.Position)
                    .Select(x => x.SnackPile).ToList();
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

        public string CanBuySnack(int position)
        {
            SnackPile snackPile = GetSnackPile(position);

            if (snackPile.Quantity == 0)
                return "The snack pile is empty";

            if (MoneyInTransaction < snackPile.Price)
                return "Not enough money";

            if (!MoneyInside.CanAllocate(MoneyInTransaction - snackPile.Price))
                return "Not enough change";

            return string.Empty; // validation passed
        }

        public void BuySnack(int position)
        {
            if (CanBuySnack(position).Length != 0)
                throw new InvalidOperationException();

            Slot slot = GetSlot(position);
            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
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

        public void UnLoadMoney(Money money)
        {
            MoneyInside -= money;
        }
    }
}
