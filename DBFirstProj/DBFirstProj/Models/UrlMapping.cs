using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstProj.Models;

[Table("url_mapping")]
public partial class UrlMapping
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("click_count")]
    public int ClickCount { get; set; }

    [Column("created_date", TypeName = "timestamp(6) without time zone")]
    public DateTime? CreatedDate { get; set; }

    [Column("original_url")]
    [StringLength(255)]
    public string? OriginalUrl { get; set; }

    [Column("short_url")]
    [StringLength(255)]
    public string? ShortUrl { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }

    [InverseProperty("UrlMapping")]
    public virtual ICollection<ClickEvent> ClickEvents { get; set; } = new List<ClickEvent>();

    [ForeignKey("UserId")]
    [InverseProperty("UrlMappings")]
    public virtual User? User { get; set; }
}
