using System;
using PetaPoco;


namespace Logaro.App_Data
{
    /// <summary>
    /// Byggd efter http://jamesheppinstall.wordpress.com/2012/06/16/petapoco-quick-and-easy-unit-of-work/
    /// Det syftar till att man ska kunna försäkra sig om att allt sparats i databasen innan man går vidare. Annars återställs allt.
    /// </summary>
    /// 
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void CommitTrans();
        void RollbackTrans();
        Database DB { get; }

    }


    public class ViolaUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new ViolaUnitOfWork();
        }
    }


    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork();
    }

    public class ViolaUnitOfWork : IUnitOfWork
    {
        private readonly Transaction _petaTransaction;
        private readonly Database _db;

        public Database DB { get { return _db; } }
        /// <summary>
        /// Initierar databasen.
        /// </summary>
        public ViolaUnitOfWork()
        {
            //Petapoco stuff
            _db = new Database("ViolaSQLServerDatabase");
            _petaTransaction = new Transaction(_db);
        }

        public void Dispose()
        {
            _petaTransaction.Dispose();
        }

        public void Commit()
        {
            _petaTransaction.Complete();
        }

        public void CommitTrans()
        {
            _db.CompleteTransaction();
        }

        public void RollbackTrans()
        {
            _db.AbortTransaction();
        }
    }


}
