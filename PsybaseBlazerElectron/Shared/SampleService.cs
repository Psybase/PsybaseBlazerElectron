using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

namespace PsybaseBlazerElectron.Shared
{
    public class SampleService
    {
        // Can be called from anywhere
        public void Update(NotifyProperties prop)
        {
            if (Notify != null)
            {
                this.Prop = prop;
                Notify.Invoke(prop);
            }
        }

        public NotifyProperties Prop
        {
            get; set;
        } = new NotifyProperties();

        public CurrentSampleData Data { get; set; } = new CurrentSampleData();
        public event Func<NotifyProperties, Task> Notify;
    }

    public class NotifyProperties
    {
        public bool HideSpinner { get; set; }

        public bool RestricMouseEvents { get; set; }
    }

    public class CurrentSampleData
    {
        public CurrentSampleData(NavigationManager uriHelper)
        {
            this.UriHelper = uriHelper;
        }

        public CurrentSampleData()
        {

        }
        public NavigationManager UriHelper { get; set; }
        

        

        internal void Update(NavigationManager urlHelper)
        {
            this.UriHelper = urlHelper;
            string updatedUrl = UriHelper.Uri.Replace(UriHelper.BaseUri, "").Trim();
            if (updatedUrl.Contains('?'))
            {
                updatedUrl = updatedUrl.Substring(0, updatedUrl.IndexOf('?'));
            }
            if (updatedUrl != "")
            {
                if (updatedUrl.LastIndexOf("/") == updatedUrl.Length - 1)
                {
                    updatedUrl = updatedUrl.Substring(0, updatedUrl.LastIndexOf("/"));
                }
                updatedUrl = updatedUrl.Replace("//", "/");
                string[] splittedUrl = updatedUrl.Split("/");
                if (splittedUrl.Length >= 2)
                {
                    try
                    {
                        string CategoryName = splittedUrl[^2];
                        string SampleName = splittedUrl[^1];
                        CategoryName = CategoryName.Replace("-", "");

                    }
                    catch (Exception)
                    {

                    }
                }
                if (splittedUrl.Length < 2 && splittedUrl.Length > 0)
                {
                    string CategoryName = splittedUrl[^1];
                    // CategoryName = char.ToUpper(CategoryName[0]) + CategoryName.Substring(1);
                    _ = CategoryName.Replace("-", "");

                }
            }
        }
    }
}