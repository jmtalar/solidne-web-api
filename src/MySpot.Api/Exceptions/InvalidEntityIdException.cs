namespace MySpot.Api.Exceptions;

public class InvalidEntityIdException : CustomException
{
    private Guid value;

    public InvalidEntityIdException(Guid value)
        : base($"Entity value: {value} is invalid")
    {
        this.value = value;
    }
}
