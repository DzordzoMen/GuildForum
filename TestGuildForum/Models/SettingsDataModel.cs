﻿using System.ComponentModel.DataAnnotations;

namespace GuildForum.Models {
  public class SettingsDataModel {
    [Key]
    public string Id { get; set; }

    [Required]
    [MaxLength(256)]
    public string Name { get; set; }

    [Required]
    [MaxLength(2048)]
    public string Value { get; set; }
  }
}
