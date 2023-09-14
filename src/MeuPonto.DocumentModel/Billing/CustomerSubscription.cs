﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace MeuPonto.Billing;

public class CustomerSubscription
{
    [Required]
    [DisplayName("Plano de Assinatura")]
    public SubscriptionPlanEnum? SubscriptionPlanId { get; set; }
}
