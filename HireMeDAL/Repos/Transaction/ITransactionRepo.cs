using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos
{
    internal interface ITransactionRepo
    {

        public IEnumerable<Transaction> GetAllTranscations(string userid);
        public Transaction GetTransactionById(int id);
        public void AddNewTranscation(Transaction transaction);
        public void UpdateTransaction(Transaction transaction, int id);
        public void DeleteTransaction(int id);
        public void saveChanges();

    }
}
