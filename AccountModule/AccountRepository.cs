using static System.Net.Mime.MediaTypeNames;

namespace Bar_Control_System_2025.AccountModule;

    public class AccountRepository
    {
        protected Account[] registers = new Account[100];
        protected int registerCounter = 0;
        protected int idCounter = 0;

        public void Register(Account newAccount)
        {
            newAccount.id = ++idCounter;

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

                if (register.id == idSelected)
                    return register;
            }

            return null;
        }
    }