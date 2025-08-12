using AutoMapper;
using RAC.Communication.Requests;
using RAC.Communication.Responses;
using RAC.Domain.Entities;

namespace RAC.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();

    }

    public void RequestToEntity()
    {
        CreateMap<RequestCar, Car>();
        CreateMap<RequestUser, User>();
    }

    public void EntityToResponse()
    {
        CreateMap<Car, ResponseCarRegistered>();
        CreateMap<Car, CarInformation>();
    }
}
