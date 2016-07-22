namespace LinqToObject
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Average { get; set; }
        internal string Class { get; set; }
        public int Discipline { get; set; }

        public override string ToString()
        {
            return
                $"Student's name: {Name}\nStudent's Age: {Age}\nStudent's average: {Average}\nStudent's class: {Class}\nStudent's discipline: {Discipline}";
        }
    }
}
