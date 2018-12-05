using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cpts_161_bet.Areas.Admin.Models {
    public class ViewModel {
    }
    public class BaseReportModel<T> {
        public int TotalCount { get; set; }
        public int OnePageCount { get { return 2; }  }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
        public int NextPageIndex { get { if (CurrentPageIndex + 1 >= TotalCount) return CurrentPageIndex; else return CurrentPageIndex + 1; }  }
        public int PrePageCount { get { if (CurrentPageIndex  <= 0) return 0; else return CurrentPageIndex -1 ; } }
        public IEnumerable<T> ItemList { get; set; }

    }
    public class HouseReportModel {
        public HouseReportModel() {
            ItemList = new PaginationModel<HouseInformation>();
        }
        public PaginationModel<HouseInformation> ItemList { get; set; }
    }
    public class HouseInformation {
        public string 市区 { get; set; }
        public string 街道1 { get; set; }
        public string 街道2 { get; set; }
        public string 小区 { get; set; }
        public string 室厅厨卫 { get; set; }
        public double? 面积 { get; set; }

    }
}