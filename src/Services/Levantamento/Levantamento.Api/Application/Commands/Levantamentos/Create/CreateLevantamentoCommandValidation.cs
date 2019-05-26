
namespace Levantamento.Api.Application.Commands.Levantamentos.Create
{
    public class CreateLevantamentoCommandValidation : LevantamentoValidation<CreateLevantamentoCommand>
    {
        public CreateLevantamentoCommandValidation()
        {
            ValidateName();
            ValidateDescription();
        }
    }
}
