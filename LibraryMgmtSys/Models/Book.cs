using System.Text.Json.Serialization;
namespace LibraryMgmtSys.Models
{
    public class Book
    {
        /// <summary>
        /// Book's unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int id { get; set; }

        /// <summary>
        /// Book's title
        /// </summary>
        [JsonPropertyName("title")]
        public string title { get; set; }

        /// <summary>
        /// Name of book's author
        /// </summary>
        [JsonPropertyName("author")]
        public string author { get; set; }

        /// <summary>
        /// Book's genre
        /// </summary>
        [JsonPropertyName("genre")]
        public string genre { get; set; }

        /// <summary>
        /// Total number of copies of a book in the library
        /// </summary>
        [JsonPropertyName("total_copies")]
        public int totalCopies { get; set; }

        /// <summary>
        /// Number of copies of a book currently available for checkout
        /// </summary>
        [JsonPropertyName("available_copies")]
        public int availableCopies { get; set; }
    }
}
