namespace LibreLegends.Cli;

public class CreateCardsCommand : ICommand
{
    public string Name => "create";
    public string Outline => "Create a new card";

    public string Description => "Cards are created through a JSON object";
    
    public string Usage => string.Empty;

    public string[] Examples => [];
    public int Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}

public class CardsCommandGroup : CommandGroup
{
    public override string Name => "cards";
    public override string Outline => "Manage cards";
    public override string Description => "Manage cards available in the game";
    public override string Usage => string.Empty;
    public override string[] Examples => [];
}

public class App : CommandGroup
{
    public override string Name => "librelegends";
    public override string Outline => "Manage the game and content";
    public override string Description => string.Empty;
    public override string Usage => "librelegends [options] [command]";
    public override string[] Examples => [];
}