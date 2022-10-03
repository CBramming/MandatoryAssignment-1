namespace Football
{
    public class FootballPlayer
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int ShirtNumber { get; set; }


        public void ValidateName()
        {
            if (Name.Length < 2 ) throw new ArgumentException("Name must be at least 2 characters: " + Name);
        }

        public void ValidateAge()
        {
            if (Age < 1) throw new ArgumentOutOfRangeException("Age cannot be under 1: " + Age);
        }

        public void ValidateShirtNumber()
        {
            if ((ShirtNumber < 1) || (ShirtNumber > 99)) throw new ArgumentOutOfRangeException("Shirt number must to be between 1 and 99:" + ShirtNumber);
        }

        public void Validate()
        {
            ValidateName();
            ValidateAge();
            ValidateShirtNumber();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Age)}={Age.ToString()}, {nameof(ShirtNumber)}={ShirtNumber.ToString()}}}";
        }
    }
}