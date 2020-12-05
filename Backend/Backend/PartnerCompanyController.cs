using System;
using Backend.Data;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
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

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Update(PartnerCompany company)
		{
			try
			{
				_repository.Update(company);
				_repository.Save();

				return Ok();
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Add(PartnerCompany company)
		{
			try
			{
				_repository.Add(company);
				_repository.Save();

				return Ok();
			}
			catch(ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
