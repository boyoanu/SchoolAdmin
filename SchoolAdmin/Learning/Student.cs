using SchoolAdmin.Facilities;
using SchoolAdmin.LookUp;
using System;

namespace SchoolAdmin.Learning
{
    public class Student : ILearner
    {
        private readonly int _regNumber;
        private readonly string _fullName;
        private StudentLevel _level;


        public Student(int regNumber, string fullName)
        {
            _regNumber = regNumber;
            _fullName = fullName;
        }


        public int RegNumber
        {
            get => _regNumber;
        }


        public string Name
        {
            get => _fullName;
        }


        public StudentLevel Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
        }


        public void Learn()
        {
            Console.WriteLine("I am learning something interesting now.");
        }


        public void ReceiveNewBookAlert(object source, BookEventArgs args)
        {
            Console.WriteLine($"Sending email to student: \nTitle: {args.Title}, \nAuthor: {args.Author}, \nTime Added: {args.TimeAdded}\n\n");
        }
    }
}
