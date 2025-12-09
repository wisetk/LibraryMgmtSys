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
        /// Get book record by searching by corresponding ID number
        /// </summary>
        /// <param name="id">Book record being searched for</param>
        /// <returns>Book record</returns>
        public async Task<Book> GetBookByIdAsync(int id)
        {
            Book book = new Book();

            book = await _httpClient.GetFromJsonAsync<Book>($"/books/id/{id}");

            return book;
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
            List<User> users = new List<User>();
            
            if (username != null && username != "")
            {
                users = await _httpClient.GetFromJsonAsync<List<User>>($"/users/username/{username}");
            }
            else
            {
                users = await _httpClient.GetFromJsonAsync<List<User>>("/users"); // FLIPPED SLASH FROM BACK TO FRONT IF THIS BREAKS
            }

            return users;
        }

        /// <summary>
        /// Get the user record corresponding to a user ID
        /// </summary>
        /// <param name="id">User ID of user record being searched for</param>
        /// <returns>User record</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = new User();

            user = await _httpClient.GetFromJsonAsync<User>($"/users/id/{id}");

            return user;
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

        public async Task<string> ReturnCheckoutAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"checkouts/return/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

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
        /// Calls API to get list of checkouts by user ID
        /// </summary>
        /// <param name="id">User ID being searched for</param>
        /// <returns>List of checkouts by user ID</returns>
        public async Task<List<Checkout>> GetCheckoutsByUserId(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<Checkout>>($"checkouts/user/{id}");
        }

        /// <summary>
        /// Calls API to get list of checkouts by book ID
        /// </summary>
        /// <param name="id">Book ID being searched for</param>
        /// <returns>List of checkouts by book ID</returns>
        public async Task<List<Checkout>> GetCheckoutsByBookId(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<Checkout>>($"checkouts/book/{id}");
        }

        /// <summary>
        /// Calls API to get a list of checkout records
        /// </summary>
        /// <returns>List of checkouts</returns>
        public async Task<List<Checkout>> GetCheckoutsAsync()
        {
            List<Checkout> checkouts = new List<Checkout>();
            checkouts =  await _httpClient.GetFromJsonAsync<List<Checkout>>($"checkouts/");
            return checkouts;
        }
    }
}
