using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task6
{
    internal class Program
    {
        const string fileName = "StaffList.txt";

        static void ShowRecordsForThePeriod()
        {
            List<string> staffList = new List<string>(File.ReadAllLines(fileName));
            Repozitory repozitory = new Repozitory();
            repozitory.employee = new Employee[staffList.Count];
            int iteration = 0;
            while (iteration < staffList.Count)// Цикл записи данных из файла в структуру Repozitory 
            {
                StringBuilder worker = new StringBuilder(staffList[iteration]);
                repozitory.employee[iteration] = new Employee();
                int ij = 0;
                repozitory.employee[iteration].Id = worker[0];
                string c = String.Empty;
                while (worker[ij] != '#')
                {
                    c += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Id = Convert.ToUInt32(c);
                ij++;
                string x = String.Empty;
                while (worker[ij] != '#')
                {
                    x += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Date = Convert.ToDateTime(x);
                ij++;
                while (worker[ij] != '#')
                {
                    repozitory.employee[iteration].Name += worker[ij].ToString();
                    ij++;
                }
                ij++;
                string y = String.Empty;
                while (worker[ij] != '#')
                {
                    y += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Age = Convert.ToByte(y);
                ij++;
                string z = String.Empty;
                while (worker[ij] != '#')
                {
                    z += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Height = Convert.ToByte(z);
                ij++;
                while (worker[ij] != '#')
                {
                    repozitory.employee[iteration].Birthday += worker[ij].ToString();
                    ij++;
                }
                ij++;
                while (ij < worker.Length)
                {
                    repozitory.employee[iteration].Birthplace += worker[ij].ToString();
                    ij++;
                }
                iteration++;
            }

            Console.WriteLine("Укажите начальную дату периода для просмотра записей " +
                "в формате ДД.ММ.ГГГГ ЧЧ:ММ");
            DateTime firstDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Укажите конечную дату периода для просмотра записей " +
                    "в формате ДД.ММ.ГГГГ ЧЧ:ММ");
            DateTime secondDate = Convert.ToDateTime(Console.ReadLine());
            for (int it = 0; it < staffList.Count; it++)
            {
                if (repozitory.employee[it].Date > firstDate & repozitory.employee[it].Date < secondDate)
                {
                    Console.WriteLine(repozitory.employee[it].Print());
                }
                else
                    continue;
            }
        }
        static void SortByDate()
        {
            List<string> staffList = new List<string>(File.ReadAllLines(fileName));
            Repozitory repozitory = new Repozitory();
            repozitory.employee = new Employee[staffList.Count];
            int iteration = 0;
            while (iteration < staffList.Count)
            {
                StringBuilder worker = new StringBuilder(staffList[iteration]);
                repozitory.employee[iteration] = new Employee();
                int ij = 0;
                repozitory.employee[iteration].Id = worker[0];
                string c = String.Empty;
                while (worker[ij] != '#')
                {
                    c += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Id = Convert.ToUInt32(c);
                ij++;
                string x = String.Empty;
                while (worker[ij] != '#')
                {
                    x += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Date = Convert.ToDateTime(x);
                ij++;
                while (worker[ij] != '#')
                {
                    repozitory.employee[iteration].Name += worker[ij].ToString();
                    ij++;
                }
                ij++;
                string y = String.Empty;
                while (worker[ij] != '#')
                {
                    y += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Age = Convert.ToByte(y);
                ij++;
                string z = String.Empty;
                while (worker[ij] != '#')
                {
                    z += worker[ij].ToString();
                    ij++;
                }
                repozitory.employee[iteration].Height = Convert.ToByte(z);
                ij++;

                while (worker[ij] != '#')
                {
                    repozitory.employee[iteration].Birthday += worker[ij].ToString();
                    ij++;
                }

                ij++;
                while (ij < worker.Length)
                {
                    repozitory.employee[iteration].Birthplace += worker[ij].ToString();
                    ij++;
                }
                iteration++;
            }

            Console.WriteLine($"\nДля сортировки записей от старых к новым нажмите 1" +
                "\nДля сортировки записей от новых к старым нажмите 2");
            char key4 = Console.ReadKey(true).KeyChar;
            switch (key4)
            {
                case '1':
                    repozitory.SortingInAscedingOrder();
                    Console.WriteLine("Список отсортирован");
                    break;
                case '2':
                    repozitory.SortingByDescedingOrder();
                    Console.WriteLine("Список отсортирован");
                    break;
            }

            using (StreamWriter sw1 = new StreamWriter(fileName, false))
            {
                for (int ik = 0; ik < staffList.Count; ik++)
                {
                    sw1.WriteLine(repozitory.employee[ik].Print());
                }
            }


        }

        static void WorkingWithRecord()
        {
            Console.WriteLine("Введите ID сотрудника");
            string inputId = Console.ReadLine();
            string id = null;
            StringBuilder line = new StringBuilder();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (inputId != id)
                {
                    line = new StringBuilder((reader.ReadLine()));
                    id = Convert.ToString(line[0]);
                }
            }
            List<string> lines = new List<string>(File.ReadAllLines(fileName));
            int index = lines.IndexOf(line.ToString());
            Console.WriteLine(line.ToString().Replace('#', ' '));
            string inputResult = null;
            Console.WriteLine($"\nЕсли желаете изменить данные о сотруднике нажмите 1" +
               "\nЕсли хотите удалить сотрудника из списка нажмите 2");
            char key2 = Console.ReadKey(true).KeyChar;
            switch (key2)
            {
                case '1':
                    string date = String.Empty;
                    string name = String.Empty;
                    string age = String.Empty;
                    string height = String.Empty;
                    string birthday = String.Empty;
                    string birthplace = String.Empty;

                    int i = 2;
                    while (line[i] != '#')
                    {
                        date += line[i].ToString();
                        i++;
                    }
                    i++;
                    while (line[i] != '#')
                    {
                        name += line[i].ToString();
                        i++;
                    }
                    i++;
                    while (line[i] != '#')
                    {
                        age += line[i].ToString();
                        i++;
                    }
                    i++;
                    while (line[i] != '#')
                    {
                        height += line[i].ToString();
                        i++;
                    }
                    i++;
                    while (line[i] != '#')
                    {
                        birthday += line[i].ToString();
                        i++;
                    }
                    i++;
                    while (i < line.Length)
                    {
                        birthplace += line[i].ToString();
                        i++;
                    }
                    Console.WriteLine($"Какие данные вы хотите изменить?" +
                        $"\n 1 - ФИО \n 2 - Возраст \n 3 - Рост \n 4 - Дату рождения \n 5 - Место рождения ");
                    char key3 = Console.ReadKey(true).KeyChar;
                    switch (key3)
                    {
                        case '1':
                            Console.WriteLine("Введите новые данные");
                            name = Console.ReadLine();
                            break;
                        case '2':
                            Console.WriteLine("Введите новые данные");
                            age = Console.ReadLine();
                            break;
                        case '3':
                            Console.WriteLine("Введите новые данные");
                            height = Console.ReadLine();
                            break;
                        case '4':
                            Console.WriteLine("Введите новые данные");
                            birthday = Console.ReadLine();
                            break;
                        case '5':
                            Console.WriteLine("Введите новые данные");
                            birthplace = Console.ReadLine();
                            break;
                    }
                    inputResult = id + "#" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
                        + "#" + name + "#" + age
                        + "#" + height + "#" + birthday + "#" + birthplace;
                    lines.Insert(index, inputResult);
                    lines.RemoveAt(index + 1);
                    Console.WriteLine("Данные успешно изменены");
                    break;

                case '2':
                    lines.RemoveAt(index);
                    Console.WriteLine($"Сотрудник №{id} удален из списка");
                    break;
            }
            File.WriteAllLines(fileName, lines);
        }

        static void ReadFile()
        {
            string lines = null;
            if (File.Exists(fileName))
            {
                lines = File.ReadAllText(fileName);
                Console.WriteLine(lines.Replace('#', ' '));
            }
            else
                Console.WriteLine("Файл не существует, перезапустите программу и выберите 1 или создайте файл вручную");
        }

        static void AddStaff()
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                char key2 = 'д';

                while (Char.ToLower(key2) == 'д')
                {
                    string note = string.Empty;
                    Console.WriteLine($"\nВведите ID сотрудника");
                    note += $"{Console.ReadLine()}" + "#";

                    string now = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();// Для записи времени без учета секунд, согласно заданию
                    note += $"{now}" + "#";

                    Console.WriteLine("Введите ФИО сотрудника");
                    note += $"{Console.ReadLine()}" + "#";

                    Console.WriteLine("Введите возраст сотрудника");
                    note += $"{Console.ReadLine()}" + "#";

                    Console.WriteLine("Введите рост сотрудника");
                    note += $"{Console.ReadLine()}" + "#";

                    Console.WriteLine("Введите дату рождения сотрудника");
                    note += $"{Console.ReadLine()}" + "#";

                    Console.WriteLine("Введите место рождения сотрудника");
                    note += $"{Console.ReadLine()}";

                    sw.WriteLine(note);
                    Console.Write("Добавить ещё одного сотрудника? н/д");
                    key2 = Console.ReadKey(true).KeyChar;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Приветсвую, что вы хотите сделать? \n1 - добавить новых сотрудников, " +
                "\n2 - посмотреть/изменить/удалить данные о сотруднике \n3 - сортировать записи по дате " +
                "\n4 - показать записи за указанный период \n5 - показать все записи");
            char key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    AddStaff();
                    break;
                case '2':
                    WorkingWithRecord();
                    break;
                case '3':
                    SortByDate();
                    break;
                case '4':
                    ShowRecordsForThePeriod();
                    break;
                case '5':
                    ReadFile();
                    break;
                default:
                    Console.WriteLine("Вы нажали клавишу, отличную от 1,2,3,4,5. Перезапустите приложение.");
                    break;
            }
            Console.ReadKey();
        }
    }
}



