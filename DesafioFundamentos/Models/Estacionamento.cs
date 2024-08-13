using System.Text.RegularExpressions;

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
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            if (IsPlacaValida(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi adicionado ao estacionamento");
            }
            else
            {
                Console.WriteLine("Placa inválida. Por favor, digite uma placa no formato correto (ABC-1234).");
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {



            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();


            if (IsPlacaValida(placa) && veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido para as horas.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, Placa inválida ou esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos)
                    Console.WriteLine(veiculo);


            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool IsPlacaValida(string placa)
        {
            string pattern = @"^[A-Z]{3}-\d{4}$";
            return Regex.IsMatch(placa.ToUpper(), pattern);
        }
    }
}
