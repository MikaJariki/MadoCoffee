using MadoCoffee.DTO;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public interface ISupplierRepository
    {
        void CreateSupplier(SupplierDto newSupplier);
        SupplierDto GetSupplierById(long id);
        List<SupplierDto> GetAllSupplier(string supplierName);
        void UpdateSupplier(long id, SupplierDto updatedSupplier);
        void DeleteSupplier(long id);

        void Save();
    }
}
