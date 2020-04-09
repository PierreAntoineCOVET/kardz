﻿using Domain.Domain.Interfaces;
using Domain.Exceptions.Game;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Implementations.Coinche
{
    /// <summary>
    /// Coinche team.
    /// </summary>
    internal class CoincheTeam : ITeam
    {
        private List<CoinchePlayer> _Players = new List<CoinchePlayer>();
        /// <summary>
        /// List of players in the team.
        /// </summary>
        public IEnumerable<IPlayer> Players => _Players;

        /// <summary>
        /// Team's number.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Constructor for deserialisation.
        /// Use <see cref="CoinchePlayer"/> insted of <see cref="IPlayer"/>.
        /// </summary>
        /// <param name="number">Team number.</param>
        /// <param name="players">List of players.</param>
        [JsonConstructor]
        public CoincheTeam(int number, List<CoinchePlayer> players)
        {
            Number = number;
            _Players = players;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="number">Team's number.</param>
        public CoincheTeam(int number)
        {
            Number = number;
        }

        /// <summary>
        /// Add a player to the team.
        /// </summary>
        /// <param name="player">Player to add.</param>
        /// <remarks>Compute player's number based on the team's number and number of player in the team.</remarks>
        public void AddPlayer(IPlayer player)
        {
            if (_Players.Count >= 2)
                throw new GameCreationException($"Game {Enums.GamesEnum.Coinche} teams doesn't allow for {_Players.Count} player(s)");

            if (! (player is CoinchePlayer))
                throw new InvalidCastException($"{nameof(player)} shoud be of type 'CoinchePlayer'");

            player.Number = (Number * 2) + _Players.Count;
            _Players.Add((CoinchePlayer)player);
        }
    }
}