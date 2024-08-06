namespace Activity.Domain;

public class User : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public DateOnly BirthDate { get; set; }

    public int Age
    {
        get
        {
            return CalculateAge(BirthDate);
        }
    }

    public decimal BMI
    {
        get
        {
            return CalculateBMI(Weight, Height);
        }
    }

    private int CalculateAge(DateOnly birthDate)
    {
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        int age = currentDate.Year - birthDate.Year;

        if (currentDate < birthDate.AddYears(age))
        {
            age--;
        }
        return age;
    }

    private decimal CalculateBMI(decimal weight, decimal height)
    {
        if (height <= 0)
        {
            throw new ArgumentException("Height must be greater than zero.");
        }
        return weight / (height * height);
    }
}