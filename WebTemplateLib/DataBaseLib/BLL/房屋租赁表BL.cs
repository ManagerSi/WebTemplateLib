using DataBaseLib.DAL;
using DataBaseLib.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataBaseLib.BLL {
    public partial interface I房屋租赁表BL :
        DataBaseLib.Infrastructure.BLL.IGenericBL<房屋租赁表> {
        IQueryable<房屋租赁表> QueryAll();
    }

    public partial class 房屋租赁表BL : 
       DataBaseLib.Infrastructure.BLL.GenericBL<房屋租赁表>,
       I房屋租赁表BL {
        
        public 房屋租赁表BL() : base() {
            unitOfWork = new DataBaseLib.DAL.UnitOfWork();
            OnCreate();
        }
        public 房屋租赁表BL(DataBaseLib.DAL.UnitOfWork unitOfWork) : base() {
            this.unitOfWork = unitOfWork;
            OnCreate();
        }
        partial void OnCreate();
        private DataBaseLib.DAL.UnitOfWork UnitOfWork {
            get { return unitOfWork as DataBaseLib.DAL.UnitOfWork; }
            set { unitOfWork = value; }
        }
        private I房屋租赁表_dal _repository;
        private I房屋租赁表_dal Repository {
            get {
                if (_repository == null) {
                    _repository = unitOfWork.Repository<房屋租赁表>() as I房屋租赁表_dal;
                }
                return _repository;
            }
            set {
                _repository = value;
            }
        }

        public override 房屋租赁表 InsertOrUpdate(房屋租赁表 entity) {
            if (entity.ID == 0) {
                return Insert(entity);
            }
            Update(entity);
            return entity;
        }
        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>

    protected const string kCacheKeyPrefix = "_bl_房屋租赁表BL";

        public IQueryable<房屋租赁表> QueryAll() {
            return Repository.GetAllCityQueryable();
        }
    }




}
