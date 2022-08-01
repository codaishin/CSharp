// POWER

static int Power(int @base, int exponent) {
	var power = 1;
	for (int i = 0; i < exponent; ++i) {
		power *= @base;
	}
	return power;
}

var result = Power(2, 10);
Console.WriteLine($"2 ^ 10 = {result}");


//PEOPLE

var people = new List<Person>();

AddPerson(people, 42, "Hugo");
AddPerson(people, 33, "Henriette");

foreach (var person in people) {
	Console.WriteLine(person.name);
	Console.WriteLine(person.age);
}

static void AddPerson(List<Person> personList, int age, string name) {
	var person = new Person {
		name = name,
		age = age,
	};
	/* the above is shorthand for:
		var person = new Person();
		person.age = age;
		person.name = name;*/
	personList.Add(person);
}

struct Person {
	public string name;
	public int age;
}
