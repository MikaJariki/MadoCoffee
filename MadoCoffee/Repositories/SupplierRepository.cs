using MadoCoffee.DTO;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext appDbContext;

        public SupplierRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void CreateSupplier(SupplierDto supplierDto)
        {
            var result = new Supplier
            {
                ID = supplierDto.Id,
                Name = supplierDto.Name,
                Phone = supplierDto.PhoneNo,
                Address = supplierDto.Address,
                Representative = supplierDto.Representative,
                Email = supplierDto.Email,
            };

            appDbContext.Suppliers.Add(result);
        }

        public SupplierDto GetSupplierById(long id)
        {
           var result = from supplier in appDbContext.Suppliers
                        where supplier.ID == id
                        select new SupplierDto
                        {
                            Id = supplier.ID,
                            Name = supplier.Name,
                            PhoneNo = supplier.Phone,
                            Address = supplier.Address,
                            Representative = supplier.Representative,
                            Email = supplier.Email,
                        };
            return result.FirstOrDefault();
        }

        public List<SupplierDto> GetAllSupplier(string supplierName)
        {   
            var result = from supplier in appDbContext.Suppliers
                         where supplierName == null || supplier.Name.Contains(supplierName)
                         select new SupplierDto
                         {
                             Id = supplier.ID,
                             Name = supplier.Name,
                             PhoneNo = supplier.Phone,
                             Address = supplier.Address,
                             Representative = supplier.Representative,
                             Email = supplier.Email,
                         };
            return result.ToList();
        }

        public void UpdateSupplier(long id, SupplierDto updatedSupplier)
        {
           var exist = appDbContext.Suppliers.Find(id);
            if (exist != null) { 
                exist.Name = updatedSupplier.Name;
                exist.Phone = updatedSupplier.PhoneNo;
                exist.Address = updatedSupplier.Address;
                exist.Representative = updatedSupplier.Representative;
                exist.Email = updatedSupplier.Email;
            }
        }

        public void DeleteSupplier(long id)
        {
            var supplier = appDbContext.Suppliers.Find(id);
            appDbContext.Suppliers.Remove(supplier);
        }

        public void Save()
        {
            appDbContext.SaveChanges();
        }
    }
}
