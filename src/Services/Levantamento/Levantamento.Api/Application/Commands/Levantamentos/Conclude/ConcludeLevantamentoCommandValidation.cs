
namespace Levantamento.Api.Application.Commands.Levantamentos.Conclude
{
    public class ConcludeLevantamentoCommandValidation : LevantamentoValidation<ConcludeLevantamentoCommand>
    {
        public ConcludeLevantamentoCommandValidation()
        {
            ValidateId();
            ValidateEnd();
        }
    }
}
