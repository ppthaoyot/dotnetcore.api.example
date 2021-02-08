using SmileShop.API.Validations;

namespace SmileShop.API.DTOs
{
    public class RoleDtoAdd
    {
        [FirstLetterUpperCase]
        public string RoleName { get; set; }
    }
}