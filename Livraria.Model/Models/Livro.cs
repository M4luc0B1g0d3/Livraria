﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Model.Models;

public partial class Livro
{
    [Key]
    [Column("id")]
    [HiddenInput(DisplayValue = false)]
    [DisplayName("Código")]
    public int Id { get; set; }

    [Required]
    [Column("nome")]
    [StringLength(80)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Required]
    [Column("capa")]
    [StringLength(255)]
    [Unicode(false)]
    public string Capa { get; set; }

    [Required]
    [Column("ano")]
    [StringLength(4)]
    [Unicode(false)]
    public string Ano { get; set; }

    [Required]
    [Column("autor")]
    [StringLength(80)]
    [Unicode(false)]
    public string Autor { get; set; }

    [Required]
    [Column("genero")]
    [StringLength(50)]
    [Unicode(false)]
    [DisplayName("Gênero")]
    public string Genero { get; set; }

    [InverseProperty("IdLivroNavigation")]
    public virtual ICollection<Alugado> Alugado { get; set; } = new List<Alugado>();

    [InverseProperty("IdLivroNavigation")]
    public virtual ICollection<ItemAlugado> ItemAlugado { get; set; } = new List<ItemAlugado>();
}