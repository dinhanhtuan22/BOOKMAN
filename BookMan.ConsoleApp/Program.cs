using System;
using System.Text;

namespace BookMan.ConsoleApp
{
    using Framework;
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var text = Config.Instance.PromptText;
            var color = Config.Instance.PromptColor;

            ConfigRouter();

            while (true)
            {
                ViewHelp.Write(text, color);
                string request = Console.ReadLine();
                try
                {
                    Router.Instance.Forward(request);
                }
                catch (Exception e)
                {

                    ViewHelp.WriteLine(e.Message, ConsoleColor.Red);
                }
                finally
                {
                    Console.WriteLine();
                }
            }

            #region version cũ
            //while(true)
            //{
            //    Console.Write("Request> ");
            //    string request = Console.ReadLine();

            //    switch (request.ToLower())
            //    {
            //        case "single":
            //            controller.Single(1);
            //            break;
            //        case "create":
            //            controller.Create();
            //            break;
            //        case "update":
            //            controller.Update(1);
            //            break;
            //        case "list":
            //            controller.List();
            //            break;
            //        default:
            //            Console.WriteLine("Unknown command");
            //            break;
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Hiển thị gợi ý sử dụng router
        /// </summary>
        /// <param name="parameter"></param>
        private static void Help(Parameter parameter)
        {
            if (parameter == null)
            {
                ViewHelp.WriteLine("SUPPORTER COMMANDS:", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("type: help ? cmd <command> to get command details", ConsoleColor.Cyan);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }

        /// <summary>
        /// Hiển thị thông tin phần mềm
        /// </summary>
        /// <param name="parameter"></param>
        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MANAGER version 1.0", ConsoleColor.Green);
            ViewHelp.WriteLine("by tuanda", ConsoleColor.Magenta);
        }
    }
}
