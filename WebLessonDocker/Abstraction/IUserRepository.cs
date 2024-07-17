using WebLessonDocker.Dto;

namespace WebLessonDocker.Abstraction
{
    public interface IUserRepository
    {
        int AddUser(UserDto user);
        RoleIdDto CheckUser(LoginDto login);
    }
}
