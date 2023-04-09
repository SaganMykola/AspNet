using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Services.Repositories
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

        public List<GasStation> Read(GasStation filterBy, string orderBy, string order, int page, int perPage)
        {
            var filteredItems = context.GasStation
               .Where(gas_station =>
                   (filterBy.Address != null ? gas_station.Address.ToLower().Contains(filterBy.Address.ToLower()) : true)
                   &&
                   (filterBy.OwnerCompany != null ? gas_station.OwnerCompany.ToLower().Contains(filterBy.OwnerCompany.ToLower()) : true));

            IOrderedQueryable<GasStation> orderedItems;

            switch ($"{orderBy}_{order}".ToLower())
            {
                case "id_desc":
                    orderedItems = filteredItems.OrderByDescending(u => u.Id);
                    break;
                case "address_asc":
                    orderedItems = filteredItems.OrderBy(u => u.Address);
                    break;
                case "address_desc":
                    orderedItems = filteredItems.OrderByDescending(u => u.Address);
                    break;
                case "owner_company_asc":
                    orderedItems = filteredItems.OrderBy(u => u.OwnerCompany);
                    break;
                case "owner_company_desc":
                    orderedItems = filteredItems.OrderByDescending(u => u.OwnerCompany);
                    break;
                default:
                    orderedItems = filteredItems.OrderBy(u => u.Id);
                    break;
            };

            return orderedItems
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();
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
        public int Count(GasStation filterBy)
        {
            return context.GasStation
                .Count(gas_station =>
                   (filterBy.Address != null ? gas_station.Address.ToLower().Contains(filterBy.Address.ToLower()) : true)
                   &&
                   (filterBy.OwnerCompany != null ? gas_station.OwnerCompany.ToLower().Contains(filterBy.OwnerCompany.ToLower()) : true));
        }

        public bool AddressExist(GasStation gas_station)
        {
            return context.GasStation.Any(u => u.Id != gas_station.Id && u.Address.ToLower() == gas_station.Address.ToLower());
        }
    }
}
