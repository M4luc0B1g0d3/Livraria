﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Model.Models;

public partial class ItemAlugado
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("idLivro")]
    public int IdLivro { get; set; }

    [Column("idCliente")]
    public int IdCliente { get; set; }

    [Column("dataEntrega", TypeName = "date")]
    public DateTime DataEntrega { get; set; }

    [Column("retornado")]
    public bool Retornado { get; set; }

    [Column("alugadoId")]
    public int AlugadoId { get; set; }

    [ForeignKey("AlugadoId")]
    [InverseProperty("ItemAlugado")]
    public virtual Alugado Alugado { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("ItemAlugado")]
    public virtual Cliente IdClienteNavigation { get; set; }

    [ForeignKey("IdLivro")]
    [InverseProperty("ItemAlugado")]
    public virtual Livro IdLivroNavigation { get; set; }
}