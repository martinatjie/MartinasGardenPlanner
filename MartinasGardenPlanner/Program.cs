// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using var db = new PlantContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new plant");
db.Add(new Plant { CommonName = "Rose"});
db.SaveChanges();

// Read
Console.WriteLine("Querying for a plant");
var plants = db.Plants
    .OrderBy(b => b.PlantId)
    .First();

Console.WriteLine($"found {plants.PlantId}");


//Add companions
var plant1 = new Plant { CommonName = "boxwood" };
var plant2 = new Plant { CommonName = "fern" };
var plant3 = new Plant { CommonName = "banana tree" };

db.Plants.AddRange(plant1, plant2, plant3);
db.SaveChanges();

// Update
Console.WriteLine("Updating the plant and adding a plant");
plants.Color = "red, pink, yellow, white";
db.SaveChanges();

// Delete
Console.WriteLine("Delete the plants");
db.Remove(plants);
db.SaveChanges();