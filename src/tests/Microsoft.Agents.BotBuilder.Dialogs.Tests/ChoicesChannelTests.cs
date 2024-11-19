﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.BotBuilder.Dialogs.Choices;
using Microsoft.Agents.Protocols.Adapter;
using Microsoft.Agents.Protocols.Primitives;
using Moq;
using Xunit;

namespace Microsoft.Agents.BotBuilder.Dialogs.Tests
{
    [Trait("TestCategory", "Prompts")]
    [Trait("TestCategory", "Choice Tests")]
    public class ChoicesChannelTests
    {
        [Fact]
        public void ShouldReturnTrueForSupportsSuggestedActionsWithLineAnd13()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Line, 13);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsSuggestedActionsWithLineAnd14()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Line, 14);
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsSuggestedActionsWithSkypeAnd10()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Skype, 10);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsSuggestedActionsWithSkypeAnd11()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Skype, 11);
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsSuggestedActionsWithKikAnd20()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Kik, 20);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsSuggestedActionsWithKikAnd21()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Skype, 21);
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsSuggestedActionsWithEmulatorAnd100()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Emulator, 100);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsSuggestedActionsWithEmulatorAnd101()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Emulator, 101);
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsSuggestedActionsWithDirectLineSpeechAnd100()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.DirectlineSpeech, 100);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsSuggestedActionsWithTeamsAndPersonalAnd3()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Msteams, 3, "personal");
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsSuggestedActionsWithTeamsAndPersonalAnd4()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Msteams, 4, "personal");
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsSuggestedActionsWithTeamsAndGroupChat()
        {
            var supports = Channel.SupportsSuggestedActions(Channels.Msteams, 3, "groupChat");
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsCardActionsWithDirectLineSpeechAnd99()
        {
            var supports = Channel.SupportsCardActions(Channels.DirectlineSpeech, 99);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsCardActionsWithLineAnd99()
        {
            var supports = Channel.SupportsCardActions(Channels.Line, 99);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsCardActionsWithLineAnd100()
        {
            var supports = Channel.SupportsCardActions(Channels.Line, 100);
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsCardActionsWithCortanaAnd100()
        {
            var supports = Channel.SupportsCardActions(Channels.Cortana, 100);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsCardActionsWithSlackAnd100()
        {
            var supports = Channel.SupportsCardActions(Channels.Slack, 100);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnTrueForSupportsCardActionsWithSkypeAnd100()
        {
            var supports = Channel.SupportsCardActions(Channels.Skype, 3);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsCardActionsWithSkypeAnd5()
        {
            var supports = Channel.SupportsCardActions(Channels.Skype, 5);
            Assert.False(supports);
        }
        
        [Fact]
        public void ShouldReturnTrueForSupportsCardActionsWithTeamsAnd50()
        {
            var supports = Channel.SupportsCardActions(Channels.Msteams, 50);
            Assert.True(supports);
        }

        [Fact]
        public void ShouldReturnFalseForSupportsCardActionsWithTeamsAnd51()
        {
            var supports = Channel.SupportsCardActions(Channels.Msteams, 51);
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnFalseForHasMessageFeedWithCortana()
        {
            var supports = Channel.HasMessageFeed(Channels.Cortana);
            Assert.False(supports);
        }

        [Fact]
        public void ShouldReturnChannelIdFromContextActivity()
        {
            var adapter = new Mock<IBotAdapter>();
            var testActivity = new Activity() { ChannelId = Channels.Facebook };
            var testContext = new TurnContext(adapter.Object, testActivity);
            var channelId = Channel.GetChannelId(testContext);
            Assert.Equal(Channels.Facebook, channelId);
        }

        [Fact]
        public void ShouldReturnEmptyFromContextActivityMissingChannel()
        {
            var adapter = new Mock<IBotAdapter>();
            var testActivity = new Activity() { ChannelId = null };
            var testContext = new TurnContext(adapter.Object, testActivity);
            var channelId = Channel.GetChannelId(testContext);
            Assert.Equal(channelId, string.Empty);
        }
    }
}