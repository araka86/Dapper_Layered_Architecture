using DapperTest.Dal.Interfaces;
using Dapper;
using DapperTest.Models;

namespace DapperTest.Dal.Implementation
{
    public class UserDal : IUserDal
    {     
        public IEnumerable<User> FindByEmail(string email)
        {
           using(var connection = DbConnections.CreateConnection())
            {

              return  connection.Query<User>("select * from [User] where Email = @_email",
                    new
                    {
                        _email = email
                    });
            }

        }

        public User FindById(int id)
        {
            using (var connection = DbConnections.CreateConnection())
            {

                var res = connection.QueryFirstOrDefault<User>("select * from [User] where UserId = @_id",
                      new
                      {
                          _id = id
                      });


                return connection.QueryFirstOrDefault<User>("select * from [User] where UserId = @_id",
                      new
                      {
                          _id = id
                      });
            }
        }

        public Task<IEnumerable<User>> FindUser(int UserId)
        {
            using (var connection =  DbConnections.CreateConnection())
            {

                return Task.FromResult(connection.Query<User>("select * from [User] where UserId = @_UserId",
                      new
                      {
                          _UserId = UserId
                      }));
            }
        }

      





        public async Task<User> InsertAsync(User user)
        {
            using (var connection = DbConnections.CreateConnection())
            {


              return  await connection.QueryFirstAsync<User>(@"INSERT INTO [dbo].[User] ([UserId]) VALUES (@UserId)",
              new
              {
                  UserId = user.UserId
              });
            }
            
        }
    }
}
