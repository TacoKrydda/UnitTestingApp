using System.Text.Json;
using UnitTesting.Models;

namespace TestProject
{
    public class PersonTests
    {
        [Fact]
        public void Person_SetProperties_IdFirstNameLastNameAge()
        {
            // Arrange
            var person = new Person();

            // Act
            person.Id = 1;
            person.FirstName = "John";
            person.LastName = "Doe";
            person.Age = 30;

            // Assert
            Assert.Equal(1, person.Id);
            Assert.Equal("John", person.FirstName);
            Assert.Equal("Doe", person.LastName);
            Assert.Equal(30, person.Age);
        }

        [Fact]
        public void Person_IsOver18_WhenAgeIsOver18_ReturnsTrue()
        {
            // Arrange
            var person = new Person();
            person.Age = 25;

            // Act
            bool isOver18 = person.Age >= 18;

            // Assert
            Assert.True(isOver18);
        }

        [Fact]
        public void Person_IsOver18_WhenAgeIsUnder18_ReturnsFalse()
        {
            // Arrange
            var person = new Person();
            person.Age = 15;

            // Act
            bool isOver18 = person.Age >= 18;

            // Assert
            Assert.False(isOver18);
        }

        [Theory]
        [InlineData(-1)] // Ålder är negativ
        [InlineData(151)] // Ålder över maximal ålder
        public void Person_InvalidAge_ThrowsArgumentException(int age)
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.Age = age);
        }

        [Theory]
        [InlineData(0)] // Minsta ålder
        [InlineData(18)] // Ålder precis vid gränsen
        [InlineData(150)] // Maximal ålder
        public void Person_ValidAge_DoesNotThrowException(int age)
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Null(Record.Exception(() => person.Age = age));
        }

        [Theory]
        [InlineData(null)] // Förnamn är null
        [InlineData("")] // Förnamn är tom sträng
        public void Person_InvalidFirstName_ThrowsArgumentException(string firstName)
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.FirstName = firstName);
        }

        [Theory]
        [InlineData("John")] // Giltigt förnamn
        [InlineData("Jane")] // Ett annat giltigt förnamn
        public void Person_ValidFirstName_DoesNotThrowException(string firstName)
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Null(Record.Exception(() => person.FirstName = firstName));
        }

        [Theory]
        [InlineData(null)] // Efternamn är null
        [InlineData("")] // Efternamn är tom sträng
        public void Person_InvalidLastName_ThrowsArgumentException(string lastName)
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.LastName = lastName);
        }

        [Theory]
        [InlineData("Doe")] // Giltigt efternamn
        [InlineData("Smith")] // Ett annat giltigt efternamn
        public void Person_ValidLastName_DoesNotThrowException(string lastName)
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Null(Record.Exception(() => person.LastName = lastName));
        }

        [Fact]
        public void Person_Equality_TwoEqualPersons_ReturnsTrue()
        {
            // Arrange
            var person1 = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };
            var person2 = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };

            // Act & Assert
            Assert.Equal(person1.Id, person2.Id);
            Assert.Equal(person1.FirstName, person2.FirstName);
            Assert.Equal(person1.LastName, person2.LastName);
            Assert.Equal(person1.Age, person2.Age);
        }

        [Fact]
        public void Person_Equality_TwoDifferentPersons_ReturnsFalse()
        {
            // Arrange
            var person1 = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };
            var person2 = new Person { Id = 2, FirstName = "Jane", LastName = "Smith", Age = 25 };

            // Act & Assert
            Assert.NotEqual(person1.Id, person2.Id);
            Assert.NotEqual(person1.FirstName, person2.FirstName);
            Assert.NotEqual(person1.LastName, person2.LastName);
            Assert.NotEqual(person1.Age, person2.Age);
        }

        [Fact]
        public void Person_SerializationAndDeserialization_ReturnsEqualObject()
        {
            // Arrange
            var originalPerson = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };

            // Act
            string json = JsonSerializer.Serialize(originalPerson);
            var deserializedPerson = JsonSerializer.Deserialize<Person>(json);

            // Assert
            Assert.NotNull(deserializedPerson);
            Assert.Equal(originalPerson.Id, deserializedPerson.Id);
            Assert.Equal(originalPerson.FirstName, deserializedPerson.FirstName);
            Assert.Equal(originalPerson.LastName, deserializedPerson.LastName);
            Assert.Equal(originalPerson.Age, deserializedPerson.Age);
        }

        [Fact]
        public void Person_ChangeProperties_NewValuesSetCorrectly()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };

            // Act
            person.Id = 2;
            person.FirstName = "Jane";
            person.LastName = "Smith";
            person.Age = 25;

            // Assert
            Assert.Equal(2, person.Id);
            Assert.Equal("Jane", person.FirstName);
            Assert.Equal("Smith", person.LastName);
            Assert.Equal(25, person.Age);
        }

    }
}