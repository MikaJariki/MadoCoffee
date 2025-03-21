using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MadoCoffee;
using MadoCoffee.Models;
using MadoCoffee.Services;
using MadoCoffee.DTO;
using MadoCoffee.Repositories;

namespace MadoCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _s;

        public SuppliersController(ISupplierRepository supplier)
        {
           _s = supplier;
        }

        // GET: api/Suppliers
        [HttpGet("GetAllSuppliers")]
        public IActionResult GetSuppliers(string supplierName = null)
        {
            var data = _s.GetAllSupplier(supplierName);
            return Ok(new { message = "Lấy giữ liệu thành công ", statusCode = StatusCodes.Status200OK, data = data });
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public IActionResult GetSupplier(long id)
        {
            var data = _s.GetSupplierById(id);

            if (data == null)
            {
                return NotFound(new {message = "Không tìm thấy người dùng", statusCode = StatusCodes.Status404NotFound});
            }

            return Ok(new { message = "Lấy giữ liệu thành công ", statusCode = StatusCodes.Status200OK, data = data });
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("UpdateSupplier/{id}")]
        public IActionResult PutSupplier(long id, [FromBody] SupplierDto supplier)
        {
            var existId = _s.GetSupplierById(id);
            if (existId == null) { 
            return NotFound(new { message = "Không tìm thấy người dùng", statusCode = StatusCodes.Status404NotFound });
            }

            _s.UpdateSupplier(id, supplier);
            _s.Save();
            return Ok(new
            {
                message = "Cập nhật thành công",
                statusCode = StatusCodes.Status200OK
            });
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddSupplier")]
        public IActionResult PostSupplier([FromBody] SupplierDto supplier)
        {
            _s.CreateSupplier(supplier);
            _s.Save();
            return Ok(new {message = "Thêm mới thành công", statusCode = StatusCodes.Status201Created });
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("DeleteSupplier/{id}")]
        public IActionResult DeleteSupplier(long id)
        {
            var supplier = _s.GetSupplierById(id);
            if (supplier == null)
            {
                return NotFound();
            }

           _s.DeleteSupplier(id);
           _s.Save();
            return Ok(new
            {
                message = "Xóa thành công",
                statusCode = StatusCodes.Status200OK
            });
        }

        
    }
}
