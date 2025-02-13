﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Agents.Core;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Core.Serialization;
using Microsoft.Agents.Core.Teams.Models;
using Xunit;

namespace Microsoft.Agents.Teams.Tests
{
    public class TeamsChannelDataTests
    {
        [Fact]
        public void TeamsChannelDataInits()
        {
            var channel = new ChannelInfo("general", "General");
            var eventType = "eventType";
            var team = new TeamInfo("supportEngineers", "Support Engineers");
            var notification = new NotificationInfo(true);
            var tenant = new TenantInfo("uniqueTenantId");
            var meeting = new TeamsMeetingInfo("BFSE Stand Up");
            var settings = new TeamsChannelDataSettings(channel);
            var onBehalfOf = new List<OnBehalfOf>()
            {
                new OnBehalfOf() 
                {
                    DisplayName = "onBehalfOfTest",
                    ItemId = 0,
                    MentionType = "person",
                    Mri = Guid.NewGuid().ToString()
                }
            };
            var channelData = new TeamsChannelData(channel, eventType, team, notification, tenant, onBehalfOf)
            {
                Meeting = meeting,
                Settings = settings
            };

            Assert.NotNull(channelData);
            Assert.IsType<TeamsChannelData>(channelData);
            Assert.Equal(channel, channelData.Channel);
            Assert.Equal(eventType, channelData.EventType);
            Assert.Equal(team, channelData.Team);
            Assert.Equal(notification, channelData.Notification);
            Assert.Equal(tenant, channelData.Tenant);
            Assert.Equal(settings, channelData.Settings);
            Assert.Equal(channel, channelData.Settings.SelectedChannel);
            Assert.Equal(onBehalfOf, channelData.OnBehalfOf);
        }

        [Fact]
        public void TeamsChannelDataInitsWithNoArgs()
        {
            var channelData = new TeamsChannelData();

            Assert.NotNull(channelData);
            Assert.IsType<TeamsChannelData>(channelData);
        }

        [Fact]
        public void GetAadGroupId()
        {
            // Arrange
            const string AadGroupId = "teamGroup123";
            var activity = (IActivity) new Activity { ChannelData = new TeamsChannelData { Team = new TeamInfo { AadGroupId = AadGroupId } } };

            // Act
            var channelData = activity.GetChannelData<TeamsChannelData>();

            // Assert
            Assert.Equal(AadGroupId, channelData.Team.AadGroupId);
        }

        [Fact]
        public void AdditionalProperties_ExtraChannelDataFields()
        {
            // Arrange
            const string TestKey = "thekey";
            const string TestValue = "the test value";

            // TeamsChannelData with additional property.
            var json = "{\"team\": {\"aadGroupId\": \"id\"}, \"thekey\": \"the test value\"}";

            // Act
            var asTeamsChannelData = ProtocolJsonSerializer.ToObject<TeamsChannelData>(json);

            // Assert
            Assert.True(asTeamsChannelData.Properties.ContainsKey(TestKey));
            Assert.Equal(TestValue, asTeamsChannelData.Properties[TestKey].ToString());
        }
    }
}
