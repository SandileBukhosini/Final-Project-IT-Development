using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BriteHouse.App_Start;
using MongoDB.Driver;
using BriteHouse.Models;
using MongoDB.Bson;

namespace BriteHouse.Controllers
{
    public class ReturnsController : Controller
    {
        // GET: Returns
       
        private MongoDBContext dbContext;
        private IMongoCollection<ReturnsModel> returnCollection;
        public ReturnsController()
        {
            dbContext = new MongoDBContext();
            returnCollection = dbContext.database.GetCollection<ReturnsModel>("Returns");
        }
        // GET: People
        public ActionResult Index()
        {
            List<ReturnsModel> returns = returnCollection.AsQueryable<ReturnsModel>().ToList();

            return View(returns);
        }

        // GET: People/Details/5
        public ActionResult Details(string id)
        {
            var orderId = new ObjectId(id);
            var returns = returnCollection.AsQueryable<ReturnsModel>().SingleOrDefault(x => x.Id == orderId);
            return View(returns);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(ReturnsModel returns)
        {
            try
            {

                returnCollection.InsertOne(returns);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(string id)
        {
            var orderId = new ObjectId(id);
            var returns = returnCollection.AsQueryable<ReturnsModel>().SingleOrDefault(x => x.Id == orderId);
            return View(returns);

        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ReturnsModel returns)
        {
            try
            {
                var filter = Builders<ReturnsModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<ReturnsModel>.Update
                    .Set("Person", returns.Person)
                    .Set("Region", returns.Region);
                var result = returnCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(string id)
        {
            var orderId = new ObjectId(id);
            var returns = returnCollection.AsQueryable<ReturnsModel>().SingleOrDefault(x => x.Id == orderId);
            return View(returns);

        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                returnCollection.DeleteOne(Builders<ReturnsModel>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    }
