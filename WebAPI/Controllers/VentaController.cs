using Domain.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utils;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        [Route("GetListVentas")]
        public async Task<IActionResult> GetListVentas()
        {
            try
            {
                var listVentas = await _ventaService.GetListVentas();
                return Ok(listVentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetListVentasByUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListVentasByUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JwtConfigurator.GetIdUsuario(identity);
                var listVentas = await _ventaService.GetListVentasByUser(id);
                return Ok(listVentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
