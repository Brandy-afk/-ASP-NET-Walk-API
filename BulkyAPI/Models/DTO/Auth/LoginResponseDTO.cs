namespace BulkyAPI.Models.DTO.Auth
{
    public class LoginResponseDTO
    {
        public LoginResponseDTO(string? token)
        {
            this.JwtToken = token ?? "";
        }
        public string JwtToken { get; set; }
    }
}
