namespace Tutorial6.DTOs
{
    public class CreateReservationDto
    {
        public int RoomId { get; set; }
        public string OrganizerName { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
