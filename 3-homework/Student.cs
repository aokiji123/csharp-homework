public class Student
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

}

