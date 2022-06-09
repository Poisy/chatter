using System.Threading.Tasks;
using Chatter.Models;
using FireSharp;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Chatter.Services
{
    public class UserService
    {

        public UserService(IFirebaseClient client)
        {
            Client = client;
        }

        private IFirebaseClient Client { get; set; }
        public async Task<User> SetUser(User user)
        {
            PushResponse response = await Client.PushAsync("users", user);
            User result = response.ResultAs<User>(); //The response will contain the data written
            return result;
        }
        public async Task<User> UpdateUser(User user)
        {
            FirebaseResponse response = await Client.UpdateAsync("users", user);
            User result = response.ResultAs<User>(); //The response will contain the data written
            return result;
        }
    }
}