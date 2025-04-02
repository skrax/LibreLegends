namespace LibreLegends.Cli;

public abstract class CommandGroup : ICommand
{
    private readonly Dictionary<string, ICommand> _subCommands = [];

    public abstract string Name { get; }
    
    public abstract string Outline { get; }
    
    public abstract string Description { get; }
    
    public abstract string Usage { get; }
    
    public abstract string[] Examples { get; }

    public void AddSubCommand(ICommand command)
    {
        _subCommands[command.Name] = command;
    }

    public int Execute(string[] args)
    {
        if (args.Length == 0 || args[0] == "--help" || args[0] == "-h")
        {
            PrintHelp();
            return 0;
        }

        var subCommandName = args[0];
        if (_subCommands.TryGetValue(subCommandName, out ICommand command))
        {
            return command.Execute(args.Skip(1).ToArray());
        }

        Console.WriteLine($"Unknown subcommand: {subCommandName}");
        PrintHelp();
        return 1;
    }

    private void PrintHelp()
    {
        Console.WriteLine(Outline);
        Console.WriteLine();
        if (!string.IsNullOrWhiteSpace(Description))
        {
            Console.WriteLine("Description:");
            Console.WriteLine($"  {Description}");
            Console.WriteLine();
        }

        if (!string.IsNullOrWhiteSpace(Usage))
        {
            Console.WriteLine("Usage:");
            Console.WriteLine($"  {Usage}");
            Console.WriteLine();
        }

        if (Examples.Length != 0)
        {
            Console.WriteLine("Examples:");
            foreach (var example in Examples)
            {
                Console.WriteLine($"  {example}");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("Available Commands:");

        foreach (var cmd in _subCommands.Values.OrderBy(c => c.Name))
        {
            Console.WriteLine($"  {cmd.Name,-15} {cmd.Outline}");
        }
        
        Console.WriteLine();
    }
}