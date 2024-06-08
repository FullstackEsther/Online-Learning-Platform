using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Newtonsoft.Json;

namespace Domain.DomainServices
{
    public class ResultHelper
    {
        public static Dictionary<Question, string> DeserializeDictionary(Result result)
        {
            if (result.SerializedResponse != null)
            {
                var deserialized = JsonConvert.DeserializeObject<Dictionary<Question, string>>(result.SerializedResponse, new DictionaryConverter());
                return deserialized;
            }
            throw new ArgumentException("No content to Deserialize");

        }

        public static string SerializeDictionary(Dictionary<Question, string> answers)
        {
            var json = JsonConvert.SerializeObject(answers, new DictionaryConverter());
            return json;
        }
    }

    public class DictionaryConverter : JsonConverter<Dictionary<Question, string>>
    {
        public override void WriteJson(JsonWriter writer, Dictionary<Question, string> value, JsonSerializer serializer)
        {
            if (value == null) return;
            writer.WriteStartObject();
            foreach (var (question, response) in value)
            {

                writer.WritePropertyName($"{question.QuizId},{question.AskedQuestion},{question.CorrectAnswer}");
                writer.WriteValue(response);
            }
            writer.WriteEndObject();
        }
        public override Dictionary<Question, string> ReadJson(JsonReader reader, Type objectType, Dictionary<Question, string> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var dictionary = new Dictionary<Question, string>();
            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    var keyParts = propertyName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var quizId = Guid.Parse(keyParts[0]);
                    var askedQuestion = keyParts[1];
                    var correctAnswer = keyParts[2];
                    reader.Read();
                    var value = (string)reader.Value;

                    var question = new Question(askedQuestion, correctAnswer) {  QuizId = quizId };
                    dictionary.Add(question, value);
                }

            }
            return dictionary;
        }
        public override bool CanRead => true;
        public override bool CanWrite => true;
    }
}