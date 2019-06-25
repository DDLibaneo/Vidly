using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                return Customer != null && Customer.Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel() { }

        public CustomerFormViewModel(IEnumerable<MembershipType> membershipTypes)
        {
            this.MembershipTypes = membershipTypes;
        }

        public CustomerFormViewModel(IEnumerable<MembershipType> membershipTypes, Customer customer)
        {
            this.MembershipTypes = membershipTypes;
            this.Customer = customer;
        }
    }
}