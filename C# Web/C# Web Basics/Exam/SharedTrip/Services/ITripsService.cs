namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;

    public interface ITripsService
    {
        void Add(TripAddInputModel tripAddInputModel);

        IEnumerable<TripsGetAllModel> GetAll();

        TripsDetailsViewModel GetById(string id);

        void AddUser(string userId, string tripId);

        bool HasUserJoinedTrip(string userId, string tripId);

        bool HasFreeSeats(string tripId);
    }
}
