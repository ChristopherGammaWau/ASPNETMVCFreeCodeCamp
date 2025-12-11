using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstProj.Models;

[Table("click_event")]
public partial class ClickEvent
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("click_date", TypeName = "timestamp(6) without time zone")]
    public DateTime? ClickDate { get; set; }

    [Column("url_mapping_id")]
    public long? UrlMappingId { get; set; }

    [ForeignKey("UrlMappingId")]
    [InverseProperty("ClickEvents")]
    public virtual UrlMapping? UrlMapping { get; set; }
}
