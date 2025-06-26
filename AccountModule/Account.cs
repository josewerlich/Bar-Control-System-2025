

using Bar_Control_System_2025.WaiterModule;

namespace Bar_Control_System_2025.AccountModule
{
    public class Account : BaseEntity<Account>
    {
        public string Customer;
        public Table Table;
        public Waiter Waiter;
        public DateTime DateTimeOpening;
        public DateTime DateTimeClosing;
        public bool StillOpen; 
        public Order[] Order; 

        public Account(string customer, Table table, Waiter waiter)
        {
            Titular = titular;
            Mesa = mesa;
            Garcom = garcom;
            Pedidos = new Pedido[100];

            Abrir();
        }

        public override void UpdateRegister(Conta registroAtualizado)
        {
            EstaAberta = registroAtualizado.EstaAberta;
            Fechamento = registroAtualizado.Fechamento;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Titular.Length < 3 || Titular.Length > 100)
                erros += "O campo \"Titular\" deve conter entre 3 e 100 caracteres.";

            if (Mesa == null)
                erros += "O campo \"Mesa\" é obrigatório.";

            if (Garcom == null)
                erros += "O campo \"Garçom\" é obrigatório.";

            return erros;
        }

        public void Abrir()
        {
            EstaAberta = true;
            Abertura = DateTime.Now;

            Mesa.Ocupar();
        }

        public void Fechar()
        {
            EstaAberta = false;
            Fechamento = DateTime.Now;

            Mesa.Desocupar();
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0;

            for (int i = 0; i < Pedidos.Length; i++)
            {
                if (Pedidos[i] == null)
                    continue;

                valorTotal += Pedidos[i].CalcularTotalParcial();
            }
            return valorTotal;
        }


        public Pedido RegistrarPedido(Produto produto, int quantidadeEscolhida)
        {
            Pedido novoPedido = new Pedido(produto, quantidadeEscolhida);

            Pedidos[EncontrarIndicePedidosVazio()] = novoPedido;

            return novoPedido;
        }

        public void RemoverPedido(int idPedido)
        {
            int indiceParaRemover = -1;

            for (int i = 0; i < Pedidos.Length; i++)
            {
                if (Pedidos[i] == null) continue;

                if (Pedidos[i].Id == idPedido)
                {
                    indiceParaRemover = i;
                    break;
                }
            }

            Pedidos[indiceParaRemover] = null;
        }

        private int EncontrarIndicePedidosVazio()
        {
            for (int i = 0; i < Pedidos.Length; i++)
            {
                if (Pedidos[i] == null)
                    return i;
            }

            return -1;
        }
    }

}
