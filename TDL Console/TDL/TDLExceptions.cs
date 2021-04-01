using System;

namespace TDL
{
    internal static class TDLExceptions
    {
        public static void UnknownCommand()
        {
            Console.WriteLine("Неизвестная команда!");
        }
        public static void CommandEnteredIncorrectly()
        {
            Console.WriteLine("Неправильно введена команда!");
        }
        public static void NonexistentTask()
        {
            Console.WriteLine("Такой задачи не существует!");
        }
    }
}