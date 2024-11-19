﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.CopilotStudio.Client.Discovery;

namespace Microsoft.Agents.CopilotStudio.Client.Interfaces
{

    public interface IDirectToEngineConnectionSettings
    {
        /// <summary>
        /// Schema name for the Copilot Studio Hosted Copilot. 
        /// </summary>
        string? BotIdentifier { get; set; }
        /// <summary>
        /// if PowerPlatformCloud is set to Other, this is the url for the power platform API endpoint.
        /// </summary>
        string? CustomPowerPlatformCloud { get; set; }
        /// <summary>
        /// Environment ID for the environment that hosts the bot
        /// </summary>
        string? EnvironmentId { get; set; }
        /// <summary>
        /// Power Platform Cloud where the environment is hosted
        /// </summary>
        PowerPlatformCloud? Cloud { get; set; }
        
        /// <summary>
        /// Type of Bot hosted in Copilot Studio
        /// </summary>
        BotType? CopilotBotType { get; set; }
    }
}