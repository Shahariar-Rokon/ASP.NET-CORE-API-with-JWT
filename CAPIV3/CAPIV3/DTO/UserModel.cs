namespace CAPIV3.DTO
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? EmailId { get; set; }
        public string Password { get; set; }
        public string? UserMessage { get;set; }
        public string FullName { get; set; }
        public string? AccessToken { get; set; }
    }
}
