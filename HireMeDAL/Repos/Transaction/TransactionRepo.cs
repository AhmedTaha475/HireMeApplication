﻿using HireMeDAL.Repos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class TransactionRepo : ITransactionRepo
    {
        #region Constructor && All Injection Requires for Repo Transaction Class  
        public HireMeContext Context { get; }
        public TransactionRepo(HireMeContext context)
        {
            Context = context;
        }
        #endregion

        #region All Get Cruds for Repo Trasaction Class

        // ======== this method to Get All Transaction ( !!!! for user or not ???) ========= //
        public IEnumerable<Transaction> GetAllTranscations(string userid)
        {
            var Transactions = Context.transactions.Where(t => t.SystemUserId == userid).ToList();
            if (Transactions.Count==0)
            {
                return null;
            }
            else
                return Transactions;
        }

        // ======== this method to Get specific Transaction with id ( !!!! for user or not ???) ========= //
        public Transaction GetTransactionById(int id)
        {
            Transaction? transaction = Context.transactions.FirstOrDefault(t => t.TransactionId == id);
            if (transaction is null)
                return null;
            else
                return transaction;
        }

        #endregion

        #region All Create Cruds for Repo Trasaction Class

        // ======== this method to Add New Transaction ========= //
        public bool AddNewTranscation(Transaction transaction)
        {
            try
            {
            Context.transactions.Add(transaction);
            saveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region All Update Cruds for Repo Trasaction Class

        // ======== this method to Update New Transaction  (for user ---> client or freelancer) ========= //
        public void UpdateTransaction(Transaction transaction, int id)
        {
            var updTransaction = Context.transactions.FirstOrDefault(t => t.TransactionId == id);

            if (updTransaction is null)
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

        #endregion

        #region All Delete Cruds for Repo Trasaction Class

        // ======== this method to Delete Transaction ========= //
        public bool DeleteTransaction(int id)
        {
            Transaction? delTransaction = Context.transactions.Find(id);

            if (delTransaction is null)
            {
                Console.WriteLine($"this transaction with {id} is not found !");
                return false;
            }
            else 
            { 
                Context.transactions.Remove(delTransaction);
                saveChanges();
                return true;
            }
            
        }

        public void saveChanges()
        {
            Context.SaveChanges();
        }

        #endregion


    }
}
