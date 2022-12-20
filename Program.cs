﻿Console.OutputEncoding = System.Text.Encoding.UTF8;

var defaultFgColor = Console.ForegroundColor;
var defaultBgColor = Console.BackgroundColor;

var legend = new[] {
  ("intercepted request", MessageType.InterceptedRequest),
  ("request passed through to Graph", MessageType.PassedThrough),
  ("Warning", MessageType.Warning),
  ("Tip", MessageType.Tip),
  ("Chaos", MessageType.Failed),
  ("Error", MessageType.Error),
  ("Mocked", MessageType.Mocked)
};
var sampleData = new[] {
  ("GET https://graph.microsoft.com/v1.0/me?$select=id", MessageType.InterceptedRequest),
  (" ↪ passed through", MessageType.PassedThrough),
  ("To improve performance of your application, use the $select parameter.", MessageType.Warning),
  (" ↪ More info at https://learn.microsoft.com/graph/query-parameters#select-parameter", MessageType.Warning),
  ("To handle API errors more easily, use the Graph SDK.", MessageType.Tip),
  (" ↪ More info at https://aka.ms/move-to-graph-js-sdk", MessageType.Tip),
  ("429 Too Many Requests", MessageType.Failed),
  ("Calling https://graph.microsoft.com/v1.0/me?$select=id before waiting for the Retry-After period.", MessageType.Error),
  (" ↪ Request will be throttled", MessageType.Error),
  ("200 OK https://graph.microsoft.com/v1.0/me*", MessageType.Mocked)
};

void WriteData((string, MessageType)[] data, Action<string, MessageType> handler)
{
  foreach (var message in data)
  {
    handler(message.Item1, message.Item2);
  }

  Console.WriteLine();
  Console.WriteLine();
  Console.WriteLine();
}

WriteData(legend, WriteColorWithAsciiIcons);
WriteData(sampleData, WriteColorWithAsciiIcons);
WriteData(sampleData, WriteWithColorAsciiIcons);
WriteData(sampleData, WriteWithInvertedColorAsciiIcons);
WriteData(sampleData, WriteColorWithEmojiIcons);
WriteData(sampleData, WriteIndented);
WriteData(sampleData, WriteColorWithLabels);
WriteData(sampleData, WriteWithColorLabels);
WriteData(sampleData, WriteWithInvertedColorLabels);
WriteData(sampleData, WriteWithShortColorLabels);

void WriteColorWithAsciiIcons(string message, MessageType type)
{
  var icon = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      icon = "! →";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      icon = "× →";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      icon = "← ←";
      break;
    case MessageType.Mocked:
      icon = "o →";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      icon = "   ";
      break;
    case MessageType.PassedThrough:
      icon = "↑ ↑";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      icon = "(i)";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      icon = "/!\\";
      color = ConsoleColor.Yellow;
      break;
    default:
      icon = "   ";
      break;
  }

  Console.ForegroundColor = color;
  Console.WriteLine($"{icon} {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteWithColorAsciiIcons(string message, MessageType type)
{
  var icon = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      icon = "! →";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      icon = "× →";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      icon = "← ←";
      break;
    case MessageType.Mocked:
      icon = "o →";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      icon = "   ";
      break;
    case MessageType.PassedThrough:
      icon = "↑ ↑";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      icon = "(i)";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      icon = "/!\\";
      color = ConsoleColor.Yellow;
      break;
    default:
      icon = "   ";
      break;
  }

  Console.ForegroundColor = color;
  Console.Write(icon);
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($" {message}");
}

void WriteWithInvertedColorAsciiIcons(string message, MessageType type)
{
  var icon = "";
  var fgColor = defaultFgColor;
  var bgColor = defaultBgColor; 

  switch (type)
  {
    case MessageType.Error:
      icon = "! →";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      icon = "× →";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      icon = "← ←";
      break;
    case MessageType.Mocked:
      icon = "o →";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      icon = "   ";
      break;
    case MessageType.PassedThrough:
      icon = "↑ ↑";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      icon = "(i)";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      icon = "/!\\";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.Yellow;
      break;
    default:
      icon = "   ";
      break;
  }

  Console.BackgroundColor = bgColor;
  Console.ForegroundColor = fgColor;
  Console.Write($" {icon} ");
  Console.BackgroundColor = defaultBgColor;
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($" {message}");
}

