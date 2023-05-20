using JobBoardAPI.Models;

namespace JobBoardAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<User> Authenticate(string username, string password);

        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }

}
