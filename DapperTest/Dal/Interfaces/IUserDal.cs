using DapperTest.Models;

namespace DapperTest.Dal.Interfaces
{
    public interface IUserDal
    {

        IEnumerable<User> FindByEmail(string email);
        User FindById(int id);

       

        Task<User> InsertAsync(User user);

        Task<IEnumerable<User>> FindUser(int UserId);


    }
}
