using BlogScript.DTOs.Abstract;

namespace BlogScript.DTOs.DTOs.AppUserDTOs
{
    class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
