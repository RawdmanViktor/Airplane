string fileName = "preplannedCourse.txt";
string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Data\", fileName);

int direction = 0;
int horizontal = 0;
int vertical = 0;

foreach (var course in File.ReadAllLines(path))
{
    string[] courseDetails = course.Split(" ");
    string command = courseDetails[0];
    int value = Convert.ToInt32(courseDetails[1]);

    if (command == "forward")
    {
        calculateForward(value);
    }
    if (command == "up")
    {
        calculateUp(value);
    }
    if (command == "down")
    {
        calculateDown(value);
    }

}

calculateTotal();

void calculateForward(int value)
{
    horizontal += value;
    vertical = (value * direction) + vertical;
}
void calculateUp(int value)
{
    direction += value;
}
void calculateDown(int value)
{
    direction -= value;
}
void calculateTotal()
{
    Console.WriteLine(horizontal * vertical);
}
