namespace JobBoardAPI.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
