using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PointsMicroservice.Models;
using PointsMicroservice.Repositories;
using PointsMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PointsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class PointsController : ControllerBase
    {
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PointsController));
        Helper _api = new Helper();
        public readonly PointsService _service;
        public PointsController()
        {
            _service = new PointsService();
        }
        [HttpGet]
        [Route("GetList")]
        public async Task<List<OfferData>> GetList()
        {
            _log4net.Info("GetList Method Called and result is displayed");
            return await _service.GetList();
        }

        [HttpGet]
        [Route("GetLikeIn2Days/{id}/{date}")]
        public int GetLikesInTwoDays(int id, DateTime date)
        {
            _log4net.Info("GetLikesIn2Days Method Called and result is displayed");
            return _service.GetLikesInTwoDays(id, date);

        }
        [HttpGet]
        [Route("RefreshPointsByEmployee/{employeeId}")]
        public async Task<ActionResult> RefreshPointsByEmployee(int employeeId)
        {
                _log4net.Info("Total points result is displayed");
                return Ok(await _service.RefreshPointsByEmployee(employeeId));
        }

        [HttpGet]
        [Route("GetPointsByEmployeeId/{employeeId}")]
        public ActionResult GetPointsByEmployeeId(int employeeId)
        {
            int p;
            Points point = new Points();
            for (int i = 0; i < _service.EmployeePoints.Count; i++)
            {
                if (_service.EmployeePoints.ElementAt(i).Key == employeeId)
                {
                    p = _service.EmployeePoints.ElementAt(i).Value;

                    point.TotalPoints = p;
                    point.EmployeeId = employeeId;
                    _log4net.Info("GetPoints Method Called and result is displayed");
                    return Ok(point);
                }
            }
            return Ok(0);
        }
        public Dictionary<int, int> EmployeePoints = new Dictionary<int, int>()
        {
            {101,250},
            {102,260},
            {103,275},
            {104,480},
            {105,490},
            {201,0}
        };
    }
}
