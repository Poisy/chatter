using Google.Cloud.Firestore;

namespace Chatter.Models
{
    [FirestoreData]
    public class FirestoreUserModel
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
    }
}