void WriteColorWithEmojiIcons(string message, MessageType type)
{
  var icon = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      icon = "🐞";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      icon = "🛑";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      icon = "⬅️ ";
      break;
    case MessageType.Mocked:
      icon = "🔁";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      icon = " ";
      break;
    case MessageType.PassedThrough:
      icon = "🦒";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      icon = "ℹ️ ";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      icon = "❗️";
      color = ConsoleColor.Yellow;
      break;
    default:
      icon = " ";
      break;
  }

  Console.ForegroundColor = color;
  Console.WriteLine($"{icon} {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteIndented(string message, MessageType type)
{
  var indent = "";
  switch (type)
  {
    case MessageType.InterceptedRequest:
      indent = "";
      break;
    default:
      indent = "   ";
      break;
  }

  Console.WriteLine($"{indent}{message}");
}

void WriteColorWithLabels(string message, MessageType type)
{
  var label = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      label = "[  ERROR  ]";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      label = "[  CHAOS  ]";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      label = "[ REQUEST ]";
      break;
    case MessageType.Mocked:
      label = "[  MOCK   ]";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      label = "";
      break;
    case MessageType.PassedThrough:
      label = "[  GRAPH  ]";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      label = "[   TIP   ]";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      label = "[ WARNING ]";
      color = ConsoleColor.Yellow;
      break;
    default:
      label = "";
      break;
  }

  Console.ForegroundColor = color;
  Console.WriteLine($"{label}  {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteWithColorLabels(string message, MessageType type)
{
  var label = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      label = "[  ERROR  ]";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      label = "[  CHAOS  ]";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      label = "[ REQUEST ]";
      break;
    case MessageType.Mocked:
      label = "[  MOCK   ]";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      label = "";
      break;
    case MessageType.PassedThrough:
      label = "[  GRAPH  ]";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      label = "[   TIP   ]";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      label = "[ WARNING ]";
      color = ConsoleColor.Yellow;
      break;
    default:
      label = "";
      break;
  }

  Console.ForegroundColor = color;
  Console.Write(label);
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"  {message}");
}

void WriteWithInvertedColorLabels(string message, MessageType type)
{
  var label = "";
  var fgColor = defaultFgColor;
  var bgColor = defaultBgColor; 

  switch (type)
  {
    case MessageType.Error:
      label = "[  ERROR  ]";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      label = "[  CHAOS  ]";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      label = "[ REQUEST ]";
      break;
    case MessageType.Mocked:
      label = "[  MOCK   ]";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      label = "";
      break;
    case MessageType.PassedThrough:
      label = "[  GRAPH  ]";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      label = "[   TIP   ]";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      label = "[ WARNING ]";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.Yellow;
      break;
    default:
      label = "";
      break;
  }

  Console.BackgroundColor = bgColor;
  Console.ForegroundColor = fgColor;
  Console.Write(label);
  Console.BackgroundColor = defaultBgColor;
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"  {message}");
}

void WriteWithShortColorLabels(string message, MessageType type)
{
  var label = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      label = "FAIL ";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      label = "CHAOS";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      label = "REQST";
      break;
    case MessageType.Mocked:
      label = "MOCK ";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      label = "";
      break;
    case MessageType.PassedThrough:
      label = "GRAPH";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      label = "TIP  ";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      label = "WARN ";
      color = ConsoleColor.Yellow;
      break;
    default:
      label = "";
      break;
  }

  Console.ForegroundColor = color;
  Console.Write(label);
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"  {message}");
}

enum MessageType
{
  Normal,
  InterceptedRequest,
  PassedThrough,
  Warning,
  Tip,
  Failed,
  Error,
  Mocked
}