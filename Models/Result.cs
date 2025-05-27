using EduSync.Models;

public class Result
{
    public Guid ResultId { get; set; }
    public Guid AssessmentId { get; set; }
    public Guid UserId { get; set; }
    public int Score { get; set; }
    public DateTime AttemptDate { get; set; }
    public bool Published { get; set; } // <-- Add this line

    // Navigation properties
    public virtual Assessment Assessment { get; set; }
    public virtual User User { get; set; }
}
