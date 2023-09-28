using PersistenceLayer;
using PersistenceLayer.Dtos;

namespace BussinessLayer
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserDto createUserDto);
        Task<User> UpdateAsync(int id, UpdateUserDto updateUserDto);
        void Delete(int id);
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
