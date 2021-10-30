using PointsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsMicroservice.Constants
{
    public interface IConstant
    {
        public Task<List<OfferData>> GetList();
        public int GetLikesInTwoDays(int id, DateTime date);

        public Task<Points> RefreshPointsByEmployee(int employeeId);
        public static Dictionary<int, int> EmployeePoints = new Dictionary<int, int>()
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
