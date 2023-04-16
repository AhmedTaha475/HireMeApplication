using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Managers.TransactionManager
{
    public interface ITransactionManager
    {
        public IEnumerable<TransactionReadDto> GetAllTransactionByUserId(string userid);
        public void DeleteTransaction(int id);
        public TransactionReadDto GetTransactionById(int id);
        public void CreateNewTransaction(TransactionReadDto transactiondto);
    }
}
