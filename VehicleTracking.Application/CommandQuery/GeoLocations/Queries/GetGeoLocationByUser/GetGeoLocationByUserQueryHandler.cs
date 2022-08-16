using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocationByTime;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Dtos;
using VehicleTracking.Entity.Entities;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocationByUser
{
    public class GetGeoLocationByUserQueryHandler : IRequestHandler<GetGeoLocationByUserQuery, List<VehicleGeoLocationDto>>
    {
        private readonly IMapper _iMapper;
        private readonly IVehicleGeoLocationRepository _iVehicleGeoLocationRepository;
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public GetGeoLocationByUserQueryHandler(IMapper iMapper, IVehicleGeoLocationRepository iVehicleGeoLocationRepository, IHttpContextAccessor iHttpContextAccessor)
        {
            _iMapper = iMapper;
            _iVehicleGeoLocationRepository = iVehicleGeoLocationRepository;
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public async Task<List<VehicleGeoLocationDto>> Handle(GetGeoLocationByUserQuery request, CancellationToken cancellationToken)
        {
            var location = await GetLocationByGeoLocation("10.2365498", "15.12345687");
            var items = await _iVehicleGeoLocationRepository.GetAllByUserAsync(request.userId);
            return _iMapper.Map<List<VehicleGeoLocationDto>>(items);
        }

        private async Task<string> GetLocationByGeoLocation(string longitude, string latitude)
        {
            string locationName = string.Empty;

            if (string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
                return "";

            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", latitude, longitude);


            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(url);
                var content = await request.Content.ReadAsStringAsync();
                var xmlDocument = XDocument.Parse(content);

            }


            return locationName;
        }
    }
}
