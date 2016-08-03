using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.ViewModels
{
    public class ItemViewModel<T> : BaseViewModel
    {
        public T Item { get; set; }
    }
    
}