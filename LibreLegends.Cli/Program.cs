using LibreLegends.Cli;

var app = new App();

var cardsCommandGroup = new CardsCommandGroup();

cardsCommandGroup.AddSubCommand(new CreateCardsCommand());

app.AddSubCommand(cardsCommandGroup);

app.Execute(args);
