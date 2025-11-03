using Turn100YearsCalcul;

namespace Turn100YearsCalculTest
{
    public class Tests
    {
        [Test]
        public void SetNameAge_ValidInput_SetsProperties()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("John Doe", 30);
            Assert.That(person.Name, Is.EqualTo("John Doe"));
            Assert.That(person.Age, Is.EqualTo(30));
        }


        [Test]
        public void SetNameAge_nonValidInput_SetsProperties()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge(" ", -1);
            Assert.That(person.Name, Is.EqualTo(" "));
            Assert.That(person.Age, Is.EqualTo(-1));
        }

        [Test]
        public void CalculateYearWhen100_ValidAge_ReturnsCorrectYear()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("Jane Smith", 25);
            int currentYear = DateTime.Now.Year;
            int expectedYear = currentYear + (100 - 25);
            Assert.That(expectedYear, Is.EqualTo(person.CalculateYearWhen100()));
        }

        [Test]
        public void CalculateYearWhen100_nonValidAge0_ReturnsCorrectYear()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("Jane S", 0);
            int currentYear = DateTime.Now.Year;
            int expectedYear = currentYear + (100 - 0);
            Assert.That(expectedYear, Is.EqualTo(person.CalculateYearWhen100())); // checking that
        }

        [Test]
        public void CalculateYearWhen100_nonValidAge130_ReturnsCorrectYear()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("Jane S", 131);
            int currentYear = DateTime.Now.Year;
            int expectedYear = currentYear + (100 - 131);
            Assert.That(expectedYear, Is.EqualTo(person.CalculateYearWhen100())); // checking that
        }

        [Test]
        public void CalculateYearWhen100_ValidAge120_ReturnsCorrectYear() // check that 
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("Jane t", 120); // checking that
            int currentYear = DateTime.Now.Year;
            int expectedYear = currentYear + (100 - 120);
            Assert.That(expectedYear, Is.EqualTo(person.CalculateYearWhen100())); // checking that
        }

        [Test]
        public void CalculateYearWhen100_Age100_ReturnsCurrentYear()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("Old Person", 100);
            int currentYear = DateTime.Now.Year;
            Assert.That(currentYear, Is.EqualTo(person.CalculateYearWhen100()));
        }

        [Test]
        public void CalculateYearWhen100_AgeOver100_ReturnsPastYear()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("Very Old Person", 110);
            int currentYear = DateTime.Now.Year;
            int expectedYear = currentYear + (100 - 110);
            Assert.That(expectedYear, Is.EqualTo(person.CalculateYearWhen100()));
        }

        [Test]
        public void CalculateYearWhen100_AgeNearZero_ReturnsFutureYear()
        {
            NameAgeCal person = new NameAgeCal();
            person.SetNameAge("Young Person", 18);
            int currentYear = DateTime.Now.Year;
            int expectedYear = currentYear + (100 - 18);
            Assert.That(expectedYear, Is.EqualTo(person.CalculateYearWhen100()));
        }


    }
}