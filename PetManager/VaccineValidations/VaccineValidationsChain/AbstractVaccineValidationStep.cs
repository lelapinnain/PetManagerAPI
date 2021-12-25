using PetManager.ErrorHandlers;

namespace PetManager.VaccineValidations.VaccineValidationsChain
{
    public abstract class AbstractVaccineValidationStep
    {
        protected AbstractVaccineValidationStep nextValidationStep = null;

        public void setNextValidationStep(AbstractVaccineValidationStep _nextValidationStep)
        {
            nextValidationStep = _nextValidationStep;
        }

        public abstract APIResponse validate();
    }
}
