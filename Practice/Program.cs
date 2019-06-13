using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PracticeLib;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoubleLinkedList();
            list.Add("Serg", 4.7, true);
            list.Add("Mark", 3, false);
            list.Add("Maria", 5, false);
            list.Add("Karl", 4.9, true);
            list.Add("Lisa", 5, true);

            //var list2 = new DoubleLinkedList();


            //list2 = list1.NewList();

            //list1.SeeAll();

            //var NewList = list1.NewList();
            //NewList.SeeAll();

            //var SearchList = new DoubleLinkedList();
            //SearchList = list1.Search();
            //SearchList.SeeAll();
            //Console.WriteLine("{0}", list1.Length);

            //var s = new DoubleLinkedList(SearchList);


            while (true)
            {
                Console.Clear();
                Help();

                ShowAll(list);

                Console.Write(">");
                switch (Console.ReadLine())
                {
                    case "quit":
                        return;
                    case "add":
                        try
                        {
                            var index = InputIndex();
                            var s = InputStudent();
                            if (s != null)
                                list.Add(index, s.name, s.averageMark, s.dancing);
                            ShowAll(list);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Try again");
                        }
                        break;

                    case "addl":
                        {
                            var s = InputStudent();
                            if (s != null)
                                list.Add(s.name, s.averageMark, s.dancing);
                            ShowAll(list);
                            break;
                        }
                    case "addf":
                        {
                            var s = InputStudent();
                            if (s != null)
                                list.AddFirst(s.name, s.averageMark, s.dancing);
                            ShowAll(list);
                            break;
                        }
                    case "del":
                        {
                            try
                            {
                                var index = InputIndex();
                                list.Del(index);
                                ShowAll(list);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Try again");
                            }
                            break;
                        }
                    case "getNewList":
                        var newL = new DoubleLinkedList();
                        newL = list.NewList();
                        Console.WriteLine("New list is:");
                        ShowAll(newL);
                        break;
                    case "getNode":
                        try
                        {
                            var index = InputIndex();
                            Console.WriteLine("{0}", list[index]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Try again");
                        }
                        break;
                    case "search":
                        try
                        {
                            var newL2 = new DoubleLinkedList();
                            newL2 = list.Search();
                            ShowAll(newL2);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Try again");
                        }
                        break;
                    case "":
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                Console.WriteLine();

                Console.WriteLine("Press any key o continue...");
                Console.ReadKey(false);
            }
        }

        private static int InputIndex()
        {
            Console.Write(">");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static Element InputStudent()
        {
            try
            {
                Console.Write(">");
                var name = Console.ReadLine();
                Console.Write(">");
                var average = Convert.ToDouble(Console.ReadLine());
                Console.Write(">");
                var dancing = Convert.ToBoolean(Console.ReadLine());
                return new Element(name, average, dancing);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again");
            }
            return null;
        }

        public static void ShowAll(DoubleLinkedList list)
        {
            var i = 0;
            Console.WriteLine();
            Console.WriteLine("{3} \t {0,-20} {1,5} \t {2,10}\n", "Name", "Average mark", "Dancing", "Index");
            foreach (Element item in list)
                Console.WriteLine("{3} \t {0,-20} {1,5}\t {2,17:N1}", item.name, item.averageMark, item.dancing, i++);
            Console.WriteLine();
        }

        private static void Help()
        {
            Console.WriteLine("To add element to the first position of the list write 'addf' and enter");
            Console.WriteLine("name, average mark and true (if student is practicing dancing)/false(if he is not).");

            Console.WriteLine("To add element to the specified position of the list write 'add' and enter index,");
            Console.WriteLine("name, average mark and true (if student is practicing dancing)/false(if he is not).");

            Console.WriteLine("To add element to the list write 'addl' and enter name, average mark ");
            Console.WriteLine("and true (if student is practicing dancing)/false(if he is not).");

            Console.WriteLine("To delete element of the specified position write 'del' and enter index.");

            Console.WriteLine("To get new list out of current one enter'getNewList'.");

            Console.WriteLine("To get information about node enter 'getNode' and enter it index");
            Console.WriteLine("Enter 'search' to see all students with average mark 5 who are practicing dancing.");

        }
    }
}
