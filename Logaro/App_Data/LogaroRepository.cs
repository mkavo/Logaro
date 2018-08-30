using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using log4net.Core;
using Logaro.Controllers;
using Logaro.Models;
using PetaPoco;
using Logaro = Logaro.Models.Logaro;


namespace Logaro.App_Data
{
    public class LogaroRepository : IRepository<Models.Logaro>
    {
        private static LogaroRepository _instance;


        public static LogaroRepository Instance
        {
            get
            {
                //Database.Mapper = new PolicyMapper();
                return _instance ?? (_instance = new LogaroRepository());
            }
        }
        public void Create(Models.Logaro objectToCreate, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public void Index(Models.Logaro objectToIndex, IUnitOfWork uow)
        {
            var db = new Database("DevtestSQLServerDatabase");
            var query = db.Query<Models.Logaro>("SELECT * FROM Log");
            var result = query.FirstOrDefault();
        }

        public void Delete(Models.Logaro objectToDelete, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public Models.Logaro Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.Logaro> ReadAll()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Models.Logaro> Index(string appname)
        //{
        //    var db = new Database("DevtestSQLServerDatabase");
        //    var query = db.Query<Models.Logaro>("SELECT * FROM @0", appname);
        //    var result = query;   //.FirstOrDefault();

        //    return result;
        //}

        public List<Models.Logaro> logaroListBind(string tablename)
        {
                var db = new Database("DevtestSQLServerDatabase");
                var query = db.Query<Models.Logaro>("SELECT * FROM " + tablename + " Order By Id");
                var result = query;
                return result.ToList();         
        }

        public List<Models.Logaro> LogaroList(string day, string tableName)
        {

            //var da = DateTime.Parse(day);
            //var dag = DateTime.Parse(day).ToShortDateString();
            
            var db = new Database("DevtestSQLServerDatabase");
            var query = db.Query<Models.Logaro>("SELECT  Date, id ,Thread ,level, Logger ,Message, Exception  FROM " + tableName + " Where Convert(DATE,Date) LIKE " + "("+"'" + day + "%" + "'" + ")" + " Order By Id");
            var result = query;
            return result.ToList();
        }

        public IEnumerable<WebApplication> AppsConfig()
        {
            var db = new Database("DevtestSQLServerDatabase");
            var query = db.Query<WebApplication>("SELECT * FROM WebApplication");
            var result = query;
            return result;
        }

        public IEnumerable<WebApplication> TableName(int applicationId)
        {
            var db = new Database("DevtestSQLServerDatabase");
            var query = db.Fetch<WebApplication>("Select * From WebApplication Where ApplicationId = @0", applicationId);
            var result = query;
            return result;
        }

        
        public IEnumerable<Models.Logaro> LogaroListFreeText (string text, string tableName)
        {
            var db = new Database("DevtestSQLServerDatabase");
            const string S = "Select * From ";
            string v = S + tableName;
            var query = db.Fetch<Models.Logaro>(v + " Where Level ='Error' And Message like '%" +text + "%'" + " Order By Id");
            var result = query;
            return result;
        }

        public void Update(Models.Logaro objectToUpdate, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }
    }
}

