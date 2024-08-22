using System;
using System.Collections.Generic;
using ZooManagement.Models.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);
        Animal Create(CreateAnimalRequest animal);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Animal GetById(int id)
        {
            return _context.Animals.Single(animal => animal.Id == id);
        }

        public Animal Create(CreateAnimalRequest animal)
        {
            var insertResult = _context.Animals.Add(new Animal 
            {
                Name = animal.Name,
                AnimalTypeId = animal.AnimalTypeId,
                Sex = animal.Sex,
                BirthDate =  DateOnly.Parse(animal.BirthDate),
                AcquiredDate =  DateOnly.Parse(animal.AcquiredDate),
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }
    }
}