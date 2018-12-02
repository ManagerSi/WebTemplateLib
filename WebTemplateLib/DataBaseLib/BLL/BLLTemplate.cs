﻿


//------------------------------------------------------------------------------
// <auto-generated>
//     此代码是根据模板生成的。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataBaseLib.Model;

namespace DataBaseLib.BLL
{
    public partial class BLLFactory : DataBaseLib.Infrastructure.BLL.BLLFactory
        {
            
            static BLLFactory()
            {
                //在这里进行注册
                RegisterBL("IBASECITYBL", typeof(IBASECITYBL), typeof(BASECITYBL));
                RegisterBL("I房屋租赁表BL", typeof(I房屋租赁表BL), typeof(房屋租赁表BL));
                
                ExtraInit(); 
            }
    	    static partial void ExtraInit();
    		public static  void  RegisterBL(string name,Type intf, Type type) {
              BLLs.Add(intf, type);
              BLLsByName.Add(name, type);
            }
    
    		protected static Dictionary<Type, Type> BLLs = new Dictionary<Type, Type>();
    		protected static Dictionary<string, Type> BLLsByName = new Dictionary<string, Type>();
    	/// <summary>
            ///     创建对应BL,如果缓存可用，则使用缓存
            /// </summary>
    		public static IBL Create<IBL>(DataBaseLib.DAL.UnitOfWork uw=null) where IBL : class {
    	      return null == uw ? CreateNew<IBL>() : CreateNew<IBL>(uw);
    	      // 现在还没遇到性能瓶颈，无需使用以下方法
       	      /*var service = CurrentService;
        	  if (service  == null) {
                return null == uw ? CreateNew<IBL>() : CreateNew<IBL>(uw);
        	  }
    		  if (null == uw) {
    	        return service.BL<IBL>() as IBL;
    	      }
              var cur_uw = service.UnitOfWork;
    		  if (uw == cur_uw) {
    	        return service.BL<IBL>() as IBL;
    	      } else {
    		    return CreateNew<IBL>(uw);
    		  }*/
    		}
    	
    	/// <summary>
            ///     创建一个新的BLL对象
            /// </summary>
    		public static IBL CreateNew<IBL>(params object[] args) where IBL : class {
    		  return CreateNewFromDict<IBL>(BLLs, args);
    		}
    		public static object CreateNewByName(string name, params object[] args) {
    		  return CreateNewFromDictByName(BLLsByName, name, args);
    		}
        }
    
    public partial interface IBLLService : DataBaseLib.Infrastructure.BLL.IBLLService {
        DataBaseLib.DAL.UnitOfWork UnitOfWork {get; set;}

        IBASECITYBL BASECITYBL { get;}
  
    }
    
    public partial class BLLService : DataBaseLib.Infrastructure.BLL.BLLService,IBLLService {
      public DataBaseLib.DAL.UnitOfWork UnitOfWork {get; set;}
      public BLLService(DataBaseLib.DAL.UnitOfWork unitofwork) : base(unitofwork) {
        this.UnitOfWork = unitofwork;
      }
    
      //在这里进行注册
      private IBASECITYBL _BASECITYBL = null;
      public IBASECITYBL BASECITYBL {
        get
    	{
    	  if (_BASECITYBL == null)
    	  {
                    _BASECITYBL = BLLFactory.CreateNew<IBASECITYBL>(UnitOfWork);
    	  }
    	  return _BASECITYBL;
    	}
      }
        
      //在这里进行注册
      private I房屋租赁表BL _I房屋租赁表BL = null;
        public I房屋租赁表BL I房屋租赁表BL {
            get {
                if (_I房屋租赁表BL == null) {
                    _I房屋租赁表BL = BLLFactory.CreateNew<I房屋租赁表BL>(UnitOfWork);
                }
                return _I房屋租赁表BL;
            }
        }
    }
}

