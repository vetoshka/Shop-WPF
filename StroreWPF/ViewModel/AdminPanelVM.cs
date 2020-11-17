using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Prism.Commands;
using Prism.Events;
using Store.Domain;
using Store.Domain.Data;
using Store.Services;

namespace StoreWPF.ViewModel
{
    public class AdminPanelVM : BindableBase
    {
        protected readonly IEventAggregator _eventAggregator;
        public string NameW { get; set; }
        public string CountryW { get; set; }
        public string CityW { get; set; }
       
        public string NameV {get; set; }
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





        private readonly WarehouseService warehouseService= new WarehouseService(new Repository<Warehouse>(new DBContext()));
        private readonly VendorService vendorService= new VendorService(new Repository<Vendor>(new DBContext()));
        private readonly ProductService productService = new ProductService(new Repository<Product>(new DBContext()));
        private readonly OrderService orderService = new OrderService(new Repository<Order>(new DBContext()));



        public AdminPanelVM(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Warehouses = new ObservableCollection<Warehouse>(warehouseService.GetAllWarehouses());
            Vendors = new ObservableCollection<Vendor>(vendorService.GetAllVendors());
            Orders =new ObservableCollection<Order>(orderService.GetAllOrders());
            AddWarehouse = new DelegateCommand<object>(obj => CreateWarehouse());
            AddVendor = new DelegateCommand<object>(obj => CreateVendor());
            AddProduct = new DelegateCommand<object>(obj => CreateProduct());
            DeleteWarehouse=new DelegateCommand<Warehouse>(warehouse =>
            {
                warehouseService.DeleteWarehouse(warehouse);
                Warehouses.Remove(warehouse);
            });

            DeleteVendor = new DelegateCommand<Vendor>(vendor =>
            {
                vendorService.DeleteVendor(vendor);
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
            warehouseService.InsertWarehouse(warehouse);
            Warehouses.Add(warehouse);
        }
        private void CreateVendor()
        {
            var vendor = new Vendor()
            {
                Country = CountryV,
                Email = EmailV,
                Name = NameV,
                WarehouseId = SelectedWarehouse.WarehouseId
            };
            vendorService.InsertVendor(vendor);
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
                VendorId = SelectedVendor.VendorId,
                FreeShipping = FreeShipping,
                FullDescription = FullDescription,
                Height = Height,
                ImageSource = ImageSource,
                Length = Length,
                Width = Width,
                Weight = Weight
            };
            productService.InsertProduct(product);
            _eventAggregator.GetEvent<InsertProductEvent>().Publish(product);
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
