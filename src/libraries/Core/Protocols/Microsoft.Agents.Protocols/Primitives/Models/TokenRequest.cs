﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Agents.Protocols.Primitives
{
    /// <summary>
    /// A request to receive a user token.
    /// </summary>
    public class TokenRequest
    {
        public TokenRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRequest"/> class.
        /// </summary>
        /// <param name="provider">The provider to request a user token
        /// from.</param>
        /// <param name="settings">A collection of settings for the specific
        /// provider for this request.</param>
        public TokenRequest(string provider = default, IDictionary<string, object> settings = default)
        {
            Provider = provider;
            Settings = settings;
        }

        /// <summary>
        /// Gets or sets the provider to request a user token from.
        /// </summary>
        /// <value>The provider to request a user token from.</value>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets a collection of settings for the specific provider for
        /// this request.
        /// </summary>
        /// <value>The collection of settings for the specific provider for this request.</value>
#pragma warning disable CA2227 // Collection properties should be read only (we can't change this without breaking compat).
        public IDictionary<string, object> Settings { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}