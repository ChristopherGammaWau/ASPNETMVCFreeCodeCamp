using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstProj.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("password")]
    [StringLength(255)]
    public string? Password { get; set; }

    [Column("role")]
    [StringLength(255)]
    public string? Role { get; set; }

    [Column("username")]
    [StringLength(255)]
    public string? Username { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UrlMapping> UrlMappings { get; set; } = new List<UrlMapping>();
}
