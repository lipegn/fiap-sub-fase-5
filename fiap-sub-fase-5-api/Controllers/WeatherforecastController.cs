using Microsoft.AspNetCore.Mvc;

namespace fiap_sub_fase_5_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] CidadesBrasileiras = { "S�o Paulo", "Rio de Janeiro", "Bras�lia", "Salvador", "Belo Horizonte" };

        [HttpGet]
        public IEnumerable<String> Cidades()
        {
            return CidadesBrasileiras;
        }

        [HttpGet("condicoes-atuais")]
        public IEnumerable<PrevisaoTempo> ObterPrevisoesTempo()
        {
            var rng = new Random();
            var previsoes = new List<PrevisaoTempo>();

            foreach (var cidade in CidadesBrasileiras)
            {
                var temperaturaC = rng.Next(15, 35);
                previsoes.Add(new PrevisaoTempo
                {
                    Cidade = cidade,
                    Data = DateTime.Now,
                    TemperaturaC = temperaturaC,
                    Resumo = ObterResumo(temperaturaC)
                });
            }

            return previsoes;
        }

        [HttpGet("previsao-cinco-dias")]
        public IEnumerable<PrevisaoTempo> ObterPrevisaoCincoDias()
        {
            var rng = new Random();
            var previsoes = new List<PrevisaoTempo>();

            foreach (var cidade in CidadesBrasileiras)
            {
                for (int i = 0; i < 5; i++)
                {
                    var temperaturaC = rng.Next(15, 35);
                    previsoes.Add(new PrevisaoTempo
                    {
                        Cidade = cidade,
                        Data = DateTime.Now.AddDays(i),
                        TemperaturaC = temperaturaC,
                        Resumo = ObterResumo(temperaturaC)
                    });
                }
            }

            return previsoes;
        }

        private static string ObterResumo(int temperaturaC)
        {
            return temperaturaC switch
            {
                var temp when temp < 0 => "Congelante",
                var temp when temp < 5 => "Friozinho",
                var temp when temp < 10 => "Frio",
                var temp when temp < 15 => "Frio agradavel",
                var temp when temp < 20 => "Agrad�vel",
                var temp when temp < 25 => "Moderado",
                var temp when temp < 30 => "Calor",
                _ => "Muito Calor",
            };
        }
    }
}