using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chatter.Models;
using Google.Cloud.Firestore;

namespace Chatter.Services
{
    public class UserService
    {
        #region Properties and fields
        private readonly FirestoreDb _db;
        #endregion


        public UserService(FirestoreDb db)
        {
            _db = db;
        }


        #region Methods
        public async Task AddUser(RegisterModel user)
        {
            CollectionReference collection = _db.Collection("users");
            DocumentReference document = await collection.AddAsync(new 
            { 
                Email = user.Email, 
                Username = user.Username, 
                Password = user.Password
            });
        }

        public async Task<UserModel> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FirestoreUserModel> GetUser(string email)
        {
            CollectionReference collection = _db.Collection("users");
            Query query = collection.WhereEqualTo("Email", email);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            DocumentSnapshot document = querySnapshot.Documents.FirstOrDefault();
            FirestoreUserModel user = document.ConvertTo<FirestoreUserModel>();

            return user;
        }
        #endregion
    }
}