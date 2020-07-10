namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(TripAddInputModel tripAddInputModel)
        {
            try
            {
                var date = DateTime.ParseExact(tripAddInputModel.DepartureTime,
                "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = new Trip()
                {
                    StartPoint = tripAddInputModel.StartPoint,
                    EndPoint = tripAddInputModel.EndPoint,
                    DepartureTime = date,
                    ImagePath = tripAddInputModel.ImagePath,
                    Seats = tripAddInputModel.Seats,
                    Description = tripAddInputModel.Description
                };

                this.db.Trips.Add(trip);
                this.db.SaveChanges();
            }
            catch (Exception e)
            {
                this.ErrorOccured = true;
            }
        }

        public void AddUser(string userId, string tripId)
        {
            var trip = this.GetTripById(tripId);

            trip.Seats--;

            var userTrip = new UserTrip()
            {
                UserId = userId,
                TripId = tripId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripsGetAllModel> GetAll()
            => this.db.Trips.Select(x => new TripsGetAllModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Seats = x.Seats
            })
            .OrderBy(x => x.StartPoint)
            .ThenBy(x => x.EndPoint)
            .ToArray();

        public TripsDetailsViewModel GetById(string id)
        {
            var trip = this.db.Trips.Where(x => x.Id == id)
                .Select(x => new TripsDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    Description = x.Description,

                }).FirstOrDefault();

            return trip;
        }

        public bool HasUserJoinedTrip(string userId, string tripId)
        {
            var userTrip = this.GetUserTripById(userId, tripId);

            if (userTrip == null)
            {
                return false;
            }
            
            return true;
        }

        private Trip GetTripById(string tripId)
            => this.db.Trips.FirstOrDefault(x => x.Id == tripId);

        private UserTrip GetUserTripById(string userId, string tripId)
            => this.db.UserTrips.FirstOrDefault(x => x.UserId == userId && x.TripId == tripId);

        public bool HasFreeSeats(string tripId)
        {
            var trip = this.GetTripById(tripId);

            if (trip.Seats < 1)
            {
                return false;
            }

            return true;
        }

        public bool ErrorOccured { get; private set; } = false;
    }
}
