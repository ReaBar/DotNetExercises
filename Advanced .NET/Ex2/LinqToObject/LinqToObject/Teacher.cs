namespace LinqToObject
{
    class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public decimal Salary { get; set; }
        public string Discipline { get; set; }


        public override string ToString()
        {
            return $"Teacher's name: {Name}\nTeacher's age: {Age}\nTeacher's class: {Class}\nTeacher's Salary: {Salary}\nTeacher's discipline: {Discipline}";
        }
    }
}
