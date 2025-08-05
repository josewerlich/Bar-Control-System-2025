using Bar_Control_System_2025.Domain.Shared;
using System.Text.RegularExpressions;


namespace Bar_Control_System_2025.Domain.WaiterModule
{
    public class Waiter : BaseEntity<Waiter>
    {
        public string Name { get; set; }
        public string SSN { get; set; }

        public Waiter(string name, string ssn)
        {
            Name = name;
            SSN = ssn;
        }

        public override void UpdateRegister(Waiter updateRegister)
        {
            Name = updateRegister.Name;
            SSN = updateRegister.SSN;
        }

        public override string Validate()
        {
            string errors = string.Empty;

            if (Name.Length < 3 || Name.Length > 100)
                errors += "The field \"Name\" must have between 3 and 100 characters.";

            if (!Regex.IsMatch(SSN, @"^\d{3}-\d{2}-\d{4}$"))
                errors += "The field \"SSN\" must follow the format XXX-XX-XXXX.";

            return errors;



        }
    }
}

