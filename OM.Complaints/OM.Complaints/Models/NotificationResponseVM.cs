namespace OM.Complaints.Models
{
    public class NotificationResponseVM: ServiceResponseVM
    {
        public string Receipents { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseData { get; set; }

    }
}
