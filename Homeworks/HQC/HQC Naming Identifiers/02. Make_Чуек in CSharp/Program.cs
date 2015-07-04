//Refactor the following examples to produce code with well-named C# identifiers.

class Hauptklasse
{
    enum Gender
    {
        male,
        female
    };

    class Person
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public void makeNewPerson(int personId)
    {
        Person currentPerson = new Person();
        currentPerson.Age = personId;

        if (personId % 2 == 0)
        {
            currentPerson.Name = "Батката";
            currentPerson.Gender = Gender.male;
        }
        else
        {
            currentPerson.Name = "Мацето";
            currentPerson.Gender = Gender.female;
        }
    }
}