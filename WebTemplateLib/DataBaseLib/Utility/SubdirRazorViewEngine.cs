﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobizone.TSIC.Utility {
  public class SubdirRazorViewEngine : RazorViewEngine {
    public SubdirRazorViewEngine()
      : base() {

      AreaViewLocationFormats = new[] {
            "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
        };

      AreaMasterLocationFormats = new[] {
            "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
        };

      AreaPartialViewLocationFormats = new[] {
            "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
        };

      ViewLocationFormats = new[] {
            "~/Views/%1/{1}/{0}.cshtml",
            "~/Views/%1/{1}/{0}.vbhtml",
            "~/Views/%1/Shared/{0}.cshtml",
            "~/Views/%1/Shared/{0}.vbhtml"
        };

      MasterLocationFormats = new[] {
            "~/Views/%1/{1}/{0}.cshtml",
            "~/Views/%1/{1}/{0}.vbhtml",
            "~/Views/%1/Shared/{0}.cshtml",
            "~/Views/%1/Shared/{0}.vbhtml"
        };

      PartialViewLocationFormats = new[] {
            "~/Views/%1/{1}/{0}.cshtml",
            "~/Views/%1/{1}/{0}.vbhtml",
            "~/Views/%1/Shared/{0}.cshtml",
            "~/Views/%1/Shared/{0}.vbhtml"
        };
    }
    protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath) {
      var nameSpace = controllerContext.Controller.GetType().Namespace;
      nameSpace = filterPath(nameSpace);
      return base.CreatePartialView(controllerContext, partialPath.Replace("%1", nameSpace));
    }

    protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath) {
      var nameSpace = controllerContext.Controller.GetType().Namespace;
      nameSpace = filterPath(nameSpace);
      return base.CreateView(controllerContext, viewPath.Replace("%1", nameSpace), masterPath.Replace("%1", nameSpace));
    }

    protected override bool FileExists(ControllerContext controllerContext, string virtualPath) {
      var nameSpace = controllerContext.Controller.GetType().Namespace;
      nameSpace = filterPath(nameSpace);
      return base.FileExists(controllerContext, virtualPath.Replace("%1", nameSpace));
    }

    private string filterPath(string nameSpace) {
      // remove first two part of nameSpace
      for (int i = 0; i < 3; ++i) {
        int pos = nameSpace.IndexOf('.');
        if (pos < 0) {
          break;
        }
        nameSpace = nameSpace.Substring(pos + 1);
      }
      return nameSpace;
    }
  }
}