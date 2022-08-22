using DapperTest.Models;

namespace DapperTest.BL.Interfaces
{
    public interface IUserBL
    {
        int? Aunthenticate(string email, string password);

        User GetUserById(int userId);

        Task<User> Add(User user);


        public int FindIdUser(string email);

        Task<IEnumerable<User>> Aunthenticate2(int UserId);

        IEnumerable<User> FindAll(string email);
    }

}
