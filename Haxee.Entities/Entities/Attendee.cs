﻿namespace Haxee.Entities.Entities
{
    public class Attendee : AbstractEntity
    {
        public DateTime? StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }

        public required string UserId { get; set; }

        public string? CardId { get; set; }

        public required int YearId { get; set; }
        public virtual Year Year { get; set; } = null!;

        public virtual User User { get; set; } = null!;

        public virtual List<StandVisit> StandVisits { get; set; } = new();
    }
}