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
        public async Task AddUser(User user)
        {
            CollectionReference collection = _db.Collection("users");
            DocumentReference document = await collection.AddAsync(new { FirstName = user.FirstName, LastName = user.LastName });
        }
        #endregion
    }
}