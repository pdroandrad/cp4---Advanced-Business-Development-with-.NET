using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace livros.Models
{
    public class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Titulo")]
        public string Titulo { get; set; }

        [BsonElement("AnoPublicacao")]
        public int AnoPublicacao { get; set; }

        [BsonElement("Autor")]
        public List<Autor> Autor { get; set; }

    }
}
