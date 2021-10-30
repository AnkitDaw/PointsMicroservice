using Newtonsoft.Json;
using PointsMicroservice.Constants;
using PointsMicroservice.Models;
using PointsMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PointsMicroservice.Services
{
    public class PointsService : IConstant
    {
        public Dictionary<int, int> EmployeePoints = new Dictionary<int, int>()
        {
            {101,250},
            {102,260},
            {103,275},
            {104,480},
            {105,490},
            {201,0}
        };
        Helper _api = new Helper();
        public readonly PointsRepository _points;
        public PointsService()
        {
            _points = new PointsRepository();
        }
        public int GetLikesInTwoDays(int id, DateTime date)
        {
            int count = _points.Likes.Where(c => c.LikeDate == date && c.OfferId == id).Count();

            int count1 = _points.Likes.Where(c => c.LikeDate == date.AddDays(1) && c.OfferId == id).Count();

            // int count2 = Likes.Where(c => c.LikeDate == date.AddDays(2) && c.OfferId == id).Count();
            int totalLikes = count + count1;
            return totalLikes;
        }

        public async Task<List<OfferData>> GetList()
        {
            List<OfferData> offers = new List<OfferData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/offer/GetOffersList");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                offers = JsonConvert.DeserializeObject<List<OfferData>>(results);
            }
            return offers;
        }
        public async Task<Points> RefreshPointsByEmployee(int employeeId)
        {
            int id, likes_two_days, totalPoints = 0;
            Points points = new Points();
            DateTime date;
            List<OfferData> newOffers = await GetList();
            var employeeoffer = newOffers.Where(c => c.EmployeeId == employeeId).ToList();
            foreach (var e in employeeoffer)
            {
                id = e.OfferId;
                date = e.OpenedDate;
                likes_two_days = GetLikesInTwoDays(id, date);
                e.LikesInTwoDays = likes_two_days;
            }
            foreach (var e in employeeoffer)
            {
                TimeSpan engaggedDuration = e.EngagedDate - e.OpenedDate;
                if (e.LikesInTwoDays > 50)
                    totalPoints += 10;
                else if (e.LikesInTwoDays > 100)
                    totalPoints += 50;
                else if (e.Status == "Engaged" && engaggedDuration.TotalDays <= 2)
                {
                    totalPoints += 100;
                }
            }
            EmployeePoints[employeeId] += totalPoints;
            points.EmployeeId = employeeId;
            points.TotalPoints = EmployeePoints[employeeId];
            return points;
        }
    }
}