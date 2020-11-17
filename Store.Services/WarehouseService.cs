using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
    public class WarehouseService
    {
        private readonly IRepository<Warehouse> _warehouseRepository;

        public WarehouseService(IRepository<Warehouse> warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public IList<Warehouse> GetAllWarehouses()
        {
            return _warehouseRepository.GetAll().ToList();
        }

        public void InsertWarehouse(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(Warehouse));
            _warehouseRepository.Insert(warehouse);

        }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            if ( warehouse == null)
                throw new ArgumentNullException(nameof(Warehouse));
            _warehouseRepository.Delete(warehouse);

        }

        public Warehouse GetWarehouseByName(string name)
        {
            return _warehouseRepository.GetAll().FirstOrDefault(warehouse => warehouse.Name.Equals(name));
        }

        public Warehouse GetWarehouseById(Guid id)
        {
           
            return _warehouseRepository.GetById(id);
        }
    }
}
