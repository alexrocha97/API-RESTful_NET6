using API.Domain;
using API.Entities.Enums;
using API.Infra;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public class Video : BaseEntity
    {
        public Video(
            string Hat, 
            string title,
            string author, 
            string thumbnail, 
            Status status, 
            string url)
        {
            this.Hat = Hat;
            Title = title;
            Author = author;
            Thumbnail = thumbnail;
            PublishDate = DateTime.Now;
            Slug = Helper.GenerateSlug(title);
            Status = status;
            Url = url;

            ValidateEntity();
        }

        [BsonElement("Hat")]
        public string Hat { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("Thumbnail")]
        public string Thumbnail { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }

        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Title, "O título não pode está vazio");
            AssertionConcern.AssertArgumentNotEmpty(Hat, "O chapéu não pode está vazio");

            AssertionConcern.AssertArgumentLength(Title, 90, "O título deve ter até 90 caracteres");
            AssertionConcern.AssertArgumentLength(Hat, 40, "O chapéu deve ter até 40 caracteres");
        }
    }
}
