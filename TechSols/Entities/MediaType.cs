﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSols.Entities
{
	public class MediaType
	{
		public int Id { get; set; }

		[Required]
		[StringLength(200, MinimumLength = 2)]
		public string Title { get; set; }

		[Required]
		public string ThumbnailImagePath { get; set; }

		[ForeignKey("MediaTypeId")]
		public virtual ICollection<CategoryItem> CategoryItems { get; set; }
	}
}
