﻿using FluentValidation;
using System;

namespace EventHandlers.Queries.GetPlayerCards
{
    /// <summary>
    /// Validator for <see cref="GetGameInformationsQuery"/>.
    /// </summary>
    public class GetGameInformationsQueryValidator : AbstractValidator<GetGameInformationsQuery>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GetGameInformationsQueryValidator()
        {
            RuleFor(query => query.GameId).NotNull().NotEqual(default(Guid));

            RuleFor(query => query.PlayerId).NotNull().NotEqual(default(Guid));
        }
    }
}
