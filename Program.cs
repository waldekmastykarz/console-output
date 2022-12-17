var defaultColor = Console.ForegroundColor;

Write("← ← intercepted request");
WriteWithColor("↑ ↑ request passed thru to Graph", ConsoleColor.DarkGreen);
WriteWithColor(" !  Warning", ConsoleColor.Yellow);
WriteWithColor(" i  Tip", ConsoleColor.Blue);
WriteWithColor("x → Failed", ConsoleColor.DarkRed);
WriteWithColor("o → Mocked", ConsoleColor.DarkYellow);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Write("← ← GET https://graph.microsoft.com/v1.0/me?$select=id");
WriteWithColor("↑ ↑ GET https://graph.microsoft.com/v1.0/me?$select=id", ConsoleColor.DarkGreen);
WriteWithColor(" !  To improve performance of your application, use the $select parameter. More info at https://learn.microsoft.com/graph/query-parameters#select-parameter", ConsoleColor.Yellow);
WriteWithColor(" i  To handle API errors more easily, use the Graph SDK. More info at https://aka.ms/move-to-graph-js-sdk", ConsoleColor.Blue);
WriteWithColor("x → 429 Too Many Requests", ConsoleColor.DarkRed);
WriteWithColor("x → Calling https://graph.microsoft.com/v1.0/me?$select=id again before waiting for the Retry-After period. Request will be throttled", ConsoleColor.Red);
WriteWithColor("o → 200 OK https://graph.microsoft.com/v1.0/me*", ConsoleColor.DarkYellow);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Write("⬅️ GET https://graph.microsoft.com/v1.0/me?$select=id");
WriteWithColor("🦒 GET https://graph.microsoft.com/v1.0/me?$select=id", ConsoleColor.DarkGreen);
WriteWithColor("⚠️ To improve performance of your application, use the $select parameter. More info at https://learn.microsoft.com/graph/query-parameters#select-parameter", ConsoleColor.Yellow);
WriteWithColor("ℹ️  To handle API errors more easily, use the Graph SDK. More info at https://aka.ms/move-to-graph-js-sdk", ConsoleColor.Blue);
WriteWithColor("🛑 429 Too Many Requests", ConsoleColor.DarkRed);
WriteWithColor("🐞 Calling https://graph.microsoft.com/v1.0/me?$select=id again before waiting for the Retry-After period. Request will be throttled", ConsoleColor.Red);
WriteWithColor("↪️ 200 OK https://graph.microsoft.com/v1.0/me*", ConsoleColor.DarkYellow);


void Write(string message)
{
  Console.WriteLine(message);
}

void WriteWithColor(string message, ConsoleColor color)
{
  Console.ForegroundColor = color;
  Write(message);
  Console.ForegroundColor = defaultColor;
}