using Derek.Web.App_Start;
using Derek.Web.Domain;
using Derek.Web.Models.ViewModels;
using Derek.Web.Services.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Derek.Web.Services
{
    public class BaseController : Controller
    {
        //private IUnityContainer _container;
        ////private IUserService _userService;

        //public BaseController()
        //{
        //    _container = UnityConfig.GetConfiguredContainer();
        //    //_userService = _container.Resolve<IUserService>();
        //}

        //public new ViewResult View()
        //{
        //    BaseViewModel model = GetViewModel<BaseViewModel>();
        //    DecorateViewModel(model);
        //    return base.View(model);
        //}

        //public new ViewResult View(string viewString)
        //{
        //    BaseViewModel model = GetViewModel<BaseViewModel>();
        //    DecorateViewModel(model);
        //    return base.View(viewString, model);
        //}

        //public ViewResult View(BaseViewModel baseVM)
        //{
        //    return base.View(DecorateViewModel(baseVM));
        //}

        //protected T GetViewModel<T>() where T : BaseViewModel, new()
        //{
        //    T model = new T();
        //    return DecorateViewModel(model);
        //}

        //protected T DecorateViewModel<T>(T model) where T : BaseViewModel
        //{
        //    if (_userService.IsLoggedIn())
        //    {
        //        model.IsLoggedIn = true;
        //        model.CurrentUser = new PublicUser(_userService.GetCurrentUser());
        //    }
        //    else
        //    {
        //        model.IsLoggedIn = false;
        //    }
        //    return model;
        //}
    }
}