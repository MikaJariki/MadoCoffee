using MadoCoffee.DTO;
using MadoCoffee.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MadoCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly TableRepository _t;
        public TablesController(TableRepository t)
        {
            _t = t;
        }

        [HttpGet("GetAllTables")]
        public IActionResult Get(string tableLocation = null)
        {
            var result = _t.GetAllTables(tableLocation);
            return Ok(new
            {
                message = "Lấy dữ liệu thành công",
                statusCode = StatusCodes.Status200OK,
                data = result
            });
        }

        [HttpGet("GetTableById/{id}")]
        public IActionResult GetById(long id)
        {
            var result = _t.GetTablesById(id);
            return Ok(new
            {
                message = "Lấy dữ liệu thành công",
                statusCode = StatusCodes.Status200OK,
                data = result
            });
        }

        [HttpPost("AddTable")]
        public IActionResult Add([FromBody] TableDto tableDto)
        {
            _t.CreateTables(tableDto);
            _t.Save();
            return Ok(new
            {
                message = "Thêm dữ liệu thành công",
                statusCode = StatusCodes.Status200OK,
               
            });
        }

        [HttpPut("UpdateTable/{id}")]
        public IActionResult Update(long id, [FromBody] TableDto tableDto)
        {
            _t.UpdateTables(id,tableDto);
            _t.Save();

            return Ok(new
            {
                message = "Sửa dữ liệu thành công",
                statusCode = StatusCodes.Status201Created,

            });
        }

        [HttpDelete("DeleteTable/{id}")]
        public IActionResult Delete(long id)
        {
            _t.DeleteTables(id);
            _t.Save();
            return Ok(new
            {
                message = "Xóa dữ liệu thành công",
                statusCode = StatusCodes.Status200OK,

            });
        }
    }
}
