using Lab6;

Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.UTF8;

Menu menu = new();
NumberAnalyzer fibonachi = new FibonachiAnalyzer(), depth = new DepthAnalyzer(), divisibility = new DivisibilityAnalyzer();
menu.OnDataReceived += fibonachi.Analyze;
menu.OnDataReceived += depth.Analyze;
menu.OnDataReceived += divisibility.Analyze;
menu.Input();