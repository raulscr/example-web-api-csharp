namespace Auth.Controller.Model
{
    class UserLoginServiceAdapter : Service.Model.UserLoginModel
    {
        private readonly UserLoginModel _adaptee;

        public UserLoginServiceAdapter(UserLoginModel adaptee)
        {
            this._adaptee = adaptee;
            this.Login = _adaptee.Login;
            this.Password = _adaptee.Password;
        }
    }
}
