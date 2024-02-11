namespace UnitTesting.Models
{
    public class Person
    {
        private int _age;
        private string? _firstName;
        private string? _lastName;

        public int Id { get; set; }

        public string? FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }
                _firstName = value;
            }
        }

        public string? LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }
                _lastName = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Age must be between 0 and 150.");
                }
                _age = value;
            }
        }
    }
}
