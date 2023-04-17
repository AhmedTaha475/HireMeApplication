using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos
{
    public interface ITransactionRepo
    {
        #region Get Cruds in Transaction (Interface)
        public IEnumerable<Transaction> GetAllTranscations(string userid);
        public Transaction GetTransactionById(int id);

        #endregion

        #region Create Cruds in Transaction (Interface)
        public void AddNewTranscation(Transaction transaction);
        #endregion

        #region Update Cruds in Transaction (Interface)
        public void UpdateTransaction(Transaction transaction, int id);

        #endregion

        #region Delete Cruds in Transaction (Interface)
        public void DeleteTransaction(int id);

        #endregion

        #region Helper Methods to save in context in Transaction (Interface)
        public void saveChanges();
        #endregion




    }
}
