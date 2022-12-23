Console.OutputEncoding = System.Text.Encoding.UTF8;

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

void WriteData((string, MessageType)[] data, Action<string, MessageType, int> handler)
{
  foreach (var message in data)
  {
    handler(message.Item1, message.Item2, 1);
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
WriteData(sampleData, WriteColorWithNerdFontIconsOption1);
WriteData(sampleData, WriteWithInvertedNerdFontIconsOption1);
WriteData(sampleData, WriteColorWithNerdFontIconsOption2);
WriteMixedWithNerdFontIconsOption1();
WriteShadedWithNerdFontIconsOption1();
WriteBoxedWithNerdFontIconsOption1();
WriteNerdFontSample();

void WriteColorWithAsciiIcons(string message, MessageType type, int requestId = 1)
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
  Console.WriteLine($"{requestId} | {icon} {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteWithColorAsciiIcons(string message, MessageType type, int requestId = 1)
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
  Console.Write($"{requestId} | {icon}");
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($" {message}");
}

void WriteWithInvertedColorAsciiIcons(string message, MessageType type, int requestId = 1)
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
  Console.Write($" {requestId} | {icon} ");
  Console.BackgroundColor = defaultBgColor;
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($" {message}");
}

void WriteColorWithEmojiIcons(string message, MessageType type, int requestId = 1)
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
  Console.WriteLine($"{requestId} | {icon} {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteIndented(string message, MessageType type, int requestId = 1)
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

  Console.WriteLine($"{requestId} | {indent}{message}");
}

void WriteColorWithLabels(string message, MessageType type, int requestId = 1)
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
  Console.WriteLine($"{requestId} | {label}  {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteWithColorLabels(string message, MessageType type, int requestId = 1)
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
  Console.Write($"{requestId} | {label}");
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"  {message}");
}

void WriteWithInvertedColorLabels(string message, MessageType type, int requestId = 1)
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
  Console.Write($"{requestId} | {label}");
  Console.BackgroundColor = defaultBgColor;
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"  {message}");
}

void WriteWithShortColorLabels(string message, MessageType type, int requestId = 1)
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
  Console.Write($"{requestId} | {label}");
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"  {message}");
}

void WriteColorWithNerdFontIconsOption1(string message, MessageType type, int requestId = 1)
{
  var icon = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      icon = "\uf65b";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      icon = "\uf188";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      icon = "\uf441";
      break;
    case MessageType.Mocked:
      icon = "\uf064";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      icon = "   ";
      break;
    case MessageType.PassedThrough:
      icon = "\ue33c";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      icon = "\ufbe6";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      icon = "\uf421";
      color = ConsoleColor.Yellow;
      break;
    default:
      icon = "   ";
      break;
  }

  Console.ForegroundColor = color;
  Console.WriteLine($"{requestId} | {icon}   {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteWithInvertedNerdFontIconsOption1(string message, MessageType type, int requestId = 1) {
var icon = "";
  var fgColor = defaultFgColor;
  var bgColor = defaultBgColor; 

  switch (type)
  {
    case MessageType.Error:
      icon = "\uf65b";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      icon = "\uf188";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      icon = "\uf441";
      break;
    case MessageType.Mocked:
      icon = "\uf064";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      icon = "   ";
      break;
    case MessageType.PassedThrough:
      icon = "\ue33c";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      icon = "\ufbe6";
      fgColor = ConsoleColor.White;
      bgColor = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      icon = "\uf421";
      fgColor = ConsoleColor.Black;
      bgColor = ConsoleColor.Yellow;
      break;
    default:
      icon = "   ";
      break;
  }

  Console.BackgroundColor = bgColor;
  Console.ForegroundColor = fgColor;
  Console.Write($" {requestId} | {icon}  ");
  Console.BackgroundColor = defaultBgColor;
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($" {message}");
}

