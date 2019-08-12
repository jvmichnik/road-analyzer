using Levantamento.Consoles.ApiClient.Model;
using Levantamento.Consoles.ApiClient;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.IO;
using System.Linq;

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
                var apiClient = new ServiceClient("http://ec2-18-228-156-207.sa-east-1.compute.amazonaws.com:8080");
                //var apiClient = new ServiceClient("http://localhost:8080");

                //Criar levantamento e deserializar
                var levantamento = new LevantamentoDTO("BR 020", "Teste de levantamento");
                var result = apiClient.CreateLevantamento(levantamento).Result;
                var text = result.Content.ReadAsStringAsync().Result;
                var serialized = JsonConvert.DeserializeObject<ApiResultModel<LevantamentoDTO>>(text);

                //CriarLogs
                Console.WriteLine("Criado: " + serialized.Data.Id);
                var trecho = File.ReadAllLines("DF_020.csv");
                var anterior = new LogDTO();
                for (int i = trecho.Length - 1; i > trecho.Length - 1 - 120; i -= 3)
                {
                    var split = trecho[i].Split(";");
                    var log = new LogDTO(Convert.ToDecimal(split[0]), Convert.ToDecimal(split[1]), Convert.ToDecimal(split[3]), (int)Convert.ToDecimal(split[2]));
                    apiClient.CreateLog(serialized.Data.Id, log);
                    anterior = log;
                    Console.WriteLine("Criado: " + i);
                    Thread.Sleep(1000);
                }
                //var anterior = new LogDTO();
                //for (int i = 0; i < 30; i++)
                //{
                //    Thread.Sleep(1000);
                //    Console.WriteLine("Criado: " + i);
                //    var log = new LogDTO(anterior.Speed, anterior.Long, anterior.Lat);
                //    apiClient.CreateLog(serialized.Data.Id, log);
                //    anterior = log;
                //}

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
