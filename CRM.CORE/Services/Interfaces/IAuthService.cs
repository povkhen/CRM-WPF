namespace CRM.CORE
{
    interface IAuthService
    {
        void Login();
        void Register();
        bool LoggedIn();
        bool RoleMatch();
    }
}
