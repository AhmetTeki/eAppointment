using Ardalis.SmartEnum;

namespace eAppointmentServer.Domain.Enums;

public sealed class DepartmentEnum : SmartEnum<DepartmentEnum>
{
    public static readonly DepartmentEnum Acil = new("Acil", 1);
    public static readonly DepartmentEnum Radyoloji = new("Radyoloji", 2);
    public static readonly DepartmentEnum Kardiyoloji = new("Kardiyoloji", 3);
    public static readonly DepartmentEnum Dermotoloji = new("Dermotoloji", 4);
    public static readonly DepartmentEnum Psikiyatri = new("Psikiyatri", 5);
    public DepartmentEnum(string name, int value) : base(name, value)
    {
    }
}