namespace MyRecipeBook.Exceptions.ExceptionsBase;

public class ErrorOnValidateException : MyRecipeBookException
{

    public IList<string> ErrorsMessages { get; set; }

    public ErrorOnValidateException(IList<string> ErrorsMessages)
    {
        this.ErrorsMessages = ErrorsMessages;
    }
}
