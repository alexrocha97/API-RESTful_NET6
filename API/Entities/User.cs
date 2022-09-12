using API.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public class User : BaseEntity
    {
        public User(string email, string password, Status status)
        {
            Email = email;
            Password = password;
            Status = status;
            PublishDate = DateTime.Now;

            ValidateEntity();
        }
        
        public string Email { get; set; }
        public string Password { get; set; }

        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Email, "O título não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(Password, "O chapéu não pode estar vazio!");

            AssertionConcern.AssertArgumentLength(Email, 90, "O título deve ter até 90 caracteres!");
            AssertionConcern.AssertArgumentLength(Password, 40, "O chapéu deve ter até 40 caracteres!");
        }
    }
}
