using DataBaseLib.DAL;
using DataBaseLib.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataBaseLib.BLL {
    public partial interface IBASECITYBL :
        DataBaseLib.Infrastructure.BLL.IGenericBL<BASE_CITY> {
        IQueryable<BASE_CITY> QueryAll();
    }

    public partial class BASECITYBL : 
       DataBaseLib.Infrastructure.BLL.GenericBL<BASE_CITY>,
       IBASECITYBL {
        
        public BASECITYBL() : base() {
            unitOfWork = new DataBaseLib.DAL.UnitOfWork();
            OnCreate();
        }
        public BASECITYBL(DataBaseLib.DAL.UnitOfWork unitOfWork) : base() {
            this.unitOfWork = unitOfWork;
            OnCreate();
        }
        partial void OnCreate();
        private DataBaseLib.DAL.UnitOfWork UnitOfWork {
            get { return unitOfWork as DataBaseLib.DAL.UnitOfWork; }
            set { unitOfWork = value; }
        }
        private IBASE_CITY_dal _repository;
        private IBASE_CITY_dal Repository {
            get {
                if (_repository == null) {
                    _repository = unitOfWork.Repository<BASE_CITY>() as IBASE_CITY_dal;
                }
                return _repository;
            }
            set {
                _repository = value;
            }
        }

        public override BASE_CITY InsertOrUpdate(BASE_CITY entity) {
            if (entity.ID == 0) {
                return Insert(entity);
            }
            Update(entity);
            return entity;
        }
        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>

    protected const string kCacheKeyPrefix = "_bl_BASECITYBL";

        public IQueryable<BASE_CITY> QueryAll() {
            return Repository.Get();
        }
    }




}
