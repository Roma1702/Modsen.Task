using Models.Core;

namespace Domain.Abstractions.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel> GetUserAsync(Guid id);
        public Task CreateNewUserAsync(UserModel user);
        public Task EditUserAync(UserModel user);
        public Task DeleteUserAsync(Guid id);
    }
}
