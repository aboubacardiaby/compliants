using Microsoft.AspNetCore.Mvc;
using OM.Complaints.Builders;
using OM.Complaints.Models;
//using OM.Shared.Extensions;
using System.Diagnostics;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Graph.Models;
using Microsoft.Graph;

namespace OM.Complaints.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected IComplaintViewModelBuilder ComplaintBuilder { get; private set; }
        private IValidator<Complaint> _complaintValidator;

        public HomeController(IComplaintViewModelBuilder complaintBuilder, ILogger<HomeController> logger, IValidator<Complaint> complaintValidator)
        {
            ComplaintBuilder = complaintBuilder;
            _complaintValidator = complaintValidator;

            _logger = logger;

        }

        [HttpGet]
        public IActionResult Index()
        {
            //var userName = WindowsIdentity.GetCurrentUser.Name();
            var model = ComplaintBuilder.GetComplaintData();

            if (model.Errors.Any())
            {
                //Error(String.Join("<br>", model.Errors));
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Complaint model)
        {
            var isValid = ModelState.IsValid;
            ValidationResult validationResult = null;

            if (isValid)
                validationResult = _complaintValidator.Validate(model);

            if (!isValid || (validationResult != null && !validationResult.IsValid))
            {
                if (validationResult != null)

                return View(model);
            }

            try
            {
                var result = ComplaintBuilder.SendComplaintNotification(model);
                // send nice email to user
                //SendNewComputerUserNotification(model);

                if (!result.Success)
                {
                    // show them the error?
                    throw new Exception("Did not send email to system??");
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }


            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //protected void SendErrorEmail(bool movedToError, Message item, string errorMessage, GraphServiceClient client)
        //{
        //    //Logger.Debug("Attempting to send error email.");
        //    try
        //    {
        //        var message = new Message
        //        {
        //            Subject = "New Complaint Entered",
        //            Body = new ItemBody
        //            {
        //                ContentType = BodyType.Text,
        //                Content = string.Format("There was an error attempting to process an incoming email.\n\nSubject: {0}\nSender: {1}\n\nError Message: {2}\n\n{3}\n\n",
        //                item.Subject,
        //                item.From.EmailAddress.Address,
        //                errorMessage,
        //                movedToError ? "The email was moved to the error folder." : "The system was unable to move the email to the error folder")
        //            },
        //            ToRecipients = new List<Recipient>()
        //            {
        //                new Recipient
        //                {
        //                    EmailAddress = new EmailAddress
        //                    {
        //                        Address = "john.walker@owens-minor.com" 
        //                    }
        //                }
        //            }
        //        };

        //        var saveToSentItems = false;

        //        // should be awaited
        //        client.Users["SVC-ContractAdminEWS@owens-minor.com"]
        //            .SendMail(message, saveToSentItems)
        //            .Request()
        //            .PostAsync();

        //    }
        //    catch (Exception err)
        //    {
        //        logger.LogError(err, "There was a problem sending the error email: {0}", err.Message);
        //    }

        //}
    }
}