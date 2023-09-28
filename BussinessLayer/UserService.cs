using Microsoft.EntityFrameworkCore;
using PersistenceLayer;
using PersistenceLayer.Dtos;

namespace BussinessLayer
{
    public class UserService : IUserService
    {
        private readonly MyContext _db;

        public UserService(MyContext db)
        {
            _db = db;
        }

        public async Task<int> CreateAsync(CreateUserDto createUserDto)
        {
            if(createUserDto == null)
                throw new ArgumentNullException(nameof(createUserDto));

            var user = new User(createUserDto.Name, createUserDto.Surname, createUserDto.PhoneNumber);
            var res = await _db.AddAsync(user);
            await _db.SaveChangesAsync();

            return res.Entity.Id;
        }

        public async void Delete(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id)  
                                 ?? throw new KeyNotFoundException("There isn't user with this Id");

            _db.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id)
                            ?? throw new KeyNotFoundException("There isn't user with this Id");

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _db.Users.AsNoTracking().ToArrayAsync();
            return users;
        }

        public async Task<User> UpdateAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("There isn't user with this Id");
            user.Surname = updateUserDto.Surname;
            user.Name = updateUserDto.Name;
            user.PhoneNumber = updateUserDto.PhoneNumber;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}