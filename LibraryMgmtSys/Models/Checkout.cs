using System.Text.Json.Serialization;
namespace LibraryMgmtSys.Models
{
    public class Checkout
    {
        /// <summary>
        /// Identifier for each checkout
        /// </summary>
        [JsonPropertyName("id")]
        public int id { get; set; }

        /// <summary>
        /// User ID of user that made checkout
        /// </summary>
        [JsonPropertyName("user_id")]
        public int userId { get; set; }

        /// <summary>
        /// Book ID of book being checked out
        /// </summary>
        [JsonPropertyName("book_id")]
        public int bookId { get; set; }

        /// <summary>
        /// Date of checkout
        /// </summary>
        [JsonPropertyName("checkout_date")]
        public string checkoutDate { get; set; }
    }
}
