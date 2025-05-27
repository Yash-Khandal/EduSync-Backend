// EduSync/DTOs/ResultForCreationDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace EduSync.DTOs
{
    public class ResultForCreationDto
    {
        [Required(ErrorMessage = "Assessment ID is required.")]
        public Guid AssessmentId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Score is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Score cannot be negative.")]
        public int Score { get; set; }
    }
}