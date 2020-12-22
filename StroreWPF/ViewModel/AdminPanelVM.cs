using System.Collections.Generic;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Store.Domain;
using System.Collections.ObjectModel;
using Store.Domain.Models;
using Store.Domain.Services;

namespace StoreWPF.ViewModel
{
    public class AdminPanelVM : BindableBase
    {
        public string NameW { get; set; }
        public string CountryW { get; set; }
        public string CityW { get; set; }

        public string NameV { get; set; }
        public string EmailV { get; set; }
        public string CountryV { get; set; }
        public Warehouse SelectedWarehouse { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public bool? FreeShipping { get; set; }
        public string ImageSource { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Vendor SelectedVendor { get; set; }





        private readonly IDataService<Warehouse> _warehouseService;
        private readonly IDataService<Vendor> _vendorService;
        private readonly IDataService<Product> _productService;
        private readonly IDataService<Order> _orderService ;



        public AdminPanelVM( IDataService<Warehouse> warehouseService, IDataService<Vendor> vendorService,
            IDataService<Product> productService, IDataService<Order> orderService)
        {
            _productService = productService;
            _warehouseService = warehouseService;
            _orderService = orderService;
            _vendorService = vendorService;
            Warehouses = new ObservableCollection<Warehouse>(_warehouseService.GetAll());
            Vendors = new ObservableCollection<Vendor>(_vendorService.GetAll());
            Orders = new ObservableCollection<Order>(_orderService.GetAll());
            AddWarehouse = new DelegateCommand<object>(obj => CreateWarehouse());
            AddVendor = new DelegateCommand<object>(obj => CreateVendor());
            AddProduct = new DelegateCommand<object>(obj => CreateProduct());
            DeleteWarehouse = new DelegateCommand<Warehouse>(warehouse =>
              {
                  _warehouseService.Delete(warehouse.Id);
                  Warehouses.Remove(warehouse);
              });

            DeleteVendor = new DelegateCommand<Vendor>(vendor =>
            {
                _vendorService.Delete(vendor.Id);
                Vendors.Remove(vendor);
            });


        }
        private void CreateWarehouse()
        {
            var warehouse = new Warehouse()
            {
                City = CityW,
                Country = CountryW,
                Name = NameW
            };
            _warehouseService.Insert(warehouse);
            Warehouses.Add(warehouse);
        }
        private void CreateVendor()
        {
            var vendor = new Vendor()
            {
                Country = CountryV,
                Email = EmailV,
                Name = NameV,
                WarehouseId = SelectedWarehouse.Id
            };
            _vendorService.Insert(vendor);
            Vendors.Add(vendor);
        }
        private void CreateProduct()
        {
            var product = new Product()
            {
                Name = Name,
                ShortDescription = ShortDescription,
                Cost = Cost,
                Count = Count,
                VendorId = SelectedVendor.Id,
                FreeShipping = FreeShipping,
                FullDescription = FullDescription,
                Height = Height,
                ImageSource = ImageSource,
                Length = Length,
                Width = Width,
                Weight = Weight
            };
            _productService.Insert(product);
        }

        public ObservableCollection<Vendor> Vendors { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Warehouse> Warehouses { get; set; }
        public DelegateCommand<object> AddWarehouse { get; }

        public DelegateCommand<Warehouse> DeleteWarehouse { get; }

        public DelegateCommand<Vendor> DeleteVendor { get; }
        public DelegateCommand<object> AddVendor { get; }
        public DelegateCommand<object> AddProduct { get; }
    }
}
