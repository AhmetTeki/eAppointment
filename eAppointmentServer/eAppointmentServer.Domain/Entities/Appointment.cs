namespace eAppointmentServer.Domain.Entities;

public sealed class Appointment
{
    public Appointment()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    private Doctor? Doctor;
    public Guid PatientId { get; set; }
    private Patient? Patient;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCompleted { get; set; }
}