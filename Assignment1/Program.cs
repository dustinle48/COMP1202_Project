//Le Duc Thinh 101110291
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void ReadFile()
        {
            const string file = @"E:\Study\Sem-4\COMP 1202 - C#\Assignment1\Assignment1\Assignment1\exam.txt.txt";

            var lines = File.ReadLines(file);
            int line_count = File.ReadLines(file).Count();

            char[] answer = File.ReadLines(file).First().ToCharArray();

            string[] student = new string[line_count - 2];
            for (int i = 0; i < line_count - 2; i++)
            {
                student[i] = File.ReadLines(file).Skip(i + 1).First();
            }

            string[] student_id = new string[line_count - 2];
            for (int i = 0; i < line_count - 2; i++)
            {
                student_id[i] = student[i].Substring(0, 4);
            }

            char[][] student_answer = new char[line_count - 2][];
            for (int i = 0; i < line_count - 2; i++)
            {
                student_answer[i] = student[i].Substring(5).ToCharArray();
            }

            string[] student_mark = new string[line_count - 2];
            for (int i = 0; i < line_count - 2; i++)
            {
                int mark = 0;
                for (int n = 0; n < 20; n++)
                {
                    if (student_answer[i][n] == answer[n])
                    {
                        mark += 4;
                    }
                    else if (student_answer[i][n] != answer[n])
                    {
                        mark += -1;
                    }
                    else if (student_answer[i][n] == 'X')
                    {
                        mark += 0;
                    }
                }
                student_mark[i] = mark.ToString();
            }

            string[] num_of_correct_answer = new string[20];
            for (int n = 0; n < 20; n++)
            {
                int num_of_correct = 0;
                for (int i = 0; i < line_count - 2; i++)
                {
                    if (student_answer[i][n] == answer[n])
                    {
                        num_of_correct += 1;
                    }
                }
                num_of_correct_answer[n] = num_of_correct.ToString();
            }

            Display(student_id, student_mark, num_of_correct_answer, line_count);
        }

        static void Display(string[] student_id, string[] student_mark, string[] num_of_correct_answer, int lines_count)
        {
            Console.WriteLine("----------Le Duc Thinh_101110291----------");
            Console.WriteLine();
            Console.WriteLine("Student number\t\tMark");
            for (int i = 0; i < lines_count - 2; i++)
            {
                Console.WriteLine("{0}\t\t\t{1}", student_id[i], student_mark[i]);
            }
            Console.WriteLine();
            Console.WriteLine("The total number of examinations marked: {0}", lines_count - 2);
            Console.WriteLine("Number of correct responses for each question:");
            Console.WriteLine("Question:\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10");
            Console.Write("#correct:" + "\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(num_of_correct_answer[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Question:\t11\t12\t13\t14\t15\t16\t17\t18\t19\t20");
            Console.Write("#correct:" + "\t");
            for (int i = 10; i < 20; i++)
            {
                Console.Write(num_of_correct_answer[i] + "\t");
            }
            Console.WriteLine();
            
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            ReadFile();
        }
    }
}
