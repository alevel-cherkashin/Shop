using Shop.Data.DataModels;
using Shop.Data.Repozitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public interface IUnitOfWork
    {
        void Save();
        EFClientRepository EFClientRepository { get;}
        EFTransacyionRepository EFTransacyionRepository { get; }
        EFCategoryRepository EFCategoryRepository { get; }
    }

    public class UnitOfWork:IDisposable,IUnitOfWork
    {
        private bool disposed = false;

        private ShopDataModel context = new ShopDataModel();

        private EFClientRepository _eFClientRepository;

        private EFTransacyionRepository _eFTransacyionRepository;

        private EFCategoryRepository _eFCategoryRepository;

        public  virtual EFClientRepository EFClientRepository
        {
            get
            {
                if (_eFClientRepository == null)
                {
                    _eFClientRepository = new EFClientRepository(context);
                }

                return _eFClientRepository;
            }
        }

        public EFTransacyionRepository EFTransacyionRepository
        {
            get
            {
                if (_eFTransacyionRepository == null)
                {
                    _eFTransacyionRepository = new EFTransacyionRepository(context);
                }
                return _eFTransacyionRepository;
            }
        }

        public virtual EFCategoryRepository EFCategoryRepository
        {
            get
            {
                if (_eFCategoryRepository == null)
                {
                    _eFCategoryRepository = new EFCategoryRepository(context);
                }

                return _eFCategoryRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
