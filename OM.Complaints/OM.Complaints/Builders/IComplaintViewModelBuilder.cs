using Microsoft.AspNetCore.Mvc.Rendering;
using OM.Complaints.Models;

namespace OM.Complaints.Builders
{
    public interface IComplaintViewModelBuilder
    {
        Complaint GetComplaintData();
        NotificationResponseVM SendComplaintNotification(Complaint complaintData);

    }
}
