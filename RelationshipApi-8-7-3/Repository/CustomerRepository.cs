using Microsoft.EntityFrameworkCore;
using RelationshipApi_8_7_3.Data;
using RelationshipApi_8_7_3.Models;
using RelationshipApi_8_7_3.Models.Dto;

namespace RelationshipApi_8_7_3.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _data;
        public CustomerRepository(DataContext data)
        {
            _data = data;
        }

        public async Task AddCustomerCarDetails(AddCustomerCarDto dto)
        {
            // Add New Customer
            var newCustomer = new Customer
            {
                CustomerName = dto.CustomerName
            };

            // Add Customer to Db
            _data.Customers.Add(newCustomer);
            // Save Changes to Db
            await _data.SaveChangesAsync();

            var car = new Car
            {
                CarRego = dto.CarRego,
                CarModel = dto.CarModel,
                CarYear = dto.CarYear,
                CustomerId = newCustomer.CustomerId
            };

            // Add Car to Db
            _data.Cars.Add(car);
            // Save Changes to Db
            await _data.SaveChangesAsync();

            // Find Make By Id
            var make = await _data.Makes.FindAsync(dto.MakeId);

            // Adding Make to Car
            var carMake = new CarMake
            {
                CarId = car.CarId,
                MakeId = make.MakeId
            };

            // Add CarMake to Db
            _data.CarMakes.Add(carMake);
            // Save Changes to Db
            await _data.SaveChangesAsync();
        }

        public async Task<List<CustomerDto>> GetCustomerCarDetailsAsync()
        {
            return await _data.Customers
                .Include(c => c.Car)
                    .ThenInclude(car => car.CarMake)
                        .ThenInclude(cm => cm.Make)
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Car = c.Car.Select(car => new CarDto
                    {
                        CarId = car.CarId,
                        CarRego = car.CarRego,
                        CarModel = car.CarModel,
                        CarYear = car.CarYear,
                        CarMake = car.CarMake.Select(cm => new MakeDto
                        {
                            MakeId = cm.Make.MakeId,
                            MakeName = cm.Make.MakeName
                        }).ToList()
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<CustomerDto> GetCustomerCarDetailsByIdAsync(int id)
        {
            return await _data.Customers
                .Include(c => c.Car)
                    .ThenInclude(car => car.CarMake)
                        .ThenInclude(cm => cm.Make)
                .Where(c => c.CustomerId == id)
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Car = c.Car.Select(car => new CarDto
                    {
                        CarId = car.CarId,
                        CarRego = car.CarRego,
                        CarModel = car.CarModel,
                        CarYear = car.CarYear,
                        CarMake = car.CarMake.Select(cm => new MakeDto
                        {
                            MakeId = cm.Make.MakeId,
                            MakeName = cm.Make.MakeName
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task UpdateCustomerCarByIdAsync(int id, UpdateCustomerCarDto dto)
        {
            // Find Existing Customer 
            var customer = await _data.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if(customer == null)
            {
                throw new KeyNotFoundException("No Customer Found");
            }

            // Update Customer Details
            customer.CustomerName = dto.CustomerName;

            // Find Existing Car
            var car = await _data.Cars
                .FirstOrDefaultAsync(c => c.CustomerId == id && c.CarId == dto.CarId);
            if (car == null)
            {
                throw new KeyNotFoundException("CarId cannot be found");
            }

            // Update Car Details
            car.CarRego = dto.CarRego;
            car.CarModel = dto.CarModel;
            car.CarYear = dto.CarYear;

            // Find Make 
            var make = await _data.Makes.FindAsync(dto.MakeId);
            if(make == null)
            {
                throw new KeyNotFoundException("MakeId cannot be found");
            }

            // Remove the existing CarMake entries for the car
            var existingCarMake = _data.CarMakes.Where(cm => cm.CarId == car.CarId).ToList();
            _data.CarMakes.RemoveRange(existingCarMake);

            // Create new CarMake Entry
            var carMake = new CarMake
            {
                CarId = car.CarId,
                MakeId = make.MakeId
            };

            // Add CarMake to Db
            _data.CarMakes.Add(carMake);

            // Save changes to Db
            await _data.SaveChangesAsync();
        }
    }
}
