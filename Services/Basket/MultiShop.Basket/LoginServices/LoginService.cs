namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId
        {
            get
            {
                var user = _contextAccessor.HttpContext?.User;

                var userId = user?.FindFirst("sub")?.Value;

                if (userId == null)
                {
                    throw new Exception("sub claim is missing from user");
                }

                return userId;
            }
        }

        string ILoginService.GetUserId
        {
            get => GetUserId;
            set => throw new NotImplementedException();
        }
    }
}