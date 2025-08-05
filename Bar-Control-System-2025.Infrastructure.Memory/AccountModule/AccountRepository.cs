using Bar_Control_System_2025.Domain.AccountModule;


namespace Bar_Control_System_2025.Infrastructure.Memory.AccountModule;

    public class AccountRepository
    {
        protected Account[] registers = new Account[100];
        protected int registerCounter = 0;
        protected int idCounter = 0;

        public void Register(Account newAccount)
        {
            newAccount.Id = ++idCounter;

            registers[registerCounter++] = newAccount;
        }

        public Account[] SelectAccount()
        {
            return registers;
        }

        public Account SelectAccountViaID(int idSelected)
        {
            for (int i = 0; i < registers.Length; i++)
            {
                Account register = registers[i];

                if (register == null)
                    continue;

                if (register.Id == idSelected)
                    return register;
            }

            return null;
        }
    }