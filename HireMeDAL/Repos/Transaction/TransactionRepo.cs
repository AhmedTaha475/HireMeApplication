﻿using HireMeDAL.Repos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    internal class TransactionRepo : ITransactionRepo
    {
        public HireMeContext Context { get; }
        public TransactionRepo(HireMeContext context)
        {
            Context = context;
        }



        // ======== this method to Get All Transaction ( !!!! for user or not ???) ========= //
        public IEnumerable<Transaction> GetAllTranscations( string userid)
        {
            var Transactions = Context.transactions.Where(t=>t.SystemUserId == userid).ToList();
            if (Transactions is null)
            {
                return new List<Transaction>();
            }
            else
                return Transactions;
        }

        // ======== this method to Get specific Transaction with id ( !!!! for user or not ???) ========= //
        public Transaction GetTransactionById(int id)
        {
            Transaction? transaction = Context.transactions.FirstOrDefault(t => t.TransactionId == id);
            if (transaction is null)
                return new Transaction();
            else
                return transaction;
        }

        // ======== this method to Update New Transaction  (for user ---> client or freelancer) ========= //
        public void UpdateTransaction(Transaction transaction, int id)
        {
            var updTransaction = Context.transactions.FirstOrDefault(t => t.TransactionId == id);

            if(updTransaction is null)
            {
                Console.WriteLine($" this {updTransaction} is not found");
            }
            else
            {
                updTransaction.DateOfTransaction = transaction.DateOfTransaction;
                updTransaction.Description = transaction.Description;
                updTransaction.Amount = transaction.Amount;
                saveChanges();
                Console.WriteLine($" this {updTransaction} is successfully updated ");

            }
            
        }

        // ======== this method to Add New Transaction ========= //
        public void AddNewTranscation(Transaction transaction)
        {
            Context.transactions.Add(transaction);
            saveChanges();
        }

        // ======== this method to Delete Transaction ========= //
        public void DeleteTransaction(int id)
        {
            Transaction? delTransaction = Context.transactions.Find(id);

            if (delTransaction is null)
            {
                Console.WriteLine($"this transaction with {id} is not found !");
            }

            Context.transactions.Remove(delTransaction);
            saveChanges();
        }

        public void saveChanges()
        {
            Context.SaveChanges();
        }

     
    }
}