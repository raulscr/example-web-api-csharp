namespace Auth.Controller.Model
{
    class UserLoginServiceAdapter : Service.Model.UserLoginModel
    {
        private readonly UserLoginRequest _adaptee;

        public UserLoginServiceAdapter(UserLoginRequest adaptee)
        {
            this._adaptee = adaptee;
            this.Login = _adaptee.Login;
            this.Password = _adaptee.Password;
        }
    }
}
