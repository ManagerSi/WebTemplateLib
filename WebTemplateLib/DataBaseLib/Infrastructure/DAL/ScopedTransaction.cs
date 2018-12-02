using System;
using System.Data.Entity;
using System.Transactions;

namespace DataBaseLib.Infrastructure.DAL {
    public class ScopedTransaction : IDisposable {
    protected UnitOfWork unitOfWork;
    protected DbContext ctx;
    protected TransactionScope transaction;
    public ScopedTransaction(UnitOfWork uw, TransactionOptions option) {
      unitOfWork = uw;
      transaction = new TransactionScope(TransactionScopeOption.Required, option);
      ctx = unitOfWork.NewContext(false);
    }

    public void Complete() {
      transaction.Complete();
    }

    public void Dispose() {
      unitOfWork.context.Dispose();
      unitOfWork.context = ctx;
      transaction.Dispose();
      
    }
  }
}
