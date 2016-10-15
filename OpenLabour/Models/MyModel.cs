using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace OpenLabour.Models
{
    public class CustomDisplayNameAttribute : DisplayNameAttribute
    {
        public CustomDisplayNameAttribute(string value) : base(GetMessageFromResource(value))
        { }

        private static string GetMessageFromResource(string value)
        {
            return value;
        }
    }

}