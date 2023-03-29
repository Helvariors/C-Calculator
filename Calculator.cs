string errorCode;
string exitCode = "exit";
string inputFN;
string entryMessage = "Napiš: \n \"exit\" - pro ukončení programu \n";
string entryMessage2 = "Operátoři\n+,-,*,/,exp,root,%";
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Kalkulačka - V.1.2");
Console.ResetColor();
Console.WriteLine(entryMessage);

Main(); //start
void Main()
{
    Console.WriteLine("\n ---------------------------------------- \n");
    Console.ForegroundColor = ConsoleColor.Yellow; //operator text color
    Console.WriteLine(entryMessage2);
    Console.ResetColor();
    Console.WriteLine("\n ---------------------------------------- \n");
    Console.ForegroundColor = ConsoleColor.Green; //first number color
    Console.WriteLine("První číslo:");
    Console.ResetColor();
    inputFN = Console.ReadLine();
    if (float.TryParse(inputFN, out float firstNumber)){} //check if first number is valid
    else
    {
        if (inputFN == exitCode) //check if user wants to exit
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n------------Application ended------------");
            Console.ResetColor();
            Environment.Exit(0);
        }
        else
        {
            errorCode = "FNInvalid";
            Error();
        }
    }
    Console.ForegroundColor = ConsoleColor.DarkYellow; //operator color
    Console.WriteLine("Operátor:");
    Console.ResetColor();
    string op = Console.ReadLine();
    if (op != "+" && op != "-" && op != "*" && op != "/" && op != ":" && op != "exp" && op != "root" && op != "%") //check if operator is valid
    {
        errorCode = "OpInvalid";
        Error();
    }
    Console.ForegroundColor = ConsoleColor.Green; //second number color
    Console.WriteLine("Druhé číslo:");
    Console.ResetColor();
    if (float.TryParse(Console.ReadLine(), out float secondNumber)){} //check if second number is valid
    else
    {
        errorCode = "SNInvalid";
        Error();
    }
    Console.WriteLine("=");
    Console.ForegroundColor = ConsoleColor.Cyan;//answer color
    switch (op) //check which operator is used
    {
        case "+":
            Console.WriteLine(Plus(firstNumber, secondNumber));
            break;
        case "-":
            Console.WriteLine(Minus(firstNumber, secondNumber));
            break;
        case "*":
            Console.WriteLine(Multiplication(firstNumber, secondNumber));
            break;
        case "/":
            Console.WriteLine(Division(firstNumber, secondNumber));
            break;
        case ":":
            Console.WriteLine(Division(firstNumber, secondNumber));
            break;
        case "exp":
            Console.WriteLine(Exponentation(firstNumber, secondNumber));
            break;
        case "root":
            Console.WriteLine(Root(firstNumber, secondNumber));
            break;
        case "%":
            Console.WriteLine(Percent(firstNumber, secondNumber));
            break;
        default:
            errorCode = "OpInvalid";
            Error();
            break;
    }
    Console.ResetColor();
    Main(); //restart
}
///////////// Operator functions /////////////
float Plus(float fn, float sn)
{return fn + sn;}
float Minus(float fn, float sn)
{return fn - sn;}
float Multiplication(float fn, float sn)
{return fn * sn; }
float Division(float fn, float sn)
{ return fn / sn; }
float Exponentation(float fn, float sn)
{
    float sus = fn;
    for (int i = 1; i < sn; i++)
    {
        fn = fn * sus;
    }
    return fn;
}
float Root(float fn, float sn)
{
    float root = (float)Math.Pow(fn, (1.0 / sn));
    return root;
}
float Percent(float fn, float sn)
{return sn / 100 * fn; }
///////////// Error functions /////////////
void Error()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    switch (errorCode)
    {
        case "FNInvalid":
            Console.WriteLine("First Number is invalid");
            break;
        case "OpInvalid":
            Console.WriteLine("Operator is invalid");
            break;
        case "SNInvalid":
            Console.WriteLine("Second Number is invalid");
            break;
        default:
            Console.WriteLine("Error not specified");
            break;
    }
    Console.WriteLine("\n");
    errorCode = "null";
    Console.ResetColor();
    Main();
}