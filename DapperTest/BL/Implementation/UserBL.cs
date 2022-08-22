using DapperTest.BL.Interfaces;
using DapperTest.Dal.Interfaces;
using Dapper;
using DapperTest.Models;
using System.Data.Common;
using DapperTest.Dal.Implementation;

namespace DapperTest.BL.Implementation
{
    public class UserBL : IUserBL
    {
        public readonly IUserDal _userDal;
        public UserBL(IUserDal userDal)
        {
             _userDal = userDal;
        }

        public Task<User> Add(User user)
        {
            return _userDal.InsertAsync(user);
        }

        public int? Aunthenticate(string email, string password)
        {
            string enpass = Encrypt(password);

            foreach (User user in _userDal.FindByEmail(email))
            {
                if(user.Password == enpass)
                {
                   
                    return user.UserId;
                }
            }
            return null;
        }


        
        public async Task<IEnumerable<User>> Aunthenticate2(int UserId)
        {
            
            var us = await _userDal.FindUser(UserId);

          
            return us;
        }



        public IEnumerable<User> FindAll(string email)
        {
            var connection = DbConnections.CreateConnection();
         var res =   connection.Query<User>("select * from [User] where Email = @_email",
                     new
                     {
                         _email = email
                     });

            return res;
        }

        


        public string Encrypt(string password) => password;

        public User GetUserById(int userId)
        {
            return _userDal.FindById(userId);
        } 

        public int FindIdUser(string email)
        {
            var conn = DbConnections.CreateConnection();
            var userid = conn.Query<User>("select * from [User] where Email = @_email",
                    new
                    {
                        _email = email
                    });

             
            return userid.Select(x => x.UserId).FirstOrDefault();
        }

       
    }
}
