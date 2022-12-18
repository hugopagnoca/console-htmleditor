using System.Text;

namespace HtmlEditor
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            System.Console.WriteLine("MODO EDITOR");
            System.Console.WriteLine("-----------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            System.Console.WriteLine("-----------");
            System.Console.WriteLine("  Deseja salvar o arquivo? (S/N): ");
            Viewer.Show(file.ToString());

            var save = System.Console.ReadLine().ToUpper();

            if (save == "S")
            {
                Save(file);
            }
            else Menu.Show();
        }

        public static void Save(StringBuilder file)
        {
            Console.Clear();
            System.Console.WriteLine(" Selecione onde gostaria de salvar o arquivo:");
            var path = Console.ReadLine();

            using (var salvar = new StreamWriter(path))
            {
                salvar.Write(file);
            }
            System.Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            System.Console.WriteLine();
            System.Console.WriteLine("Pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Menu.Show();
        }
    }
}