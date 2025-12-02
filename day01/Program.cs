string path = "input.txt";
int code = 50;
int zero_count = 0;

string[] readText = File.ReadAllLines(path);
bool counted = false;
foreach (var line in readText)
{
    string direction = line.Substring(0, 1);
    int amount = Int32.Parse(line.Substring(1, line.Length - 1));
    bool start_zero = false;
    if (direction == "L")
    {
        if (code == 0) start_zero = true;
        while (amount > 99)
        {
            zero_count++;
            amount -= 100;
        }
        code -= amount;
        if (code < 0)
        {
            code += 100;
            if (!start_zero)
            {
                zero_count++;
                counted = true;
            }
        }
    }
    else
    {
        if (code == 0) start_zero = true;
        while (amount > 99)
        {
            zero_count++;
            amount -= 100;
        }
        code += amount;
        if (code > 99)
        {
            code -= 100;
            if (!start_zero)
            {
                zero_count++;
                counted = true;
            }
        }
    }
    if (code == 0 && !counted)
    {
        zero_count++;
    }
    counted = false;
}
Console.WriteLine("Result: " + zero_count);
