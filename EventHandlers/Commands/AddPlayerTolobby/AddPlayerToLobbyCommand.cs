﻿using MediatR;
using System;

namespace EventHandlers.Commands.AddPlayerTolobby
{
    /// <summary>
    /// Add a player to the lobby command.
    /// </summary>
    public class AddPlayerToLobbyCommand : IRequest<int>
    {
        /// <summary>
        /// Player id.
        /// </summary>
        public Guid PlayerId { get; set; }
    }
}
