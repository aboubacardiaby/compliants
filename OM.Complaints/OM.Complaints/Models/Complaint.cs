using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using FluentValidation.Validators;


namespace OM.Complaints.Models
{
    //[Validator(typeof(ComplaintValidator))]
    public class Complaint : ServiceResponseVM
    {
        public Complaint() 
        {
            Errors = new List<string>();

            ProblemNoticedList = new List<SelectListItem> { new SelectListItem("Prior","Prior"), new SelectListItem("During", "During"), new SelectListItem("After Use", "After Use") };
            SerilizationList = new List<SelectListItem> { new SelectListItem("Pre", "Pre"), new SelectListItem("Post", "Post") };
            YesNoList = new List<SelectListItem> { new SelectListItem("Yes", "Yes"), new SelectListItem("No", "No") };
            QuantityList = new List<SelectListItem> { new SelectListItem("Each", "Each"), new SelectListItem("Box", "Box"), new SelectListItem("Case", "Case"), new SelectListItem("Gaylord", "Gaylord") };
            YesNoUnknownList = new List<SelectListItem> { new SelectListItem("Yes", "Yes"), new SelectListItem("No", "No"), new SelectListItem("Unknown", "Unknown") };
            UsedUnusedList = new List<SelectListItem> { new SelectListItem("Used", "Used"), new SelectListItem("Unused", "Unused") };
            TranslationLanguageList = new List<SelectListItem> { new SelectListItem("English", "English"), new SelectListItem("Dutch", "Dutch"), new SelectListItem("Japanese", "Japanese"), new SelectListItem("Chinese", "Chinese"), new SelectListItem("German", "German"), new SelectListItem("French", "French") };
            EmploymentStatusList = new List<SelectListItem> { new SelectListItem("Yes", "Yes"), new SelectListItem("No", "No") };
        }

        [Required]
        [DisplayName("Name & Title of Person Filing Complaint:")] 
        public string? TitleNamePersonFilingComplaint { get; set; }

        [DisplayName("O&M Teammate Responsible for Account:")] 
        public string? TeammateResponsibleForAccount { get; set; }

        [DisplayName("Telephone:")]
        [RegularExpression(@"^\+1 \(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number.")]
        public string? Telephone { get; set; }

        [Required]
        [DisplayName("Email:")] 
        public string? Email { get; set;}
        
        [Required]
        [DisplayName("Country of Complaint Origin:")] 
        public string? CountryOfCompaintOrigin { get; set;}

        [Required]
        [DisplayName("Date of Event:")]
        public DateTime DateOfEvent { get; set;}

        [DisplayName("Alert Date/Date of Awareness:")]
        public DateTime AlertDate { get; set;}

        [Required]
        [DisplayName("Facility Name:")]
        public string? FacitityName { get; set;}
 
        [Required]
        [DisplayName("Contact Name:")]
        public string? ContactName { get;set;}

        [DisplayName("Address:")]
        public string? Address { get; set;}

        [DisplayName("Telephone:")]
        [RegularExpression(@"^\+1 \(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number.")]
        public string? ContactTelephone { get; set;}

        [Required]
        [DisplayName("Email:")]
        public string? ContactEmail { get; set;}

        [Required]
        [DisplayName("Product Code/SKU:")]
        public string? ProductCodeSKU { get; set;}

        [Required]
        [DisplayName("Product Description/Brand Name:")]
        public string? ProductDescriptionBrandName { get; set;}

        [Required]
        [DisplayName("When Was Problem Noticed:")]
        public string? WhenProblemNotice { get; set;}

        [DisplayName("Sterilization Wrap:")]
        public string? SterilizationWrap { get; set;}

        [Required]
        [DisplayName("Was incident discoverd during patient care?")]
        public string? IncidentDiscoveredDuringPatientCare { get; set; }

        [Required]
        [DisplayName("If yes, what was the nature of patient care at the time (isolation environment or type of procedure/care being provided at time of incident?")]
        public string? NatureOfPatientCare { get; set; }


        [Required]
        [DisplayName("Quantity:")]
        public string? Quantity { get; set;}

        [Required]
        [DisplayName("Lot:")]
        public string? Lot { get; set;}

        [Required]
        [DisplayName("Incident Details:")]
        public string? IncidentDetails { get; set;}

        [Required]
        [DisplayName("Was a Patient Injured:")]
        public string? WasPatientInjured { get; set;}

        [DisplayName("If yes, please provide details:")]
        public string? InjuryDetails { get; set;}

        [Required]
        [DisplayName("Was Medical Treatment Required:")]
        public string? WasMedicalTreatmentRequired { get; set;}

        [Required]
        [DisplayName("If yes, please provide details:")]
        public string? TreatmentDetails { get; set;}

        [Required]
        [DisplayName("What is the Patient's Current Status:")]
        public string? PatientCurrentStatus { get; set;}

        [Required]
        [DisplayName("Is Photo Available:")]
        public string? IsPhotoAvailable { get; set;}

        [Required]
        [DisplayName("Is a Sample Available:")]
        public string? IsSampleAvailable { get; set;}

        [Required]
        [DisplayName("If yes, is sample used/unused:")]
        public string? SampleUsedUnused { get; set;}

        [Required]
        [DisplayName("Investigation Reponse Requested:")]
        public string? InvestigationResponseRequested { get; set;}

        [Required]
        [DisplayName("If yes, please provide email:")]
        public string? ProvidedEmail { get; set;}

        [Required]
        [DisplayName("Translation/Language:")]
        public string? TranslationLanguage { get;set;}

        [DisplayName("Replacement Requested:")]
        public string? ReplacementRequested { get; set;}

        [DisplayName("Credit Requested:")]
        public string? CreditRequested { get; set;}

        [DisplayName("Purchase Order Number:")]
        public string? PONumber { get;set;}

        public List<SelectListItem> ProblemNoticedList { get; set; }
        public List<SelectListItem> SerilizationList { get; set; }
        public List<SelectListItem> YesNoList { get; set; }
        public List<SelectListItem> QuantityList { get; set; }
        public List<SelectListItem> YesNoUnknownList { get; set; }
        public List<SelectListItem> UsedUnusedList { get; set; }
        public List<SelectListItem> TranslationLanguageList { get; set; }
        public List<SelectListItem> EmploymentStatusList { get; set; }


    }
}
