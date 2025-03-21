using MadoCoffee.DTO;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public interface ITable
    {
        List<TableDto> GetAllTables(string tableNumber);
        TableDto GetTablesById(long id);
        void CreateTables(TableDto newTable);
        void UpdateTables(long id, TableDto updatedTable);
        void DeleteTables(long id);
        void Save();
    }
}
