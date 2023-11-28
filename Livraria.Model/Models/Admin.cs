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

public partial class Admin
{
    [Key]
    [Column("id")]
    [DisplayName("Código")]
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required]
    [Column("nome")]
    [StringLength(80)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Required]
    [Column("login")]
    [StringLength(50)]
    [Unicode(false)]
    public string Login { get; set; }

    [Required]
    [Column("senha")]
    [StringLength(255)]
    [Unicode(false)]
    public string Senha { get; set; }
}