void WriteColorWithNerdFontIconsOption2(string message, MessageType type, int requestId = 1)
{
  var icon = "";
  var color = defaultFgColor;

  switch (type)
  {
    case MessageType.Error:
      icon = "\uf00d";
      color = ConsoleColor.Red;
      break;
    case MessageType.Failed:
      icon = "\uf0d0";
      color = ConsoleColor.DarkRed;
      break;
    case MessageType.InterceptedRequest:
      icon = "\uea9b";
      break;
    case MessageType.Mocked:
      icon = "\uf710";
      color = ConsoleColor.DarkYellow;
      break;
    case MessageType.Normal:
      icon = "   ";
      break;
    case MessageType.PassedThrough:
      icon = "\ueaa1";
      color = ConsoleColor.Gray;
      break;
    case MessageType.Tip:
      icon = "\uf05a";
      color = ConsoleColor.Blue;
      break;
    case MessageType.Warning:
      icon = "\uf490";
      color = ConsoleColor.Yellow;
      break;
    default:
      icon = "   ";
      break;
  }

  Console.ForegroundColor = color;
  Console.WriteLine($"{requestId} | {icon}   {message}");
  Console.ForegroundColor = defaultFgColor;
}

void WriteMixedWithNerdFontIconsOption1() {
  WriteColorWithNerdFontIconsOption1("GET https://graph.microsoft.com/v1.0/me/joinedTeams?$select=displayName,id,isArchived", MessageType.InterceptedRequest, 1);
  WriteColorWithNerdFontIconsOption1("GET https://graph.microsoft.com/v1.0/me/todo/lists", MessageType.InterceptedRequest, 2);
  WriteColorWithNerdFontIconsOption1("GET https://graph.microsoft.com/v1.0/me/planner/plans", MessageType.InterceptedRequest, 3);

  WriteColorWithNerdFontIconsOption1(" ↪ passed through", MessageType.PassedThrough, 1);
  WriteColorWithNerdFontIconsOption1(" ↪ passed through", MessageType.PassedThrough, 3);
  WriteColorWithNerdFontIconsOption1(" ↪ passed through", MessageType.PassedThrough, 2);

  WriteColorWithNerdFontIconsOption1("To improve performance of your application, use the $select parameter.", MessageType.Warning, 3);
  WriteColorWithNerdFontIconsOption1(" ↪ More info at https://learn.microsoft.com/graph/query-parameters#select-parameter", MessageType.Warning, 3);
  WriteColorWithNerdFontIconsOption1("To improve performance of your application, use the $select parameter.", MessageType.Warning, 2);
  WriteColorWithNerdFontIconsOption1(" ↪ More info at https://learn.microsoft.com/graph/query-parameters#select-parameter", MessageType.Warning, 2);

  WriteColorWithNerdFontIconsOption1("GET https://graph.microsoft.com/v1.0/me/calendarview?$orderby=start/dateTime&startdatetime=2022-12-22T18:55:40.901Z&enddate=2022-12-25T18:55:40.901Z", MessageType.InterceptedRequest, 4);
  WriteColorWithNerdFontIconsOption1(" ↪ passed through", MessageType.PassedThrough, 4);
  WriteColorWithNerdFontIconsOption1("To improve performance of your application, use the $select parameter.", MessageType.Warning, 4);
  WriteColorWithNerdFontIconsOption1(" ↪ More info at https://learn.microsoft.com/graph/query-parameters#select-parameter", MessageType.Warning, 4);

  Console.WriteLine();
  Console.WriteLine();
  Console.WriteLine();
}

