namespace FirstApi2.Classes
{
    public class Person
    {
        public Person(string id, string name, int age)
        {
           Id = id;
           Name = name;
           Age = age;
        }
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
