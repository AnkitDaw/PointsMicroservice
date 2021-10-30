using PointsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsMicroservice.Repositories
{
    public class PointsRepository
    {
        public List<Like> Likes = new List<Like>()
            {
                new Like() {OfferId=1,LikeDate= new DateTime(2021, 10, 01)},
                new Like() {OfferId =1, LikeDate = new DateTime(2021, 10, 01)},
                new Like() { OfferId = 1, LikeDate = new DateTime(2021, 10, 02) },

                new Like() { OfferId = 2, LikeDate = new DateTime(2021, 10, 01) },
                new Like() { OfferId = 2, LikeDate = new DateTime(2021, 10, 02) },
                new Like() { OfferId = 2, LikeDate = new DateTime(2021, 10, 01) },
                new Like() { OfferId = 2, LikeDate = new DateTime(2021, 10, 01) },
                new Like() { OfferId = 2, LikeDate = new DateTime(2021, 10, 02) },
                new Like() { OfferId = 2, LikeDate = new DateTime(2021, 10, 01) },

                new Like() {OfferId=3,LikeDate= new DateTime(2021, 10, 04)},
                new Like() {OfferId =3, LikeDate = new DateTime(2021, 10, 05)},
                new Like() { OfferId = 3, LikeDate = new DateTime(2021, 10, 05) },
                new Like() { OfferId = 3, LikeDate = new DateTime(2021, 10, 06) },

                new Like() { OfferId = 4, LikeDate = new DateTime(2021, 10, 09) },
                new Like() { OfferId = 4, LikeDate = new DateTime(2021, 10, 10) },
                new Like() { OfferId = 4, LikeDate = new DateTime(2021, 05, 10) },

                new Like() { OfferId = 5, LikeDate = new DateTime(2021, 10, 10) },
                new Like() { OfferId = 5, LikeDate = new DateTime(2021, 10, 11) },
                new Like() { OfferId = 5, LikeDate = new DateTime(2021, 10, 11) },
                new Like() { OfferId = 6, LikeDate = new DateTime(2021, 10, 12) },

            };

    }
}
