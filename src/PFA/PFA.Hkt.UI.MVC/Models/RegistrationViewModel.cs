using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFA.Hkt.UI.MVC.Models
{
    public class RegistrationViewModel
    {
        /// <summary>
        ///     Get or sets a <see cref="string" /> value that specifies the registering user's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Get or sets a <see cref="string" /> value that specifies the registering user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Get or sets a <see cref="string" /> value that specifies the registering user's username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Get or sets a <see cref="string" /> value that specifies the registering user's Password string
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        ///     Get or sets a <see cref="string" /> value that specifies the registering user's email ID.
        /// </summary>
        public string Email { get; set; }

       
    }
}