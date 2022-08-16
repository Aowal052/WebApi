using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Entities;
using VehicleTracking.Infrastructure.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VehicleTracking.Infrastructure.Repositories
{
    public class VehicleGeoLocationRepository : RepositoryBase<VehicleGeoLocation>, IVehicleGeoLocationRepository
    {
        public VehicleGeoLocationRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VehicleGeoLocation>> GetAllByTimeAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            return await _context.VehicleGeoLocations.Where(x => x.UserId == userId && (x.TrackingDate >= fromDate && x.TrackingDate <= toDate)).ToListAsync();
        }

        public async Task<IEnumerable<VehicleGeoLocation>> GetAllByUserAsync(int userId)
{
            return await _context.VehicleGeoLocations.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
