namespace WebApplication1
{
    public class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(string n, int a)
        {
            this.name = n;
            this.age = a;
        }

    }
}
