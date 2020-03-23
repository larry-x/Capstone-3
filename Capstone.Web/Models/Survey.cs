using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public Survey()
        {
            Parks = new List<SelectListItem>();
            States = new List<SelectListItem>();
            PopulateStateDropdown();
        }

        public IList<SelectListItem> States { get; } 
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required(ErrorMessage = "You must provide us your email address.")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        public IList<SelectListItem> Parks { get; private set; }

        public void PopulateParkDropdown(IDictionary<string, string> parks)
        {
            foreach (KeyValuePair<string, string> kvp in parks)
            {
                Parks.Add(new SelectListItem { Text = kvp.Value, Value = kvp.Key });
            } 
        }

        private void PopulateStateDropdown()
        {
            States.Add(new SelectListItem() { Text = "Alabama", Value = "AL" });
            States.Add(new SelectListItem() { Text = "Alaska", Value = "AK" });
            States.Add(new SelectListItem() { Text = "Arizona", Value = "AZ" });
            States.Add(new SelectListItem() { Text = "Arkansas", Value = "AR" });
            States.Add(new SelectListItem() { Text = "California", Value = "CA" });
            States.Add(new SelectListItem() { Text = "Colorado", Value = "CO" });
            States.Add(new SelectListItem() { Text = "Connecticut", Value = "CT" });
            States.Add(new SelectListItem() { Text = "District of Columbia", Value = "DC" });
            States.Add(new SelectListItem() { Text = "Delaware", Value = "DE" });
            States.Add(new SelectListItem() { Text = "Florida", Value = "FL" });
            States.Add(new SelectListItem() { Text = "Georgia", Value = "GA" });
            States.Add(new SelectListItem() { Text = "Hawaii", Value = "HI" });
            States.Add(new SelectListItem() { Text = "Idaho", Value = "ID" });
            States.Add(new SelectListItem() { Text = "Illinois", Value = "IL" });
            States.Add(new SelectListItem() { Text = "Indiana", Value = "IN" });
            States.Add(new SelectListItem() { Text = "Iowa", Value = "IA" });
            States.Add(new SelectListItem() { Text = "Kansas", Value = "KS" });
            States.Add(new SelectListItem() { Text = "Kentucky", Value = "KY" });
            States.Add(new SelectListItem() { Text = "Louisiana", Value = "LA" });
            States.Add(new SelectListItem() { Text = "Maine", Value = "ME" });
            States.Add(new SelectListItem() { Text = "Maryland", Value = "MD" });
            States.Add(new SelectListItem() { Text = "Massachusetts", Value = "MA" });
            States.Add(new SelectListItem() { Text = "Michigan", Value = "MI" });
            States.Add(new SelectListItem() { Text = "Minnesota", Value = "MN" });
            States.Add(new SelectListItem() { Text = "Mississippi", Value = "MS" });
            States.Add(new SelectListItem() { Text = "Missouri", Value = "MO" });
            States.Add(new SelectListItem() { Text = "Montana", Value = "MT" });
            States.Add(new SelectListItem() { Text = "Nebraska", Value = "NE" });
            States.Add(new SelectListItem() { Text = "Nevada", Value = "NV" });
            States.Add(new SelectListItem() { Text = "New Hampshire", Value = "NH" });
            States.Add(new SelectListItem() { Text = "New Jersey", Value = "NJ" });
            States.Add(new SelectListItem() { Text = "New Mexico", Value = "NM" });
            States.Add(new SelectListItem() { Text = "New York", Value = "NY" });
            States.Add(new SelectListItem() { Text = "North Carolina", Value = "NC" });
            States.Add(new SelectListItem() { Text = "North Dakota", Value = "ND" });
            States.Add(new SelectListItem() { Text = "Ohio", Value = "OH" });
            States.Add(new SelectListItem() { Text = "Oklahoma", Value = "OK" });
            States.Add(new SelectListItem() { Text = "Oregon", Value = "OR" });
            States.Add(new SelectListItem() { Text = "Pennsylvania", Value = "PA" });
            States.Add(new SelectListItem() { Text = "Rhode Island", Value = "RI" });
            States.Add(new SelectListItem() { Text = "South Carolina", Value = "SC" });
            States.Add(new SelectListItem() { Text = "South Dakota", Value = "SD" });
            States.Add(new SelectListItem() { Text = "Tennessee", Value = "TN" });
            States.Add(new SelectListItem() { Text = "Texas", Value = "TX" });
            States.Add(new SelectListItem() { Text = "Utah", Value = "UT" });
            States.Add(new SelectListItem() { Text = "Vermont", Value = "VT" });
            States.Add(new SelectListItem() { Text = "Virginia", Value = "VA" });
            States.Add(new SelectListItem() { Text = "Washington", Value = "WA" });
            States.Add(new SelectListItem() { Text = "West Virginia", Value = "WV" });
            States.Add(new SelectListItem() { Text = "Wisconsin", Value = "WI" });
            States.Add(new SelectListItem() { Text = "Wyoming", Value = "WY" });
        }

    }
}