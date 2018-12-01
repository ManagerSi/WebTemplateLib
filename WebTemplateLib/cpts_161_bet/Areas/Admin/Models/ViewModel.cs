using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cpts_161_bet.Areas.Admin.Models {
    public class ViewModel {
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