using Core.Picareta.Comunication;

namespace Core.Picareta.DomainObjects
{
    public abstract class CommandHandlerBase
    {
        private readonly IComunication _comunication;

        public CommandHandlerBase(IComunication comunication)
        {
            _comunication = comunication;
        }

        public virtual bool IsValid(Command command)
        {
            if (command.IsValid()) return true;

            foreach (var error in command.ValidationResult.Errors)
            {
                _comunication.PublicarDomainNotification(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }

            return false;
        }
    }
}
