﻿using System.ComponentModel.DataAnnotations;

namespace MeuPonto.Modules.Pontos;

public enum MomentoEnum
{
    [Display(Name = "Entrada")]
    Entrada = 1,

    [Display(Name = "Saída")]
    Saida = 2,

    [Display(Name = "Errado")]
    Errado = 3
}
