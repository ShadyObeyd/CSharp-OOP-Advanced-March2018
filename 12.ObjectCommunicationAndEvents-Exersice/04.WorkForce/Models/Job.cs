using System;

public delegate void JobCompletedHandler(Job job);

public class Job
{
    public event JobCompletedHandler JobCompleted;

    private string name;
    private int hoursOfWorkRequired;

    public Job(string name, int hoursOfWorkRequired, Employee employee)
    {
        this.name = name;
        this.hoursOfWorkRequired = hoursOfWorkRequired;
        this.Employee = employee;
    }

    public Employee Employee { get; private set; }

    public void Update()
    {
        this.hoursOfWorkRequired -= this.Employee.HoursPerWeek;

        if (this.hoursOfWorkRequired <= 0)
        {
            Console.WriteLine($"{this.GetType().Name} {this.name} done!");
            this.JobCompleted.Invoke(this);
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.name} Hours Remaining: {this.hoursOfWorkRequired}";
    }
}
