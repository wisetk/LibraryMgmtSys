using System.Text.Json.Serialization;
namespace LibraryMgmtSys.Models
{
    public class User
    {
        /// <summary>
        /// User's unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int id { get; set; }

        /// <summary>
        /// User's username
        /// </summary>
        [JsonPropertyName("username")]
        public string username { get; set; }

        /// <summary>
        /// Users' role (i.e. student, teacher, etc.)
        /// </summary>
        [JsonPropertyName("role")]
        public string role { get; set; }
    }
}
