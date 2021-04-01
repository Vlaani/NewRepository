using System;

namespace TDL
{
    internal static class TaskManager
    { 
        public static void AddTask(string task)
        {
            if (task == "")
            {
                TDLExceptions.CommandEnteredIncorrectly(); 
                return;
            }
            Console.WriteLine("Задача успешно добавлена!");
            if (task.IndexOf(' ') < 0)
            {
                Program.TasksList.Add(new Task(task, "normal"));
                Program.TDL_Data.Save(Program.TasksList);
            }
            else
            {
                string TaskContent = task.Remove(0, task.IndexOf(' ') + 1);
                switch (task.Remove(task.IndexOf(' ')).ToLower())
                {
                    case "high":
                        Program.TasksList.Insert(0, new Task("! " + TaskContent + " !", "high"));
                        Program.TDL_Data.Save(Program.TasksList);
                        break;
                    case "normal":
                        for (int i = 0; i < Program.TasksList.Count; i++)
                        {
                            if (Program.TasksList[i].Priority == "low")
                            {
                                Program.TasksList.Insert(i - 1, new Task(TaskContent, "normal"));
                                return;
                            }
                        }
                        Program.TasksList.Add(new Task(TaskContent, "normal"));
                        Program.TDL_Data.Save(Program.TasksList);
                        break;
                    case "low":
                        Program.TasksList.Add(new Task("_ " + TaskContent + " _", "low"));
                        break;
                    default:
                        Program.TasksList.Add(new Task(task));
                        Program.TDL_Data.Save(Program.TasksList);
                        break;
                }
            }
        }
        public static void RemoveTask(string NumOfTask)
        {
            if (!int.TryParse(NumOfTask, out _))
            {
                TDLExceptions.CommandEnteredIncorrectly();
                return;
            }
            if (Program.TasksList.Count >= Math.Abs(Convert.ToInt32(NumOfTask)))
            {
                Program.TasksList.RemoveAt(Convert.ToInt32(NumOfTask) - 1);
                Program.TDL_Data.Save(Program.TasksList);
            }
            else
            {
                TDLExceptions.NonexistentTask();
            }
        }
        public static void EditTask(string NumOfTask)
        {
            if (!int.TryParse(NumOfTask, out _))
            {
                TDLExceptions.CommandEnteredIncorrectly();
                return;
            }
            if (Program.TasksList.Count >= Math.Abs(Convert.ToInt32(NumOfTask)))
            {
                Console.WriteLine("Впишите новую задачу:");
                Program.TasksList[Convert.ToInt32(NumOfTask) - 1].Text = Console.ReadLine();
                Program.TDL_Data.Save(Program.TasksList);
            }
            else 
            {
                TDLExceptions.NonexistentTask();
            }
        }
        public static void EvtListener()
        {
            EventListener _EventListener = new EventListener(Console.ReadLine());
        }
        public static void ShowTasks()
        {
            Console.WriteLine("\nЗадачи:");
            for (int i = 0; i<Program.TasksList.Count;i++)
            {
                Console.WriteLine(" " + (i + 1) + ")" + Program.TasksList[i].Text+ Program.TasksList[i].Date);
            }
        }
    }
}