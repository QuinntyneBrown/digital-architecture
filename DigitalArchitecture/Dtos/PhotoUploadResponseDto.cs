﻿using DigitalArchitecture.Models;
using System.Collections.Generic;

namespace DigitalArchitecture.Dtos
{
    public class PhotoUploadResponseDto
    {
        public PhotoUploadResponseDto()
        {

        }

        public PhotoUploadResponseDto(ICollection<Photo> photos)
        {
            foreach (var photo in photos)
            {
                Files.Add(new PhotoDto(photo));
            }
        }

        public IList<PhotoDto> Files { get; set; } = new List<PhotoDto>();
    }
}
