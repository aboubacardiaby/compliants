using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Complaints.Models
{
    public class ComplaintValidator : AbstractValidator<Complaint>
    {
        public ComplaintValidator()
        {
            // ==================
            // Required Fields
            // ==================

            RuleFor(x => x.TitleNamePersonFilingComplaint)
                .NotEmpty()
                .WithMessage("Title & Name filing Complaint is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                     .EmailAddress()
                     .WithMessage("Email is required in correct format: 'name@domain.com'");

            RuleFor(x => x.DateOfEvent)
                .NotEmpty()
                .WithMessage("Date of Event is required");

            RuleFor(x => x.AlertDate)
                .NotEmpty()
                .WithMessage("Alert Date is required");

            RuleFor(x => x.FacitityName)
                .NotEmpty()
                .WithMessage("Facility Name is required");

            RuleFor(x => x.ContactName)
                .NotEmpty()
                .WithMessage("Contact Name is required");

            RuleFor(x => x.ContactEmail)
                .NotEmpty()
                     .EmailAddress()
                     .WithMessage("Contact Email is required in correct format: 'name@domain.com'");

            RuleFor(x => x.ProductCodeSKU)
                .NotEmpty()
                .WithMessage("Product Code/SKU is required");

            RuleFor(x => x.ProductDescriptionBrandName)
                .NotEmpty()
                .WithMessage("Product Description/Brand Name is required");

            RuleFor(x => x.WhenProblemNotice)
                .NotEmpty()
                    .WithMessage("You must select a When Problem Noticed");


        }

    }
}
