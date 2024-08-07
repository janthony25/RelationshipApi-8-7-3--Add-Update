using RelationshipApi_8_7_3.Models.Dto;

namespace RelationshipApi_8_7_3.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDto>> GetCustomerCarDetailsAsync();
        Task<CustomerDto> GetCustomerCarDetailsByIdAsync(int id);
        Task AddCustomerCarDetails(AddCustomerCarDto dto);
        Task UpdateCustomerCarByIdAsync(int id, UpdateCustomerCarDto dto);
    }
}
