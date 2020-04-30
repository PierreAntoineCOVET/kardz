﻿using MediatR;
using System;

namespace EventHandlers.Commands.SearchGame
{
    /// <summary>
    /// Search game command.
    /// </summary>
    public class SearchGameCommand : IRequest<bool>
    {
        /// <summary>
        /// Player id.
        /// </summary>
        public Guid PlayerId { get; set; }

        public int GameType { get; set; }
    }
}
