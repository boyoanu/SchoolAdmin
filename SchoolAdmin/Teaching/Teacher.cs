using SchoolAdmin.Facilities;
using SchoolAdmin.Learning;
using SchoolAdmin.LookUp;
using System;
using System.Collections.Generic;

namespace SchoolAdmin.Teaching
{
    public class Teacher : ITeacher
    {

        private readonly int _staffId;
        private readonly string _fullName;
        private SchoolSubject _subject;
        private List<ILearner> _learners;


        public Teacher(int staffId, string fullName)
        {
            _staffId = staffId;
            _fullName = fullName;
        }


        public int StaffId
        {
            get => _staffId;   
        }


        public string Name
        {
            get => _fullName;
        }


        public SchoolSubject Subject
        {
            // This get accessor uses the explicit syntax, rather than the short form

            get {
                return _subject;
            }


            set {
                _subject = value;
            } 
        }


        public List<ILearner> Learners
        {
            get
            {
                return _learners;
            }

            set {
                _learners = value;
            }
        }

        public void ReceiveNewBookAlert(object source, BookEventArgs args)
        {
            Console.WriteLine($"Sending email to teacher: \nTitle: {args.Title}, \nAuthor: {args.Author}, \nTime Added: {args.TimeAdded}\n\n");
        }

        public void Teach()
        {
            Console.WriteLine("I am teaching a class now.");
        }
    }
}
