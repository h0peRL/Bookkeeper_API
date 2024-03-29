﻿using System.ComponentModel.DataAnnotations.Schema;
using Bookkeeper_API.Data;

namespace Bookkeeper_API.Model
{
    public abstract class Account
    {
        // Suppression is needed here so you're forced to use initializer injection when
        // setting the data repository on initialization.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Account(int id, string accountName)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Id = id;
            AccountName = accountName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// The Entity Framework requires an empty constructor. Please do not remove it.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Account()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public int Id { get; private set; }

        public string AccountName { get; private set; }

        [NotMapped]
        required public IDataRepository DataRepository { get; init; }

        public abstract decimal CalculateBalance();

        public abstract void DoDebitBooking(decimal amount);

        public abstract void DoCreditBooking(decimal amount);
    }
}
