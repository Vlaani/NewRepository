using System;
using System.Collections.Generic;

namespace TDL
{
    class Program
    {

        public static List<Task> TasksList = new List<Task>();
        public static AppData TDL_Data = new AppData();

        static void Main(string[] args)
        {

            TasksList = TDL_Data.Load();
            Console.Write("Список доступных команд:\n /Show - просмотр задач\n /Add [Приоритет:(High/Normal/Low)] [Задача] - добавить задачу\n /Remove [№ задачи] - удалить задачу\n /Edit [№ задачи] - изменить задачу\n\n");
            _ = new EventListener(Console.ReadLine());
        }
    }
    class EventListener
    {
        public EventListener(string text)
        {
            string Command = CommandManager.MakeCommand(text);
            string Task = CommandManager.DeleteCommand(text);
            switch (Command.ToLower())
            {
                case "/add":
                    TaskManager.AddTask(Task);
                    TaskManager.EvtListener();
                    break;
                case "/remove":
                    TaskManager.RemoveTask(Task);
                    TaskManager.EvtListener();
                    break;
                case "/edit":
                    TaskManager.EditTask(Task);
                    TaskManager.EvtListener();
                    break;
                case "/show":
                    TaskManager.ShowTasks();
                    TaskManager.EvtListener();
                    break;
                default:
                    TDLExceptions.UnknownCommand();
                    TaskManager.EvtListener();
                    break;
            }
        }
    }
}