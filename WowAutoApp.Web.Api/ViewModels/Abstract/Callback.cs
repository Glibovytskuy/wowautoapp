﻿using System.ComponentModel.DataAnnotations;

namespace wowautoapp.ViewModels.Abstract
{
    /// <summary>
    /// Calback url of client that calls api
    /// </summary>
    public class Callback
    {
        /// <summary>
        /// Callback Url of client that calls api
        /// </summary>
        [Required]
        public string CallbackUrl { get; set; }
    }
}