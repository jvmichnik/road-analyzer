using Levantamento.Consoles.ApiClient.Model;
using Levantamento.Consoles.ApiClient;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace Levantamento.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Começando");
            Console.ReadLine();
            var cond = "";
            while (cond != "y")
            {
                var apiClient = new ServiceClient("http://localhost:8080");

                //Criar levantamento e deserializar
                var levantamento = new LevantamentoDTO("Teste", "Teste2");
                var result = apiClient.CreateLevantamento(levantamento).Result;
                var text = result.Content.ReadAsStringAsync().Result;
                var serialized = JsonConvert.DeserializeObject<ApiResultModel<LevantamentoDTO>>(text);

                //CriarLogs
                Console.WriteLine("Criado: " + serialized.Data.Id);
                var anterior = new LogDTO();
                for (int i = 0; i < 30; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Criado: " + i);
                    var log = new LogDTO(anterior.Speed,anterior.Long,anterior.Lat);
                    apiClient.CreateLog(serialized.Data.Id, log);
                    anterior = log;
                }

                //Concluir
                Thread.Sleep(1000);
                var resultConcluded = apiClient.ConcludeLevantamento(serialized.Data.Id).Result;

                Console.WriteLine("Concluido!!");
                Console.WriteLine("Deseja sair?");
                cond = Console.ReadLine();
            }
        }
    }
}
