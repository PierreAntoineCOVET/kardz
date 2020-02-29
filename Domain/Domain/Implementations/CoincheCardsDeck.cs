﻿using Domain.Domain.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Domain.Implementations
{
    /// <summary>
    /// List of classic 53 cards.
    /// </summary>
    public class CoincheCardsDeck : ICardsDeck
    {
        private IEnumerable<CardsEnum> Cards = new List<CardsEnum>
        {
            CardsEnum.AsSpade,
            CardsEnum.SevenSpade,
            CardsEnum.EightSpade,
            CardsEnum.NineSpade,
            CardsEnum.TenSpade,
            CardsEnum.JackSpade,
            CardsEnum.QueenSpade,
            CardsEnum.KingSpade,

            CardsEnum.AsClub,
            CardsEnum.SevenClub,
            CardsEnum.EightClub,
            CardsEnum.NineClub,
            CardsEnum.TenClub,
            CardsEnum.JackClub,
            CardsEnum.QueenClub,
            CardsEnum.KingClub,

            CardsEnum.AsDiamond,
            CardsEnum.SevenDiamond,
            CardsEnum.EightDiamond,
            CardsEnum.NineDiamond,
            CardsEnum.TenDiamond,
            CardsEnum.JackDiamond,
            CardsEnum.QueenDiamond,
            CardsEnum.KingDiamond,

            CardsEnum.AsHeart,
            CardsEnum.SevenHeart,
            CardsEnum.EightHeart,
            CardsEnum.NineHeart,
            CardsEnum.TenHeart,
            CardsEnum.JackHeart,
            CardsEnum.QueenHeart,
            CardsEnum.KingHeart,
        };

        public IEnumerable<CardsEnum> Shuffle()
        {
            var buffer = Cards.ToList();
            var shuffledCards = new List<CardsEnum>(buffer.Count);
            var random = new Random();

            for(int i=0; i<Cards.Count(); i++)
            {
                var randomCardIndex = random.Next(0, buffer.Count);
                shuffledCards.Add(buffer.ElementAt(randomCardIndex));
                buffer.RemoveAt(randomCardIndex);
            }

            return shuffledCards;
        }
    }
}
