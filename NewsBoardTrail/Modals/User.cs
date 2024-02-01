using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NewsBoardBE.Modals
{
    [CollectionName("User")]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = string.Empty;

        [BsonElement("username")]
        public string? UserName { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("first_name")]

        public string Fname { get; set; }
        [BsonElement("middle_name")]
        public string Mname { get; set; }
        [BsonElement("last_name")]
        public string Lname { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("profile_picture")]

        public string ProfilePicture { get; set; }
        [BsonElement("preferences")]

        public string Preferenceid { get; set; }
        [BsonElement("registration_date")]

        public DateTime RegistrationDate { get; set; }
        [BsonElement("bio")]

        public string Bio { get; set; }
        [BsonElement("country")]

        public string Country { get; set; }
        [BsonElement("last_login_date")]


        public DateTime LastLoginDate { get; set; }
        [BsonElement("language")]

        public string Language { get; set; }
        [BsonElement("date_of_birth")]

        public DateTime DateOfBirth { get; set; }
        [BsonElement("gender")]

        public string Gender { get; set; }
        [BsonElement("phone_number")]

        public string PhoneNumber { get; set; }
        [BsonElement("address")]

        public string Address { get; set; }
        [BsonElement("profile_visibility")]

        public string ProfileVisibility { get; set; }
        [BsonElement("profile_theme")]

        public string Profile_theme { get; set; }
        [BsonElement("notification_preferences_id")]

        public string NotificationPreferencesID { get; set; }
        [BsonElement("two_factor_auth_enabled")]

        public bool TwoFactorAuthEnabled { get; set; }
        [BsonElement("last_password_change_date")]

        public DateTime LastPasswordChangeDate { get; set; }
    }
}
