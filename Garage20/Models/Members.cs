using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;

namespace Garage20.Models
{

    public class Members
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fältet Förnamn är obligatioriskt")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage = "Endast bokstäver är tillåtna")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Fältet Efternamn är obligatioriskt")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage = "Endast bokstäver är tillåtna")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Fältet Telefonnummer är obligatioriskt")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Endast nummer är tillåtna")]
        public string PhoneNbr { get; set; }
        [Required(ErrorMessage = "Fältet Emailadress är obligatioriskt")]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Otillåtet format")]
        public string Email { get; set; }


        public virtual ICollection<Vehicles> Vehicles { get; set; }

    }
}