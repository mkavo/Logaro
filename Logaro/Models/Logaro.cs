using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using PetaPoco;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace Logaro.Models
{
    public class Logaro
    {
        public Logaro()
        {

        }
        /// <summary>
        /// Logaro id. Id:t i databasen
        /// </summary>
        [DisplayName(@"ID")]
        public int Id { get; set; }

        /// <summary>
        /// Logaro Date i databasen
        /// </summary>
        [DisplayName(@"Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Logaro id. Id:t i databasen
        /// </summary>
        [DisplayName(@"Thread")]
        public string Thread { get; set; }

        /// <summary>
        /// Logaro Level i databasen
        /// </summary>
        [DisplayName(@"Level")]
        public string Level { get; set; }

        /// <summary>
        /// Logaro id. Id:t i databasen
        /// </summary>
        [DisplayName(@"Logger")]
        public string Logger { get; set; }

        /// <summary>
        /// Logaro id. Id:t i databasen
        /// </summary>
        [DisplayName(@"Message")]
        public string Message { get; set; }

        /// <summary>
        /// Logaro id. Id:t i databasen
        /// </summary>
        [DisplayName(@"Exception")]
        public string Exception { get; set; }

        public List<Logaro> Log { get; set; }
    }
}