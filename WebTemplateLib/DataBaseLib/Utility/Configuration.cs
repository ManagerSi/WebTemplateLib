﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DataBaseLib.Utility {
  public class Configuration {
    public static int WapPageSize {
      get {
        return 2;
      }
    }
    public static int MaxPasswordRetryTimes {
      get { return 10; }
    }

    public static int MaxExportRecord {
      get { return 65000; }
    }

    public static int MaxDetailExportRecord {
      get { return 5000; }
    }

    protected static int apiLoginTokenTimeoutMins = 720;
    public static int APILoginTokenTimeoutMins {
      get { return apiLoginTokenTimeoutMins; }
    }

    protected static bool flag_CustomerVIP = false;
    public static bool Flag_CustomerVIP {
      get {
        return flag_CustomerVIP;
      }
    }

    protected static bool flag_ServiceBusEnable = false;
    public static bool Flag_ServiceBusEnable {
      get { return flag_ServiceBusEnable; }

    }

    protected static bool flag_ParallelEnable = false;
    public static bool Flag_ParallelEnable {
      get { return flag_ParallelEnable; }

    }

    protected static bool isDevMode = false;
    public static bool IsDevMode {
      get {
        return isDevMode;
      }
    }

    protected static bool flag_WapTaskOpen = false;
    public static bool Flag_WapTaskOpen {
      get {
        return flag_WapTaskOpen;
      }
    }
    protected static bool flag_EnableBetaUser = false;
    public static bool Flag_EnableBetaUser {
      get {
        return flag_EnableBetaUser;
      }
    }

    protected static bool flag_PGMUpdateDuringImport = false;
    public static bool Flag_PGMUpdateDuringImport {
      get {
        return flag_PGMUpdateDuringImport;
      }
    }
        
    protected static string hostURL = "";
    public static string HostURL {
      get { return hostURL; }
    }

    protected static string baiduMapKey = "4IQoGDqxvXOvNpWGg8U66AMsacGx4UbP"; // 74d694453a14f2f0812e16d90343b0f4
    public static string BaiduMapKey {
      get { return baiduMapKey; }
    }

    // ------ temp flags
    protected static bool flag_DisableDsrWapEnter = true;
    public static bool Flag_DisableDsrWapEnter {
      get { return flag_DisableDsrWapEnter; }
    }

    public static string APIImageDirectory {
      get { return "/Areas/Api/ImageGroup/"; }
    }

    public static string weChatUploadImagePath = "";
    public static string WeChatUploadImagePath
    {
      get { return weChatUploadImagePath; }
    }

    public static string weChatUploadViocePath = "";
    public static string WeChatUploadViocePath {
      get { return weChatUploadViocePath; }
    }

    public static string weChatUploadVideoPath = "";
    public static string WeChatUploadVideoPath {
      get { return weChatUploadVideoPath; }
    }

    public static string weChatUploadFilePath = "";
    public static string WeChatUploadFilePath {
      get { return weChatUploadFilePath; }
    }
    public static string weChatCorpID = "";
    public static string WeChatCorpID {
      get { return weChatCorpID; }
    }
    public static string weChatSecret = "";
    public static string WeChatSecret {
      get { return weChatSecret; }
    }
    public static readonly TimeZoneInfo RPCTimeZone;

    public static readonly System.Globalization.NumberFormatInfo IntMoneyFormat;
    public static readonly System.Globalization.NumberFormatInfo MoneyFormat;
    public static readonly System.Globalization.CalendarWeekRule RPCWeekRule;
    public static readonly System.Globalization.Calendar RPCCalendar;

   
    protected static string flag_Dbhost = "";
    public static string Flag_Dbhost {
      get { return flag_Dbhost; }
    }

    protected static string flag_Wfpuser = "";
    public static string Flag_Wfpuser {
      get { return flag_Wfpuser; }
    }

    protected static string flag_Appkey = "";
    public static string Flag_Appkey {
      get { return flag_Appkey; }
    }

    protected static string flag_CRMWebService = "";
    public static string Flag_CRMWebService {
      get { return flag_CRMWebService; }
    }
    //action uri log
    public static bool flag_enable_request_track_log = false;
    public static bool Flag_enable_request_track_log {
      get { return flag_enable_request_track_log; }
    }
    //功能演示
    //public static bool flag_WechatTraining = false;
    //public static bool Flag_WechatTraining {
    //  get { return flag_WechatTraining; }
    //}

    public static int pgSign_TimeSpan = 3;
    public static int PGSign_TimeSpan {
      get { return pgSign_TimeSpan; }
    }
    static Configuration() {
      RPCTimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");

      IntMoneyFormat = new System.Globalization.CultureInfo("zh-CHS", false).NumberFormat;
      IntMoneyFormat.NumberDecimalDigits = 0;
      MoneyFormat = new System.Globalization.CultureInfo("zh-CHS", false).NumberFormat;
      MoneyFormat.NumberDecimalDigits = 2;

      // week rule
      System.Globalization.CultureInfo rpcCI = new System.Globalization.CultureInfo("zh-CHS");
      RPCCalendar = rpcCI.Calendar;
      RPCWeekRule = rpcCI.DateTimeFormat.CalendarWeekRule;

      var dict = ConfigurationManager.AppSettings.AllKeys.ToDictionary(i => i, i => ConfigurationManager.AppSettings[i]);


    }

    private static bool ParseBoolCfg(Dictionary<string, string> dict, string cfgName, bool defaultValue) {
      return !dict.ContainsKey(cfgName) ? defaultValue : bool.Parse(dict[cfgName]);
    }

    private static int ParseIntCfg(Dictionary<string, string> dict, string cfgName, int defaultValue) {
      return !dict.ContainsKey(cfgName) ? defaultValue : int.Parse(dict[cfgName]);
    }

    private static string ParseStringCfg(Dictionary<string, string> dict, string cfgName, string defaultValue) {
      return !dict.ContainsKey(cfgName) ? defaultValue : dict[cfgName];
    }

    protected static bool flag_oos = false;
    public static bool Flag_OOS {
      get {
        return flag_oos;
      }
    }

    protected static bool flag_wap_login_close = false;
    public static bool Flag_WapLoginClose {
      get {
        return flag_wap_login_close;
      }
    }



  }
}