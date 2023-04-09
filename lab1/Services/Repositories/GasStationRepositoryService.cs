using lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1.Services.Repositories
{
    public class GasStationRepositoryService : IRepository<GasStation>
    {
        private readonly ApplicationDbContext context;

        public GasStationRepositoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public GasStation Create(GasStation entity)
        {
            var entityEntry = context.GasStation.Add(entity);
            context.SaveChanges();

            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            var entity = context.GasStation.FirstOrDefault(gas_station => gas_station.Id == id);
            context.Remove(entity);
            context.SaveChanges();
        }

        public List<GasStation> Read()
        {
            return context.GasStation.ToList();
        }

        public GasStation Read(int id)
        {
            return context.GasStation.FirstOrDefault(gas_station => gas_station.Id == id);
        }

        public void Update(GasStation entity)
        {
            context.GasStation.Update(entity);
            context.SaveChanges();
        }
    }
}
