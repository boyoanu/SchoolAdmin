using SchoolAdmin.Facilities;
using SchoolAdmin.Learning;
using SchoolAdmin.LookUp;
using System.Collections.Generic;

namespace SchoolAdmin.Teaching
{
    class Supervisor : ITeacher
    {
        // NOTE: Full implementation of this class was deliberately left out as an exercise for the learners
        public int StaffId 
        {
            get;
        }

        public string Name 
        {
            get;
        }

        public SchoolSubject Subject 
        { 
            get; 
            set; 
        }
        public List<ILearner> Learners 
        { 
            get; 
            set; 
        }

        public void Teach()
        {
            
        }

        public void Supervise()
        {

        }

        public void ReceiveNewBookAlert(object source, BookEventArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}
