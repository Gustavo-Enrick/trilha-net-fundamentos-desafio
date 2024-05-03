namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine().ToUpper());
            Console.WriteLine("Placa adiciona com sucesso!");
        }

        public void RemoverVeiculo()
        {
            if(VerificaSeExisteCarroNaLista())
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                // Pedir para o usuário digitar a placa e armazenar na variável placa
                // *IMPLEMENTE AQUI*
                string placa = Console.ReadLine().ToUpper();

                // Verifica se o veículo existe
                if (veiculos.Any(x => x == placa))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    string horas = Console.ReadLine();
                    decimal valorTotal = CalculaPreco(Convert.ToDecimal(horas));

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    
                    for (int i = 0; i < veiculos.Count; i++)
                    {
                        if(veiculos[i] == placa)
                        {
                            veiculos.RemoveAt(i);
                            break;
                        }
                    }
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:0.00}");
                    
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public decimal CalculaPreco(decimal horas)
        {
            decimal preco = precoInicial + precoPorHora * horas;
            return preco;
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (VerificaSeExisteCarroNaLista())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine($"Veículo com placa: {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool VerificaSeExisteCarroNaLista()
        {
            return veiculos.Count != 0;
        }

        public bool FinalizarPrograma()
        {
            bool encerrarPrograma = false;
            if (VerificaSeExisteCarroNaLista())
            {
                bool sair = false;
                while (!sair)
                {
                    Console.WriteLine("Ainda existem carros na lista. Deseja finalizar o programa mesmo assim? (S/N)");
                    string resposta = Console.ReadLine().ToUpper();
                    if (resposta == "S")
                    {
                        sair = true;
                        encerrarPrograma =  true;
                    }
                    else if (resposta == "N")
                    {
                        sair = true;
                    }
                    else
                    {
                        Console.WriteLine("Resposta Inválida. Por favor, responda S ou N.");
                    }
                }
            }
            return encerrarPrograma;
        }
    }
}
