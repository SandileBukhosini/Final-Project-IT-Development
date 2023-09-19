using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace BriteHouse.App_Start
{
    public class MongoDBContext
    {
        
            //link between connection and your work.Where you will display your database.

            public IMongoDatabase database;
            public MongoDBContext()
            {
                var mongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
                database = mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
            }
        
    }
}