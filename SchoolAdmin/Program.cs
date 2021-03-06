using SchoolAdmin.Facilities;
using SchoolAdmin.Learning;
using SchoolAdmin.LookUp;
using SchoolAdmin.Teaching;
using System;
using System.Collections.Generic;
using SchoolAdmin.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data.SqlClient;
using SchoolAdmin.Ado.Net;
using SchoolAdmin.Ado.Net.DTO;

namespace SchoolAdmin
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // instantiate the mongoDbService class
            MongoDbService dbService = new MongoDbService();
            // Instantiate the SqlDataService class
            Ado.Net.SqlDataService sqlDbService = new SqlDataService();
            // Define and insert Teacher objects
            TeacherDTO teacher1 = new TeacherDTO() { FirstName = "Adeleke", MiddleName = "", LastName = "Ayinde", Subject = "Physics" };
            TeacherDTO teacher2 = new TeacherDTO() { FirstName = "Temi", MiddleName = "Temitope", LastName = "Tegbe", Subject = "Philosophy" };
            sqlDbService.Insert("teachers", teacher1);
            sqlDbService.Insert("teachers", teacher2);

            // Define and insert Student objects
            StudentDTO student1 = new StudentDTO() { FirstName = "Newman", MiddleName = "Philip", LastName = "Amadi", Level = "SSS 3" };
            StudentDTO student2 = new StudentDTO() { FirstName = "Habeeb", MiddleName = "", LastName = "Olakitan", Level = "SeniorMan" };
            sqlDbService.Insert("students", student1);
            sqlDbService.Insert("students", student2);

            // Define filter information
            KeyValuePair<string, object> filterPair = new KeyValuePair<string, object>("subject", "Chemistry");

            // Define data for the update
            KeyValuePair<string, object> newData = new KeyValuePair<string, object>("staff_id", 10003);

            // Invoke the Update method to make the change 
            dbService.Update("teachers", filterPair, "=", newData);

            // Invoke the Delete method to make the change 
            dbService.Delete("teachers", filterPair, "=");

            // Query the database for all teachers
            Console.WriteLine("The available teachers are: ");
            var teachers = dbService.FetchAll("teachers");
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }

            //dbService.TestConnection();

            // Create a teacher documents and insert it in the collection
            BsonDocument teacherDoc1 = new BsonDocument()
            {
                {"staff_id",1001 },{"name","Chief Adeleke Ayinde" },{"subject","Mathematics" }

            };

            BsonDocument teacherDoc2 = new BsonDocument()
            {
               {"staff_id",1002 }, {"name","High Chief Bayowa Odometa" },{"subject","Physics" }

            };

            BsonDocument teacherDoc3 = new BsonDocument()
            {
                {"staff_id",1003 }, {"name","Ambassador Temi Tegbe" },{"subject","Philosophy" }
            };

            //dbService.Insert("teachers", teacherDoc1);
            //dbService.Insert("teachers", teacherDoc2);
            //dbService.Insert("teachers", teacherDoc3);
           
            //Create a students document ansd insert it in the collection
            BsonDocument studentsDoc = new BsonDocument()
            {
                {"reg_number",50001},{"full_name", "Tunde Badmus" }, {"leve", "JSS 1" }

            };
            BsonDocument studentsDoc2 = new BsonDocument()
            {
                { "reg_number",50002},{ "full_name", "Obi Cubana" },{ "leve", "JSS 2" }

            };

            //dbService.Insert("students", studentsDoc1);
            //dbService.Insert("students", studentsDoc2);


            Console.WriteLine("The Available Student are:");
            var students = dbService.FetchAll("students");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            string ConString = @"Data Source=DESKTOP-P4C2M1N\SQLEXPRESS;Initial Catalog=SchoolAdminDB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConString);
            string querystring = "Select * from Studentss";
            con.Open();
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            }







            //Console.WriteLine(dbService.FetchAll("teachers"));


            // Create a teacher instance
            //ITeacher firstTeacher = new Teacher(101, "Tunde Badmus");

            // Create a subject instance based on the struct
            //SchoolSubject mySubject = new SchoolSubject
            //{
            //    Code = 101,
            //    Title = "Mathematics",
            //    Category = "General"
            //};

            // Assign the subject to the teacher
            //firstTeacher.Subject = mySubject;


            // Create a generic list of type ILearner
            //List<ILearner> studentList = new List<ILearner>();

            // Create a number of Student instances
            //ILearner firstStudent = new Student(1001, "Betty Turner");
            //firstStudent.Level = StudentLevel.JSS1;


            // Create an instance of the LibraryCatalog class
            //LibraryCatalog catalog = new LibraryCatalog();

            // Subscribe the teacher and student to the BookAdded event
            //catalog.BookAdded += firstTeacher.ReceiveNewBookAlert;
            //catalog.BookAdded += firstStudent.ReceiveNewBookAlert;

            // Add a book to the catalog
            //catalog.AddBook(new Book() { Title = "Things Fall Apart", Author = "Chinua Achebe" });
            //catalog.AddBook(new Book() { Title = "The Pilgrim’s Progress", Author = "John Bunyan" });
            //catalog.AddBook(new Book() { Title = "Robinson Crusoe ", Author = "Daniel Defoe" });
            //catalog.AddBook(new Book() { Title = "Gulliver’s Travels ", Author = "Jonathan Swift" });
            //catalog.AddBook(new Book() { Title = " Clarissa", Author = " Samuel Richardson" });
            //catalog.AddBook(new Book() { Title = "Tom Jones ", Author = "Henry Fielding" });
            //catalog.AddBook(new Book() { Title = " No longer at ease ", Author = "Chinua Achebe" });
            //catalog.AddBook(new Book() { Title = "The Education", Author = "Chinua Achebe" });
            //catalog.AddBook(new Book() { Title = "The trial of Brother Jero", Author = "Wole Soyinka" });
            //catalog.AddBook(new Book() { Title = "The interpreters", Author = "Wole Soyinka" });


            // bookQueries.GetBooksSortedByTitle1();
            // bookQueries.GetBooksSortedByTitle2();

            // bookQueries.GetBooksSortedByTitleAuthor1();
            // bookQueries.GetBooksSortedByTitleAuthor2();

            //  bookQueries.GetBooksWrittenByAuthor1();
            //   bookQueries.GetBooksWrittenByAuthor2();

            //bookQueries.GetBooksByTitleAuthorStrToUpper1();
            //bookQueries.GetBooksByTitleAuthorStrToUpper2();

            //bookQueries.BookCountExpression1();




            //ILearner secondStudent = new Student(1002, "Alison Wood");
            //secondStudent.Level = StudentLevel.JSS2;

            //ILearner thirdStudent = new Student(1003, "Carl John");
            //thirdStudent.Level = StudentLevel.SSS1;

            //// Store the student instances in the list
            //studentList.Add(firstStudent);
            //studentList.Add(secondStudent);
            //studentList.Add(thirdStudent);

            //// NOTE: The objects can also be added using AddRange as follows:
            //// studentList.AddRange(new List<Student> { firstStudent, secondStudent, thirdStudent });

            //// Now, assign the list of students to the teacher's Learners property
            //firstTeacher.Learners = studentList;

            //// Display the teacher's subject title and code
            //Console.WriteLine($"{firstTeacher.Name} teaches {firstTeacher.Subject.Title} with code {firstTeacher.Subject.Code}");

            //// Display the number of learners assigned to the teacher
            //Console.WriteLine($"The number of learners assigned to {firstTeacher.Name} is {firstTeacher.Learners.Count}");

            //foreach (Student student in firstTeacher.Learners)
            //{
            //    Console.WriteLine($"Name: {student.Name} \t\tLevel:{student.Level}");
            //}

            //// Check if teacher's learners include a newly created student named "Carl John"
            //Student searchStudent = new Student(1003, "Carl John");
            //searchStudent.Level = StudentLevel.SSS1;
            //bool isAssignedStudent = firstTeacher.Learners.Contains(searchStudent);
            //Console.WriteLine($"The search for Carl John returned: {isAssignedStudent}");

            //// Check if teacher's learners include the original student named "Carl John"
            //isAssignedStudent = firstTeacher.Learners.Contains(thirdStudent);
            //Console.WriteLine($"The search for Carl John returned: {isAssignedStudent}");

            //// Exploring KeyValuePair<TKey, TValue> type
            //KeyValuePair<int, ILearner> student1, student2, student3;
            //student1 = new KeyValuePair<int, ILearner>(5, firstStudent);
            //student2 = new KeyValuePair<int, ILearner>(7, secondStudent);
            //student3 = new KeyValuePair<int, ILearner>(10, thirdStudent);

            //// Exploring Dictionary<TKey, TValue> type
            //Dictionary<int, ILearner> studentDictionary;
            //studentDictionary = new Dictionary<int, ILearner>();
            //studentDictionary.Add(5, firstStudent);
            //studentDictionary.Add(7, secondStudent);
            //studentDictionary.Add(10, thirdStudent);

            //foreach(KeyValuePair<int, ILearner> kvp in studentDictionary)
            //{
            //    Console.WriteLine($"Key is {kvp.Key} \t Value is {kvp.Value.Name}");
            //}

        }
    }
}
