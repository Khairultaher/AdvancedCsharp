// See https://aka.ms/new-console-template for more information

// 11
string longMessage = """
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have "quoted text" in them.
    """;

Console.WriteLine(longMessage);


// 11
var location = $$"""
   You are at {{{12}}, {{13}}}
                   "quoted text"
   """;
Console.WriteLine(location);



location = $$"""
   You are at {{12}}, {{13}}
                   "quoted text"
   """;
Console.WriteLine(location);


var filePath = """F:\PRACTICE\AdvancedCsharp\README.md""";

try
{
    string content = await File.ReadAllTextAsync(filePath);
    Console.WriteLine(content);
}
catch (IOException e)
{
    Console.WriteLine($"An error occurred while reading the file: {e.Message}");
}


string notNull = "Hello";
string? nullable = default;
notNull = nullable!; // null forgiveness
if (notNull is null)
{
    Console.WriteLine($$"""{{notNull}}""");
}
else
{
    Console.WriteLine(notNull);
}



