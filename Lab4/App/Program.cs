using System.Text;
using ClassLib;
using McMaster.Extensions.CommandLineUtils;

const string DefaultInputFileName = "INPUT.TXT";
const string DefaultOutputFileName = "OUTPUT.TXT";

Console.OutputEncoding = Encoding.Unicode;

var app = new CommandLineApplication
{
    Name = "Oleg_Plema",
    Description = "Crossplatform lab work 4",
};

app.HelpOption();

app.Command("version", versionCmd =>
{
    versionCmd.Description = "Show version";
    versionCmd.OnExecute(() =>
    {
        Console.WriteLine("Author: Oleg Plema, IPZ-31");
        Console.WriteLine("Version: 1.0.0");
    });
});

app.Command("set-path", setPath =>
{
    setPath.Description = "Set path to folder with input and output files";
    var path = setPath.Option("-p|--path", "Path to folder", CommandOptionType.SingleValue).IsRequired();
    setPath.OnExecute(() =>
    {
        if (OperatingSystem.IsWindows())
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path.Value(), EnvironmentVariableTarget.User);
        }
        else
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path.Value());
        }
    });
});

app.Command("run", run =>
{
    run.Description = "Run lab";
    run.OnExecute(() =>
    {
        Console.WriteLine("Specify the lab to run");
        run.ShowHelp();
    });

    var input = run.Option("-i|--input", "Input file path", CommandOptionType.SingleValue, true);
    var output = run.Option("-o|--output", "Output file path", CommandOptionType.SingleValue, true);

    run.Command("lab1", lab1 =>
    {
        lab1.Description = "Run lab 1";
        lab1.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Path.Combine("..", "Files", "Lab1"); 
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);
            Lab1.Execute(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

    run.Command("lab2", lab2 =>
    {
        lab2.Description = "Run lab 2";
        lab2.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Path.Combine("..", "Files", "Lab2"); 
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);
            Lab2.Execute(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

    run.Command("lab3", lab3 =>
    {
        lab3.Description = "Run lab 3";
        lab3.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Path.Combine("..", "Files", "Lab3"); 
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);
            Lab3.Execute(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

});

app.OnExecute(() =>
{
    Console.WriteLine("Specify a subcommand");
    app.ShowHelp();
});

try
{
    app.Execute(args);
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
}
