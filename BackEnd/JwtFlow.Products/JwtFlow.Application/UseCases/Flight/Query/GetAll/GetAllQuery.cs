using JwtFlow.Domain.BackOffice.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Query.GetAll;

public record GetAllQuery(int Skip,int Take) : IRequest<IEnumerable<ProductFlight>>;