void WriteShadedWithNerdFontIconsOption1()
{
  var iconSpacing = "  ";
  var noIconSpacing = " ";
  var secondLine = " \ufb0c ";
  var interceptedRequest = "\uf441";
  var passedThrough = "\ue33c";
  var warning = "\uf421";

  // intercept
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/joinedTeams?$select=displayName,id,isArchived");
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/todo/lists");
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/planner/plans");

  // passed through
  Console.ForegroundColor = ConsoleColor.Gray;
  Console.WriteLine($"{passedThrough}{iconSpacing}passed through");
  Console.ForegroundColor = ConsoleColor.DarkGray;
  Console.WriteLine($"{noIconSpacing}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/joinedTeams?$select=displayName,id,isArchived");

  Console.ForegroundColor = ConsoleColor.Gray;
  Console.WriteLine($"{passedThrough}{iconSpacing}passed through");
  Console.ForegroundColor = ConsoleColor.DarkGray;
  Console.WriteLine($"{noIconSpacing}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/planner/plans");

  Console.ForegroundColor = ConsoleColor.Gray;
  Console.WriteLine($"{passedThrough}{iconSpacing}passed through");
  Console.ForegroundColor = ConsoleColor.DarkGray;
  Console.WriteLine($"{noIconSpacing}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  // warning
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine($"{warning}{iconSpacing}To improve performance of your application, use the $select parameter.");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{secondLine}More info at https://learn.microsoft.com/graph/query-parameters#select-parameter");
  Console.ForegroundColor = ConsoleColor.DarkYellow;
  Console.WriteLine($"{noIconSpacing}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/planner/plans");

  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine($"{warning}{iconSpacing}To improve performance of your application, use the $select parameter.");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{secondLine}More info at https://learn.microsoft.com/graph/query-parameters#select-parameter");
  Console.ForegroundColor = ConsoleColor.DarkYellow;
  Console.WriteLine($"{noIconSpacing}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine();
  Console.WriteLine();
  Console.WriteLine();
}

void WriteBoxedWithNerdFontIconsOption1()
{
  var iconSpacing = "  ";
  var noIconSpacing = " ";
  var interceptedRequest = "\uf441";
  var passedThrough = "\ue33c";
  var chaos = "\uf188";
  var warning = "\uf421";
  var error = "\uf65b";
  var topLeft = "\u250c ";
  var left = "\u2502 ";
  var bottomLeft = "\u2514 ";

  // intercept
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/joinedTeams?$select=displayName,id,isArchived");
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/todo/lists");
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/planner/plans");

  // passed through
  Console.ForegroundColor = ConsoleColor.Gray;
  Console.WriteLine($"{passedThrough}{iconSpacing}{topLeft}passed through");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/joinedTeams?$select=displayName,id,isArchived");

  Console.ForegroundColor = ConsoleColor.Gray;
  Console.WriteLine($"{passedThrough}{iconSpacing}{topLeft}passed through");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/planner/plans");

  Console.ForegroundColor = ConsoleColor.Gray;
  Console.WriteLine($"{passedThrough}{iconSpacing}{topLeft}passed through");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  // warning
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine($"{warning}{iconSpacing}{topLeft}To improve performance of your application, use the $select parameter.");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{left}More info at https://learn.microsoft.com/graph/query-parameters#select-parameter");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/planner/plans");

  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine($"{warning}{iconSpacing}{topLeft}To improve performance of your application, use the $select parameter.");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{left}More info at https://learn.microsoft.com/graph/query-parameters#select-parameter");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  // intercept
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/joinedTeams?$select=displayName,id,isArchived");
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  // chaos
  Console.ForegroundColor = ConsoleColor.DarkRed;
  Console.WriteLine($"{warning}{iconSpacing}{topLeft}429 Too Many Requests");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  // passed through
  Console.ForegroundColor = ConsoleColor.Gray;
  Console.WriteLine($"{passedThrough}{iconSpacing}{topLeft}passed through");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/joinedTeams?$select=displayName,id,isArchived");

  // intercept
  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine($"{interceptedRequest}{iconSpacing}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  // error
  Console.ForegroundColor = ConsoleColor.Red;
  Console.WriteLine($"{error}{iconSpacing}{topLeft}Calling the same URL before waiting for the Retry-After period.");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{left}Request will be throttled");
  Console.WriteLine($"{noIconSpacing}{iconSpacing}{bottomLeft}GET https://graph.microsoft.com/v1.0/me/todo/lists");

  Console.ForegroundColor = defaultFgColor;
  Console.WriteLine();
  Console.WriteLine();
  Console.WriteLine();
}

void WriteNerdFontSample() {
  Console.WriteLine("Request");
  Console.WriteLine("1 | \uea9b  (ea9b) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \uea70  (ea70) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \ueb6f  (eb6f) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \uf190  (f190) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \uf06e  (f06e) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \uf640  (f640) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \uf707  (f707) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \ufbce  (fbce) GET https://graph.microsoft.com/v1.0/me?$select=id");
  Console.WriteLine("1 | \uf441  (f441) GET https://graph.microsoft.com/v1.0/me?$select=id");

  Console.WriteLine();
  Console.WriteLine("Graph");
  Console.WriteLine("1 | \ueaa1  (eaa1) passed through");
  Console.WriteLine("1 | \ueac3  (eac3) passed through");
  Console.WriteLine("1 | \ueb01  (eb01) passed through");
  Console.WriteLine("1 | \ue760  (e760) passed through");
  Console.WriteLine("1 | \uf0ee  (f0ee) passed through");
  Console.WriteLine("1 | \uf0ac  (f0ac) passed through");
  Console.WriteLine("1 | \ue268  (e268) passed through");
  Console.WriteLine("1 | \uf63e  (f63e) passed through");
  Console.WriteLine("1 | \uf666  (f666) passed through");
  Console.WriteLine("1 | \ufa8f  (fa8f) passed through");
  Console.WriteLine("1 | \ufa9e  (fa9e) passed through");
  Console.WriteLine("1 | \uf40a  (f40a) passed through");
  Console.WriteLine("1 | \uf484  (f484) passed through");
  Console.WriteLine("1 | \ue33c  (e33c) passed through");

  Console.WriteLine();
  Console.WriteLine("Warn");
  Console.WriteLine("1 | \ueaa2  (eaa2) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \ueaf2  (eaf2) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uea6c  (ea6c) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf0f3  (f0f3) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf12a  (f12a) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf071  (f071) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf599  (f599) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf737  (f737) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf421  (f421) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf490  (f490) To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 | \uf41b  (f41b) To improve performance of your application, use the $select parameter.");
  
  Console.WriteLine();
  Console.WriteLine("Tip");
  Console.WriteLine("1 | \uea6b  (ea6b) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uea74  (ea74) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uea61  (ea61) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \ueb42  (eb42) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uf075  (f075) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uf05a  (f05a) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uf0eb  (f0eb) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uf64e  (f64e) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uf67d  (f67d) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \ufbe6  (fbe6) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \ufc72  (fc72) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uf449  (f449) To handle API errors more easily, use the Graph SDK.");
  Console.WriteLine("1 | \uf400  (f400) To handle API errors more easily, use the Graph SDK.");

  Console.WriteLine();
  Console.WriteLine("Chaos");
  Console.WriteLine("1 | \ueaaf  (eaaf) 429 Too Many Requests");
  Console.WriteLine("1 | \uf188  (f188) 429 Too Many Requests");
  Console.WriteLine("1 | \uf0e7  (f0e7) 429 Too Many Requests");
  Console.WriteLine("1 | \uf0c3  (f0c3) 429 Too Many Requests");
  Console.WriteLine("1 | \uf0d0  (f0d0) 429 Too Many Requests");
  Console.WriteLine("1 | \uf567  (f567) 429 Too Many Requests");
  Console.WriteLine("1 | \uf5e3  (f5e3) 429 Too Many Requests");
  Console.WriteLine("1 | \uf46f  (f46f) 429 Too Many Requests");

  Console.WriteLine();
  Console.WriteLine("Error");
  Console.WriteLine("1 | \uea76  (ea76) Calling https://graph.microsoft.com/v1.0/me?$select=id before waiting for the Retry-After period.");
  Console.WriteLine("1 | \uea87  (ea87) Calling https://graph.microsoft.com/v1.0/me?$select=id before waiting for the Retry-After period.");
  Console.WriteLine("1 | \uebde  (ebde) Calling https://graph.microsoft.com/v1.0/me?$select=id before waiting for the Retry-After period.");
  Console.WriteLine("1 | \uf00d  (f00d) Calling https://graph.microsoft.com/v1.0/me?$select=id before waiting for the Retry-After period.");
  Console.WriteLine("1 | \uf65b  (f65b) Calling https://graph.microsoft.com/v1.0/me?$select=id before waiting for the Retry-After period.");
  Console.WriteLine("1 | \uf686  (f686) Calling https://graph.microsoft.com/v1.0/me?$select=id before waiting for the Retry-After period.");

  Console.WriteLine();
  Console.WriteLine("Mocked");
  Console.WriteLine("1 | \uebb6  (ebb6) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uebac  (ebac) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \ueb0b  (eb0b) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \ueb18  (eb18) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uebb0  (ebb0) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \ueb37  (eb37) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uea77  (ea77) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf18e  (f18e) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf050  (f050) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf04e  (f04e) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf021  (f021) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf01e  (f01e) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf064  (f064) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf08b  (f08b) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf641  (f641) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf690  (f690) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf710  (f710) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf910  (f910) 200 OK https://graph.microsoft.com/v1.0/me*");
  Console.WriteLine("1 | \uf942  (f942) 200 OK https://graph.microsoft.com/v1.0/me*");

  Console.WriteLine();
  Console.WriteLine("Multiline");
  Console.WriteLine("1 | \uf071  To improve performance of your application, use the $select parameter.");
  Console.WriteLine("1 |     \ufb0c More info at https://learn.microsoft.com/graph/query-parameters#select-parameter");

  Console.WriteLine();
  Console.WriteLine("Option 1");

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