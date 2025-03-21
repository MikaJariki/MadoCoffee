using MadoCoffee.DTO;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public class TableRepository : ITable
    {
        private readonly AppDbContext _context;
        public TableRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TableDto> GetAllTables(string tableLocation)
        {
            var result = from table in _context.Tables
                         where tableLocation == null || table.Location.Contains(tableLocation)
                         select new TableDto
                         {
                             Id = table.ID,
                             Number = table.Number,
                             Capacity = table.Capacity,
                             Location = table.Location,
                             Status = table.Status,
                         };
            return result.ToList();
        }
        public TableDto GetTablesById(long id)
        {
            var result = (from table in _context.Tables
                         where table.ID == id
                         select new TableDto
                         {
                             Id = table.ID,
                             Number = table.Number,
                             Capacity = table.Capacity,
                             Location = table.Location,
                             Status = table.Status,
                         }).FirstOrDefault();

            return result;
        }
        public void CreateTables(TableDto newTable)
        {
            var table = new Table
            {
                ID = newTable.Id,
                Number = newTable.Number,
                Capacity = newTable.Capacity,
                Location = newTable.Location,
                Status = newTable.Status,
            };

            _context.Tables.Add(table);
        }
        public void UpdateTables(long id, TableDto updatedTable)
        {
            var existId = _context.Tables.Find(id);
            if(existId != null)
            {

            existId.Number = updatedTable.Number;
            existId.Capacity = updatedTable.Capacity;
            existId.Location = updatedTable.Location;
            existId.Status = updatedTable.Status;
            }
        }
        public void DeleteTables(long id)
        {    
            
            var existId = _context.Tables.Find(id);
            if (id != null)
            {

            _context.Tables.Remove(existId);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
