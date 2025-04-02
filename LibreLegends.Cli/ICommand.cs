namespace LibreLegends.Cli;

public interface ICommand
{
    string Name { get; }
    string Outline { get; }
    string Description { get; }
    public abstract string Usage { get; }
    public abstract string[] Examples { get; }
    int Execute(string[] args);
}