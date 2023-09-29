﻿using System.ComponentModel.DataAnnotations;

namespace MeuPonto.Enums;

public enum SubscriptionPlanEnum
{
    [Display(Name = "Bronze")]
    Bronze = 1,

    [Display(Name = "Prata")]
    Silver = 2,

    [Display(Name = "Ouro")]
    Gold = 3
}
