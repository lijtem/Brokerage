using AutoMapper;
using Brokerage.Controllers.Resources;
using Brokerage.Core.Models;
using System;
using System.Linq;

namespace Brokerage.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Remark, RemarkResource>();
            CreateMap<HousePhoto, PhotoResource>();
            CreateMap<Photo, PhotoResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
              .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResource { Id = vf.Feature.Id, Name = vf.Feature.Name })));
            // .ForMember(vr => vr.Photos, opt => opt.MapFrom(v => v.Photos.Select(vf => new Photo { FileName = vf.FileName})));
            //House
            CreateMap<City, CityResource>();
            CreateMap<City, KeyValuePairResource>();
            CreateMap<Location, KeyValuePairResource>();
            CreateMap<House, SaveHouseResource>()
                 .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }));
            CreateMap<House, HouseResource>()
                .ForMember(hr => hr.City, opt => opt.MapFrom(h => h.Location.City))
                .ForMember(hr => hr.Contact, opt => opt.MapFrom(h => new ContactResource { Name = h.ContactName, Email = h.ContactEmail, Phone = h.ContactPhone }));

            // API Resource to Domain
            CreateMap<VehicleQueryResource, VehicleQuery>();
            CreateMap<SaveVehicleResource, Vehicle>()
              .ForMember(v => v.Id, opt => opt.Ignore())
              .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
              .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
              .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
              .ForMember(v => v.Features, opt => opt.Ignore())
              .AfterMap((vr, v) => {
                  // Remove unselected features
                  var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                  foreach (var f in removedFeatures)
                      v.Features.Remove(f);

                  // Add new features
                  var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id }).ToList();
                  foreach (var f in addedFeatures)
                      v.Features.Add(f);
              });
            // house
            CreateMap<HouseQueryResource, HouseQuery>();
            CreateMap<SaveHouseResource, House>()
                .ForMember(h => h.Id, opt => opt.Ignore())
                .ForMember(h => h.ContactName, opt => opt.MapFrom(hr => hr.Contact.Name))
                 .ForMember(h => h.ContactEmail, opt => opt.MapFrom(hr => hr.Contact.Email))
                  .ForMember(h => h.ContactPhone, opt => opt.MapFrom(hr => hr.Contact.Phone));
        }
    }
}
