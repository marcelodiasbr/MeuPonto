﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeuPonto.Modules.Perfis.Empregadores;

public class Empregador : GlobalTableEntity, Concepts.Empregador
{
    [Required]
    [MinLength(3)]
    [MaxLength(36)]
    [DisplayName("Nome")]
    public string? Nome { get; set; }

    //[Required]
    [StringLength(14)]
    [DisplayName("CNPJ")]
    public string? Cnpj { get; set; }

    //[Required]
    [StringLength(11)]
    [DisplayName("CPF")]
    public string? Cpf { get; set; }

    [StringLength(12)]
    [DisplayName("Inscrição Estadual")]
    public string? InscricaoEstadual { get; set; }

    [MaxLength(36)]
    [DisplayName("Endereço")]
    public string? Endereco { get; set; }
}