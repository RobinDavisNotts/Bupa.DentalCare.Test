using FluentResults;

namespace Bupa.DentalCare.Test.Store;

public class ErrorResultAction
{
    public ErrorResultAction(List<IError> errorMessages)
    {
        ErrorMessages = errorMessages;
    }

    public List<IError> ErrorMessages { get;  }
}