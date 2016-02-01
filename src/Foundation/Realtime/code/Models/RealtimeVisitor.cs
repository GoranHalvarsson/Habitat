
namespace VisionsInCode.Foundation.Realtime.Models
{
  using System;
  using System.Collections.Generic;
  using MongoDB.Bson;
  using MongoDB.Bson.Serialization.Attributes;

  public class RealtimeVisitor
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    //No need for created date:
    //One datestamp is already in the _id object, representing insert time

    //So if the insert time is what you need, it's already there:

    //Login to mongodb shell

    //ubuntu@ip-10-0-1-223:~$ mongo 10.0.1.223
    //MongoDB shell version: 2.4.9
    //connecting to: 10.0.1.223/test
    //Create your database by inserting items

    //> db.penguins.insert({"penguin": "skipper"})
    //> db.penguins.insert({"penguin": "kowalski"})
    //> 
    //Lets make that database the one we are on now

    //> use penguins
    //switched to db penguins
    //Get the rows back:

    //> db.penguins.find()
    //{ "_id" : ObjectId("5498da1bf83a61f58ef6c6d5"), "penguin" : "skipper" }
    //{ "_id" : ObjectId("5498da28f83a61f58ef6c6d6"), "penguin" : "kowalski" }
    //Get each row in yyyy-MM-dd HH:mm:ss format:

    //> db.penguins.find().forEach(function (doc){ d = doc._id.getTimestamp(); print(d.getFullYear()+"-"+(d.getMonth()+1)+"-"+d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds()) })
    //2014-12-23 3:4:41
    //2014-12-23 3:4:53


    public string ContactId { get; set; }

    public IEnumerable<RealtimeConnection> RealtimeConnections { get; set; }

    public RealtimeMetaData RealtimeMetaData { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsToBeDeleted { get; set; }
  }
}