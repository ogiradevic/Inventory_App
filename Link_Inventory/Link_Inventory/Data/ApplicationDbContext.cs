using System;
using System.Collections.Generic;
using System.Text;
using Link_Inventory.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Link_Inventory.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemRoom> ItemsRooms { get; set; }
        public DbSet<NonSerializedItemRoom> NonSerializedItemRooms { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ItemUser> ItemUsers { get; set; }
        public DbSet<SerializedItem> SerializedItems { get; set; }
        public DbSet<SerializedItemCondition> SerializedItemConditions { get; set; }
        public DbSet<NonSerializedItemWriteOff> NonSerializedItemWriteOffs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<RoomCategoryType> RoomCategoryTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Kreiranje Tipova Artikala
            modelBuilder.Entity<ItemType>().HasData(new ItemType { Id = 1, Name = "Artikal sa serijskim brojem" });
            modelBuilder.Entity<ItemType>().HasData(new ItemType { Id = 2, Name = "Potrošna roba" });

            //Kreiranje Artikala
            modelBuilder.Entity<Item>().HasData(new Item { Id = 1, Name = "LapTop", Model = "Acer54", Amount=1, ItemTypeId=1 });
            modelBuilder.Entity<Item>().HasData(new Item { Id = 2, Name = "Monitor", Model = "Benq55", Amount=1, ItemTypeId=1 });
            modelBuilder.Entity<Item>().HasData(new Item { Id = 3, Name = "Podloga Za Miša", Model= "CabronFiber", Amount=50, ItemTypeId=2 });

            // Kreiranje Drzava
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Srbija" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Bosna i Hercegovina" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Crna Gora" });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Beograd", Address = "Cara Dusana 111", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Beograd", Address = "Cara Dusana 122", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Beograd", Address = "Cara Dusana 133", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 4, Name = "Beograd", Address = "Ustanicka 123", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 5, Name = "Beograd", Address = "Vidska 37", CountryId = 1 });

            //Kreiranje Preduzeca 
            modelBuilder.Entity<Company>().HasData(new Company { Id = 1, Name = "LinkGroup", CityId = 1 });
            modelBuilder.Entity<Company>().HasData(new Company { Id = 2, Name = "SoftLink", CityId = 2 });

            //Kreiranje Ustanova 
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, Name = "IT Akademija", CompanyId = 1, CityId=3 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, Name = "ITS_Development", CompanyId = 2, CityId=4 });

            //Kreirnaje Prostora
            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, Name = "Prostorija nije određena", BranchId = 1, RoomCategoryTypeId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 2, Name = "Učionica A23", BranchId = 1, RoomCategoryTypeId=2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 3, Name = "KancelarijaA", BranchId=2, RoomCategoryTypeId=2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 4, Name = "Učionica Mihajlo Pupin", BranchId=1, RoomCategoryTypeId=2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 5, Name = "KancelarijaB", BranchId=2, RoomCategoryTypeId=2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 6, Name = "Magacin-ITAkademija", BranchId=1, RoomCategoryTypeId=1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 7, Name = "Magacin-ITS", BranchId=2, RoomCategoryTypeId=1 });


            //Kreiranje Kategorije Prostorija
            modelBuilder.Entity<RoomCategoryType>().HasData(new RoomCategoryType { Id = 1, Name = "Magacinska prostorija"});
            modelBuilder.Entity<RoomCategoryType>().HasData(new RoomCategoryType { Id = 2, Name = "Radni prostor" });

            //Kreiranje Stanja Artikala Sa Serijskim Brojem
            modelBuilder.Entity<SerializedItemCondition>().HasData(new SerializedItemCondition { Id = 1, Name = "Aktivan" });
            modelBuilder.Entity<SerializedItemCondition>().HasData(new SerializedItemCondition { Id = 2, Name = "Na popravci" });
            modelBuilder.Entity<SerializedItemCondition>().HasData(new SerializedItemCondition { Id = 3, Name = "Rashodovan" });

            /*//Kreiranje Serijalizovanih Artikala
            modelBuilder.Entity<SerializedItem>().HasData(new SerializedItem { Id = 1, ItemId = 1, SerializedItemConditionId = 1, SerialNumber="XX-Acer-54",  ItemUserId =1, RoomId = 1 });
            modelBuilder.Entity<SerializedItem>().HasData(new SerializedItem { Id = 2, ItemId=2, SerializedItemConditionId=1, SerialNumber="XX-Benq-55", ItemUserId = 1, RoomId = 1 });*/

            // Kreiranje Dobavljača
            modelBuilder.Entity<Supplier>().HasData(new Supplier { Id = 1, Name = "Gigatron", CityId = 5, ContactEmailAddress = "gigatron@gmail.com", UniqueCompanyNumber = 123456789, AccountNumber = "111-258963-333" });
            modelBuilder.Entity<Supplier>().HasData(new Supplier { Id = 2, Name = "Tehnomanija", CityId = 5, ContactEmailAddress = "tehnomanija@gmail.com", UniqueCompanyNumber = 987654321, AccountNumber = "333-258963-111" });

            //Kreiranje Departmana
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Departman nije definisan" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name="Računovodstvo"});
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Nastava" });

            //Kreiranje Korisnika Aplikacije
            modelBuilder.Entity<ItemUser>().HasData(new ItemUser { Id = 1, Name = "Korisnik nije određen", LastName = "Korisnik nije određen", DepartmentId = 1 });
            modelBuilder.Entity<ItemUser>().HasData(new ItemUser { Id = 2, Name="Pera", LastName="Peric", DepartmentId=1 });
            modelBuilder.Entity<ItemUser>().HasData(new ItemUser { Id = 3, Name = "Mira", LastName="Miric", DepartmentId=2 });

        }


        
    }



}
