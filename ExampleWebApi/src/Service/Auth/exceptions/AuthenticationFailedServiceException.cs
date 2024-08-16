
namespace Auth.Service.Exceptions
{
    public class AuthenticationFailedServiceException : Exception
    {
        public AuthenticationFailedServiceException() : base() { }
        public AuthenticationFailedServiceException(string message) : base(message) { }
        public AuthenticationFailedServiceException(string message, Exception inner) : base(message, inner) { }
    }
}