using System.Text.RegularExpressions;

namespace HtmlEditor
{
    public class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            System.Console.WriteLine("MODO VISUALIZAÇÃO");
            System.Console.WriteLine("---------------");
            Replace(text);
            Console.ReadKey();
            Menu.Show();
        }

        public static void Replace(string text)
        {
            var tag = new Regex("<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>");
            var words = text.Split(' ');
            for (var i = 0; i < words.Length; i++)
            {
                if (tag.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            ((words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>'))
                        )
                    );
                    System.Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.Write(words[i]);
                    System.Console.Write(" ");
                }
            }
        }
    }
}