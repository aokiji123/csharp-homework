internal class Student : IComparable<Student>
{
	private string firstName;
	private string secondName;
	private string thirdName;
	private DateTime birthDay;
	private Address address;
    private string phoneNumber;
    private int[] homeworkGrades;
    private int[] projectGrades;
    private int[] examGrades;

    public Student
        (string firstName, string secondName, string thirdName, DateTime birthDay, Address address,
        string phoneNumber, int[] homeworkGrades, int[] projectGrades, int[] examGrades)
    {
        this.firstName = firstName;
        this.secondName = secondName;
        this.thirdName = thirdName;
        this.birthDay = birthDay;
        this.address = address;
        this.phoneNumber = phoneNumber;
        this.homeworkGrades = homeworkGrades;
        this.projectGrades = projectGrades;
        this.examGrades = examGrades;
    }

    public Student(string firstName, string secondName, string thirdName, DateTime dateOfBirth, Address homeAddress, string phoneNumber)
        : this(firstName, secondName, thirdName, dateOfBirth, homeAddress, phoneNumber, null, null, null) {}

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string SecondName
    {
        get { return secondName; }
        set { secondName = value; }
    }

    public string ThirdName
    {
        get { return thirdName; }
        set { thirdName = value; }
    }

    public DateTime BirthDay
    {
        get { return birthDay; }
        set { birthDay = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    public int[] HomeworkGrades
    {
        get { return homeworkGrades; }
        set { homeworkGrades = value; }
    }

    public int[] ProjectGrades
    {
        get { return projectGrades; }
        set { projectGrades = value; }
    }

    public int[] ExamGrades
    {
        get { return examGrades; }
        set { examGrades = value; }
    }

    public void DisplayStudentInfo()
    {
        Console.WriteLine("Student Information:");
        Console.WriteLine($"Full Name: {FirstName} {SecondName} {ThirdName}");
        Console.WriteLine($"Date of Birth: {BirthDay.ToShortDateString()}");
        Console.WriteLine($"Home Address: {Address.Street}, {Address.City}, {Address.State}, {Address.ZipCode}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        DisplayGrades("Homework", HomeworkGrades);
        DisplayGrades("Projects", ProjectGrades);
        DisplayGrades("Exams", ExamGrades);
    }

    private void DisplayGrades(string type, int[] grades)
    {
        Console.WriteLine($"{type} Grades:");
        if (grades != null)
        {
            Console.WriteLine(string.Join(", ", grades));
        }
        else
        {
            Console.WriteLine("No grades yet...");
        }
    }

    public double GetAverageGrade()
    {
        double totalGrades = homeworkGrades.Sum() + projectGrades.Sum() + examGrades.Sum();
        double totalGradeCount = homeworkGrades.Length + projectGrades.Length + examGrades.Length;
        return totalGrades / totalGradeCount;
    }

    public int GetAverageHomeworkGrade()
    {
        int result = 0;
        if (HomeworkGrades.Length != 0)
        {
            foreach (int grade in HomeworkGrades) result += grade;
            result /= HomeworkGrades.Length;
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        Student obj2 = obj as Student;
        if (obj == null) return false;
        return (obj2.secondName == this.secondName && obj2.firstName == this.firstName &&
            obj2.thirdName == this.thirdName && obj2.birthDay == this.birthDay &&
            obj2.address == this.address && obj2.phoneNumber == this.phoneNumber);
    }

    public static bool operator ==(Student student, Student student2)
    {
        if (ReferenceEquals(student, student2)) return true;
        if ((object)student != null) return student.Equals(student2);
        if ((object)student2 != null) return student2.Equals(student);
        return (student.secondName == student2.secondName && student.firstName == student2.firstName &&
            student.thirdName == student2.thirdName && student.birthDay == student2.birthDay &&
            student.address == student2.address && student.phoneNumber == student2.phoneNumber);
    }
    public static bool operator !=(Student student1, Student student2) { return !(student1 == student2); }
    public static bool operator <(Student student1, Student student2) { return student1.GetAverageHomeworkGrade() < student2.GetAverageHomeworkGrade(); }
    public static bool operator >(Student student1, Student student2) { return student1.GetAverageHomeworkGrade() > student2.GetAverageHomeworkGrade(); }
    public static bool operator <=(Student student1, Student student2) { return student1.GetAverageHomeworkGrade() <= student2.GetAverageHomeworkGrade(); }
    public static bool operator >=(Student student1, Student student2) { return student1.GetAverageHomeworkGrade() >= student2.GetAverageHomeworkGrade(); }
    public static bool operator true(Student student) { return (student.GetAverageHomeworkGrade() >= 7); }
    public static bool operator false(Student student) { return (student.GetAverageHomeworkGrade() < 7); }

    public override string ToString()
    {
        string homeworkGrades = ""; foreach (int grade in HomeworkGrades) homeworkGrades += grade + " ";
        string finalworkGrades = ""; foreach (int grade in ProjectGrades) finalworkGrades += grade + " ";
        string examsGrades = ""; foreach (int grade in ExamGrades) examsGrades += grade + " ";
        string result = $"Full name: {SecondName} {FirstName} {ThirdName}\nDate of birth: {BirthDay.ToShortDateString()}\nAddress: {Address.ToString()}\nPhone number: {PhoneNumber}\nHomework grades: {homeworkGrades}\nFinalwork grades: {finalworkGrades}\nExam grades: {examsGrades}";
        return result;
    }

    public int CompareTo(Student other)
    {
        if (this == other) return 0;
        if (this > other) return 1;
        else return -1;
    }

    public class SortByHomework : IComparer<Student>
    {
        public int Compare(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.homeworkGrades.Average() == secondStudent.homeworkGrades.Average())
            {
                return 0;
            }
            if (firstStudent.homeworkGrades.Average() > secondStudent.homeworkGrades.Average())
            {
                return 1;
            }
            else return -1;
        }
    }

    public class SortByFinalWork : IComparer<Student>
    {
        public int Compare(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.projectGrades.Average() == secondStudent.projectGrades.Average())
            {
                return 0;
            }
            if (firstStudent.projectGrades.Average() > secondStudent.projectGrades.Average())
            {
                return 1;
            }
            else return -1;
        }
    }

    public class SortByExamsWork : IComparer<Student>
    {
        public int Compare(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.examGrades.Average() == secondStudent.examGrades.Average())
            {
                return 0;
            }
            if (firstStudent.examGrades.Average() > secondStudent.examGrades.Average())
            {
                return 1;
            }
            else return -1;
        }
    }
}

