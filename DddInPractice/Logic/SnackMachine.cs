using System;
using System.Linq;
using static DddInPractice.Logic.Money;


namespace DddInPractice.Logic
{
    /// <summary>
    /// Entity in DDD
    /// </summary>
    public sealed class SnackMachine : Entity
    {
        // note this is mutable
        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };

            // stop using more than one coint at a time
            // inserting money need to be one of these coinsAndNotes
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
