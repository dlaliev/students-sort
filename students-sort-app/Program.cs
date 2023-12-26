using System;
using System.Collections.Generic;
using System.Text;

namespace students_sort_app
{
    public class Student : IComparable<Student>
    {
        public enum EducationStage
        {
            младшая,
            средняя,
            старшая
        }

        private static char nextName = 'A';

        public string FIO { get; private set; }
        public int Grade { get; private set; }
        public double Performance { get; private set; }
        public EducationStage Stage { get; private set; }

        public Student()
        {
            FIO = nextName.ToString();
            nextName++;
            Grade = new Random().Next(1, 12);
            Performance = Math.Round(new Random().NextDouble() * 5, 1);
            SetEducationStage();
        }

        public Student(string fio, int grade, double performance)
        {
            FIO = fio;
            Grade = grade;
            Performance = performance;
            SetEducationStage();
        }

        public void Pass()
        {
            if (Grade < 11)
            {
                Grade++;
                SetEducationStage();
            }
        }

        public override string ToString()
        {
            return $"{FIO}, {Stage.ToString()} школа, {Grade} класс, {Performance} балла";
        }

        private void SetEducationStage()
        {
            if (Grade >= 1 && Grade <= 4)
                Stage = EducationStage.младшая;
            else if (Grade >= 5 && Grade <= 8)
                Stage = EducationStage.средняя;
            else
                Stage = EducationStage.старшая;
        }

        public int CompareTo(Student other)
        {
          
            int stageComparison = Stage.CompareTo(other.Stage);
            if (stageComparison != 0)
                return stageComparison;

           
            int gradeComparison = other.Grade.CompareTo(Grade);
            if (gradeComparison != 0)
                return gradeComparison;

          
            return string.Compare(FIO, other.FIO, StringComparison.Ordinal);
        }
    }

    class School
    {
        public string Name { get; private set; }
        public List<Student> ListStudents { get; private set; }

        public School(string name)
        {
            Name = name;
            ListStudents = new List<Student>();
        }

        public void Add(Student student)
        {
            ListStudents.Add(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < ListStudents.Count; i++)
            {
                result.AppendLine($"{i + 1}. {ListStudents[i]}");
            }
            return result.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student studA = new Student();
            Student studB = new Student();
            Student studBagaev = new Student("Багаев Аслан", 4, 4);
            Student studAbaev = new Student("Абаев Георгий", 4, 3.4);
            Student studAtaev = new Student("Атаев Сослан", 4, 3);

            School school = new School("ФизМат");
            school.Add(studB);
            school.Add(studBagaev);
            school.Add(studAbaev);
            school.Add(studA);
            school.Add(studAtaev);


            Console.WriteLine(school);

        }
    }
}
