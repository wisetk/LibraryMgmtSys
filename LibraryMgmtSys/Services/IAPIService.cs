using LibraryMgmtSys.Models;
namespace LibraryMgmtSys.Services
{
    public interface IAPIService
    {
        // Book Endpoints
        Task<string> CreateBookAsync(Book book);
        Task<List<Book>> GetBooksAsync(string? title = null);
        Task<Book> GetBookByIdAsync(int id);
        Task<string> UpdateBookAsync(Book book);
        Task<string> DeleteBookAsync(int id);

        // User Endpoints
        Task<string> CreateUserAsync(User user);
        Task<List<User>> GetUsersAsync(string? username = null);
        Task<User> GetUserByIdAsync(int id);
        Task<string> UpdateUserAsync(User user);
        Task<string> DeleteUserAsync(int id);

        // Checkout Endpoints
        Task<string> CreateCheckoutAsync(Checkout checkout);
        Task<string> ReturnCheckoutAsync(int id); 
        Task<Checkout> GetCheckoutByIdAsync(int id);
        Task<List<Checkout>> GetCheckoutsAsync();
    }
}
