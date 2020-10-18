using ConsoleApp13.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public static class MidtermHelper
    {
        public static List<(int StudentId, int SubjectId, int Point)> ReadFile()
        {
            var path = @"C:\Users\Niko_N\source\repos\ConsoleApp13\ConsoleApp13\data.csv";
            var result = new List<(int StudentId, int SubjectId, int Grade)>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    result.Add((int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2])));
                }
            }
            return result;
        }

        public static void Import()
        {
            using (var context = new MidtermContext())
            {
                var students = context.Set<Student>().ToList();
                var subjects = context.Set<Subject>().ToList();
                var data = ReadFile();
                var imported = 0;
                var notImported = 0;

                foreach (var (StudentId, SubjectId, Point) in data)
                {
                    if (students.Any(s => s.Id == StudentId) && subjects.Any(s => s.Id == SubjectId))
                    {
                        context.Set<StudentSubject>().Add(new StudentSubject { StudentId = StudentId, SubjectId = SubjectId, Point = Point });
                        imported++;
                    }
                    else
                    {
                        notImported++;
                    }
                }

                context.SaveChanges();

                Console.WriteLine($"Successfully imported {imported} records");
                Console.WriteLine($"Failed to import {notImported} records");
            }

        }
    }
}
