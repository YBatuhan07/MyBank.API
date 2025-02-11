namespace MyBank.Services.ExceptionHandler;

public  class CriticalException(string message) : Exception(message);
