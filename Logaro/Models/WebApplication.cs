using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logaro.Models
{
    public class WebApplication
    {
        
    public int ApplicationId { get; set; }
    //[Display(Name = "AppName")]
    public string ApplicationName { get; set; }
    public string TableName { get; set; }
    public string ConnectionId { get; set; }

    //public IEnumerable<WebApplication> Apps { get; set; }

    }

   
    } 
