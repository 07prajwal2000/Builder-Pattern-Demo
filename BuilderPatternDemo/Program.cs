using BuilderPatternDemo;

var connectionString = MySqlConnectionBuilder
    .FromUsername("prajwal")
    .WithPassword("12345")
    .HasHost("127.0.0.1")
    .HavingPort(3306)
    .ContainsDatabase("builder_pattern_demo")
    .Build();

Console.WriteLine(connectionString);