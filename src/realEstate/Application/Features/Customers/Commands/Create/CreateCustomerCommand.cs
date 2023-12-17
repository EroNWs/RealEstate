using Application.Features.Customers.Constants;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using static Application.Features.Customers.Constants.CustomersOperationClaims;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommand : IRequest<CreatedCustomerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string CustomerName { get; set; }
    public string CustomerSurName { get; set; }
    public string? CustomerSecondSurname { get; set; }
    public string? CustomerSecondName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public Occupation Occupatipon { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public string HomePhone { get; set; }
    public string MobilePhone { get; set; }
    public byte NumberOfChildren { get; set; }
    public string Email { get; set; }
    public Occupation SpouseOccupation { get; set; }
    public DateTime SpouseBirthDate { get; set; }
    public bool IsBuyerCustomer { get; set; }
    public bool IsSellerCustomer { get; set; }
    public bool IsTenantCustomer { get; set; }
    public bool IsRenterCustomer { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public Guid EstateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomers";

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository,
                                         CustomerBusinessRules customerBusinessRules)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<CreatedCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = _mapper.Map<Customer>(request);

            await _customerRepository.AddAsync(customer);

            CreatedCustomerResponse response = _mapper.Map<CreatedCustomerResponse>(customer);
            return response;
        }
    }
}