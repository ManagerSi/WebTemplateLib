using DataBaseLib.DAL;
using DataBaseLib.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataBaseLib.BLL {
    public partial interface IBASE_USERBL :
        DataBaseLib.Infrastructure.BLL.IGenericBL<BASE_USER> {
        IQueryable<BASE_USER> QueryAll();
        BASE_USER GetByAccount(string name, string pwd);
    }

    public partial class BASE_USERBL : 
       DataBaseLib.Infrastructure.BLL.GenericBL<BASE_USER>,
       IBASE_USERBL {

        
        protected const string kCacheKeyPrefix = "_bl_BASE_USERBL";

        public IQueryable<BASE_USER> QueryAll() {
            return Repository.Get();
        }

        public BASE_USER GetByAccount(string name, string pwd) {
            return Repository.Get(i => i.UserAccount == name && i.UserPWD == pwd).FirstOrDefault();
        }
        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>

        #region 统一

        public BASE_USERBL() : base() {
            unitOfWork = new DataBaseLib.DAL.UnitOfWork();
            OnCreate();
        }
        public BASE_USERBL(DataBaseLib.DAL.UnitOfWork unitOfWork) : base() {
            this.unitOfWork = unitOfWork;
            OnCreate();
        }
        partial void OnCreate();
        private DataBaseLib.DAL.UnitOfWork UnitOfWork {
            get { return unitOfWork as DataBaseLib.DAL.UnitOfWork; }
            set { unitOfWork = value; }
        }
        private IBASE_USER_dal _repository;
        private IBASE_USER_dal Repository {
            get {
                if (_repository == null) {
                    _repository = unitOfWork.Repository<BASE_USER>() as IBASE_USER_dal;
                }
                return _repository;
            }
            set {
                _repository = value;
            }
        }

        public override BASE_USER InsertOrUpdate(BASE_USER entity) {
            if (entity.ID == 0) {
                return Insert(entity);
            }
            Update(entity);
            return entity;
        }

        #endregion

    }




}
