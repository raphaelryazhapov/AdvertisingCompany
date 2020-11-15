using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Web
{
	[Route("api/PartnerCompany")]
	[ApiController]
	public class PartnerCompanyController : ControllerBase
	{
		private readonly IRepository<PartnerCompany> _repository;

		public PartnerCompanyController(IRepository<PartnerCompany> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult GetAllCompanies()
		{
			try
			{
				var companies = _repository.GetAll();

				return Ok(companies);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		[Route("{Id}")]
		public IActionResult Delete(Guid Id)
		{
			try
			{
				_repository.DeleteById(Id);
				_repository.Save();

				return Ok();
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
