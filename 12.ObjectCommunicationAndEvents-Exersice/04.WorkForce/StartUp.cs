using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();
        JobList jobs = new JobList();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Job job = null;
            Employee employee = null;

            switch (commandTokens[0])
            {
                case "Job":
                    string jobName = commandTokens[1];
                    int hoursRequired = int.Parse(commandTokens[2]);
                    employee = employees.First(e => e.Name == commandTokens[3]);
                    job = new Job(jobName, hoursRequired, employee);
                    jobs.AddJob(job);
                    break;
                case "StandardEmployee":
                    employee = new StandartEmployee(commandTokens[1]);
                    employees.Add(employee);
                    break;
                case "PartTimeEmployee":
                    employee = new PartTimeEmployee(commandTokens[1]);
                    employees.Add(employee);
                    break;
                case "Pass":
                    Pass(jobs);
                    break;
                case "Status":
                    Status(jobs);
                    break;
            }

            input = Console.ReadLine();
        }
    }

    private static void Status(JobList jobs)
    {
        foreach (Job job in jobs)
        {
            Console.WriteLine(job);
        }
    }

    private static void Pass(List<Job> jobs)
    {
        foreach (Job job in jobs.ToList())
        {
            job.Update();
        }
    }
}