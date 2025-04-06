using Microsoft.AspNetCore.Mvc;
using WorkshopBookingSystemWebAPI.Interfaces;
using FluentValidation;
using WorkshopBookingSystemWebAPI.DTOs;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypesController : ControllerBase
    {
        private readonly IServiceTypeService _serviceTypeService;
        public ServiceTypesController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        // GET: api/ServiceTypes
        [HttpGet("Get all ServiceTypes")]
        public async Task<ActionResult<IEnumerable<ServiceTypeDto>>> GetAllServiceTypes()
        {
            var serviceTypes = await _serviceTypeService.GetAllServiceTypes();
            if (serviceTypes == null || !serviceTypes.Any())
            {
                return NotFound("No service types where found.");
            }

            return Ok(serviceTypes);
        }

        // GET: api/ServiceTypes/5
        [HttpGet("Get ServiceType with {serviceTypeId}")]
        public async Task<ActionResult<ServiceTypeDto>> GetServiceType(int serviceTypeId)
        {
            var serviceType = await _serviceTypeService.GetServiceTypeById(serviceTypeId);
            if (serviceType == null)
            {
                return NotFound($"No service type found with ID {serviceTypeId}");
            }

            return Ok(serviceType);
        }

        // POST: api/ServiceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create ServiceType")]
        public async Task<ActionResult> PostServiceType(ServiceTypeInputDto serviceType)
        {
            try
            {
                var newServiceType = await _serviceTypeService.CreateServiceType(serviceType);
                return Ok(newServiceType);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(errors);
            }
        }

        // PUT: api/ServiceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update ServiceType with {serviceTypeId}")]
        public async Task<IActionResult> UpdateServiceType(int serviceTypeId, ServiceTypeInputDto serviceType)
        {
            try
            {
                var updatedServiceType = await _serviceTypeService.UpdateServiceType(serviceTypeId, serviceType);

                if (updatedServiceType == null)
                {
                    return NotFound($"No service type found with ID {serviceTypeId}");

                }

                return Ok(updatedServiceType);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(errors);
            }
        }

        // DELETE: api/ServiceTypes/5
        [HttpDelete("Delete ServiceType{serviceTypeId}")]
        public async Task<IActionResult> DeleteServiceType(int serviceTypeId)
        {
            var serviceType = await _serviceTypeService.DeleteServiceType(serviceTypeId);
            if (!serviceType)
            {
                return NotFound($"No service type found with ID {serviceTypeId}");
            }

            return NoContent();
        }
    }
}
