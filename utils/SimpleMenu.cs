#region imports
using static System.Console;

#endregion

/*  Usefull links

(Console.)
 ReadKey = https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey?view=net-6.0
 Key = https://docs.microsoft.com/en-us/dotnet/api/system.consolekey?view=net-6.0
 
 
 */


namespace rauwers.dev
{
  class SimpleMenu
  {
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;
    private Dictionary<string, bool> Settings;


    public SimpleMenu(string prompt, string[] options,
    bool widthAligned = true)
    {
      Settings = new Dictionary<string, bool>();
      Settings.Add("widthAligned", widthAligned);

      Prompt = prompt;
      Options = options;
      SelectedIndex = 0;
    }

    private void DisplayOptions()
    {
      WriteLine(Prompt);
      for (int i = 0; i < Options.Length; i++)
      {
        string currentOption = Options[i];
        string prefix = " ";
        if (currentOption == null)
        {
          WriteLine();
          continue;
        }
        ForegroundColor = ConsoleColor.White;
        BackgroundColor = ConsoleColor.Black;

        if (i == SelectedIndex)
        {
          prefix = " ";
          ForegroundColor = ConsoleColor.Black;
          BackgroundColor = ConsoleColor.White;
        }
        WriteLine($"{prefix} << {currentOption}  ");
      }
      ResetColor();
    }

    public string ReadAtPoss(int y, int x, bool empty = false)
    {
      Console.CursorVisible = true;
      Console.SetCursorPosition(y, x);
      if (empty)
        Console.Write("                                                            ");
      Console.SetCursorPosition(y, x);
      return Console.ReadLine()!;
    }
    public int Run(Action a, int index = 0)
    {
      ConsoleKey keyPressed;
      SelectedIndex = index;
      do
      {
        Clear();
        DisplayOptions();
        a();

        ConsoleKeyInfo keyInfo = ReadKey(true);
        keyPressed = keyInfo.Key;

        if (keyPressed == ConsoleKey.UpArrow)
        {
          do
          {
            SelectedIndex--;
            SelectedIndex = SelectedIndex % Options.Length;
            if (SelectedIndex < 0) SelectedIndex += Options.Length;
          } while (Options[SelectedIndex] == null);
        }
        else if (keyPressed == ConsoleKey.DownArrow)
        {
          do
          {
            SelectedIndex++;
            SelectedIndex = SelectedIndex % Options.Length;
          } while (Options[SelectedIndex] == null);
        }

      } while (keyPressed != ConsoleKey.Enter);

      return SelectedIndex;
    }
  }
}