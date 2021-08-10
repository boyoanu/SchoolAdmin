using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SchoolAdmin.MongoDB
{
    class MongoDbService
    {
        MongoClient mongo;   
        IMongoDatabase database;
        IMongoCollection<BsonDocument> teachersCollection, studentsCollection;
        
        public MongoDbService() 
        {
            mongo = new MongoClient("mongodb://localhost:27017/School_Admin_db");   // Helps you connect to MongoDb(Database);
            database = mongo.GetDatabase("School_Admin_db");
            teachersCollection = database.GetCollection<BsonDocument>("teachers");
            studentsCollection = database.GetCollection<BsonDocument>("students");
        }

        //public void Insert(string collectionName, BsonDocument dataToInsert) 
        //{
        // switch (collectionName) 
        //    {
        //        case "teachers":
        //            //teachersCollection.InsertMany(new List<BsonDocument> { dataToInsert, dataToInsert }); // insertMany
        //            teachersCollection.InsertOne(dataToInsert);
        //            break;
        //        case "students":
        //            studentsCollection.InsertOne(dataToInsert);
        //            break;
        //        default:
        //            Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed");
        //            break;

        //    }
        //}

        public List<BsonDocument> FetchAll(string collectionName)
        {
            List<BsonDocument> result;

            switch (collectionName)
            {
                case "teachers":
                    
                    result = teachersCollection.Find(new BsonDocument()).ToList();
                    break;
                case "students":
                    result = studentsCollection.Find(new BsonDocument()).ToList();
                    break;
                default:
                    result = null;
                    Console.WriteLine("Invalid collection! Only 'teachers' and 'students' are allowed");
                    break;

            }
            return result;
        }


      

        //public void TestConnection()
        // { 
        // Display the list of database on this server
        //var dbList = mongo.ListDatabases().ToList();

        //Console.WriteLine("The list of databases on this server is: ");
        //foreach (var db in dbList)
        // {
        //  Console.WriteLine(db);
        //  }



    }
    }

