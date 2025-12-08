using LibraryMgmtSys.Components.Pages;
using LibraryMgmtSys.Models;
namespace LibraryMgmtSys.Services
{
    public class APIService : IAPIService
    {
        private readonly HttpClient _httpClient;

        public APIService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://127.0.0.1:8000/"); // REVERT TO LOCALHOST IF NOT WORKING
        }

        // ************* Book Endpoints *************

        /// <summary>
        /// Create a new book record using API
        /// </summary>
        /// <param name="book">New book</param>
        /// <returns>New book content</returns>
        public async Task<string> CreateBookAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync("books/", book);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Get list of books from API 
        /// </summary>
        /// <param name="title">Search by title</param>
        /// <returns>List of books</returns>
        public async Task<List<Book>> GetBooksAsync(string? title = null)
        {
            List<Book> books = new List<Book>();

            if (title != null)
            {
                books = await _httpClient.GetFromJsonAsync<List<Book>>($"/books/{title}");
            }
            else
            {
                books = await _httpClient.GetFromJsonAsync<List<Book>>("/books");
            }

            return books;
        }

        /// <summary>
        /// Calls API to patch a book record
        /// </summary>
        /// <param name="book">Updated book record</param>
        /// <returns>Confirmation message</returns>
        public async Task<string> UpdateBookAsync(Book book)
        {
            var response = await _httpClient.PatchAsJsonAsync("books/", book);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Calls API to delete a book record
        /// </summary>
        /// <param name="id">ID of book being deleted</param>
        /// <returns>Confirmation message</returns>
        public async Task<string> DeleteBookAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"books/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // ************* User Endpoints *************

        /// <summary>
        /// Calls API to create new user
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns>Confirmation message</returns>
        public async Task<string> CreateUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("users/", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Calls API to return list of users, can use optional username search query
        /// </summary>
        /// <param name="username">Optional username search query</param>
        /// <returns>List of users</returns>
        public async Task<List<User>> GetUsersAsync(string? username = null)
        {
            if (username != null)
            {
                return await _httpClient.GetFromJsonAsync<List<User>>($"users/?username={username}");
            }
            else
            {
                return await _httpClient.GetFromJsonAsync<List<User>>("users/");
            }
        }

        /// <summary>
        /// Calls API to update a user's record
        /// </summary>
        /// <param name="user">New user record</param>
        /// <returns>Confirmation message</returns>
        public async Task<string> UpdateUserAsync(User user)
        {
            var response = await _httpClient.PatchAsJsonAsync("users/", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Calls API to delete a user record
        /// </summary>
        /// <param name="id">ID of user record being deleted</param>
        /// <returns>Confirmation message</returns>
        public async Task<string> DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"users/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();  
        }

        // ************* Checkout Endpoints *************

        /// <summary>
        /// Calls API to create new record of a checkout
        /// </summary>
        /// <param name="checkout">New checkout</param>
        /// <returns>Confirmation message</returns>
        public async Task<string> CreateCheckoutAsync(Checkout checkout)
        {
            var response = await _httpClient.PostAsJsonAsync("checkouts/", checkout);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        //public async Task<string> ReturnCheckoutAsync(int id) // SHOULD BE CHANGED TO PATCH? OR CHANGED TO HAVE FULL JSON SENT?
        //{
            //var response = await _httpClient.PostAsJsonAsync("checkouts/")
        //}

        /// <summary>
        /// Calls API to get a checkout record by ID number
        /// </summary>
        /// <param name="id">Checkout ID number</param>
        /// <returns>Checkout corresponding to ID number</returns>
        public async Task<Checkout> GetCheckoutByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Checkout>($"checkouts/{id}");
        }

        /// <summary>
        /// Calls API to get a list of checkout records
        /// </summary>
        /// <returns>List of checkouts</returns>
        public async Task<List<Checkout>> GetCheckoutsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Checkout>>("checkouts/");
        }
    }
}
