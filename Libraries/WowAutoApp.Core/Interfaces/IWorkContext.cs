﻿using WowAutoApp.Core.Domain;

namespace WowAutoApp.Core
{
    /// <summary>
    /// Represents work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current user
        /// </summary>
        ApplicationUser CurrentUser { get; set; }

        /// <summary>
        ///     Get request Client Id
        /// </summary>
        string ClientId { get; }
    }
}