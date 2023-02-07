using System;
using System.Collections.Generic;

abstract class Operation
{
    public abstract void Execute(int value);
}

class ForwardOperation : Operation
{
    private int direction;
    private int horizontal;
    private int vertical;

    public ForwardOperation(int direction, ref int horizontal, ref int vertical)
    {
        this.direction = direction;
        this.horizontal = horizontal;
        this.vertical = vertical;
    }

    public override void Execute(int value)
    {
        horizontal += value;
        vertical = (value * direction) + vertical;
    }
}

class UpOperation : Operation
{
    private int direction;

    public UpOperation(ref int direction)
    {
        this.direction = direction;
    }

    public override void Execute(int value)
    {
        direction += value;
    }
}

class DownOperation : Operation
{
    private int direction;

    public DownOperation(ref int direction)
    {
        this.direction = direction;
    }

    public override void Execute(int value)
    {
        direction -= value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string fileName = "preplannedCourse.txt";
        string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Data\", fileName);

        int direction = 0;
        int horizontal = 0;
        int vertical = 0;

        Dictionary<string, Func<int, Operation>> operations = new Dictionary<string, Func<int, Operation>>
        {
            { "forward", value => new ForwardOperation(direction, ref horizontal, ref vertical) },
            { "up", value => new UpOperation(ref direction) },
            { "down", value => new DownOperation(ref direction) },
        };

        foreach (var course in File.ReadAllLines(path))
        {
            string[] courseDetails = course.Split(" ");
            string command = courseDetails[0];
            int value = Convert.ToInt32(courseDetails[1]);

            if (operations.TryGetValue(command, out var operationFactory))
            {
                Operation operation = operationFactory(value);
                operation.Execute(value);
            }
            else
            {
                Console.WriteLine($"Unknown command: {command}");
            }
        }

        Console.WriteLine(horizontal * vertical);
    }
}