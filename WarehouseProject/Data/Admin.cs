
namespace WarehouseProject.Data
{

    class Admin
    {
        private string paswd;
        public string Name { get; } = "Arno Slabbinck";
        public string Email { get; } = "Arno.Slabbinck@hotmail.com";
        public string Role { get; } = "Admin";
        public string Username { get; } = "Arno";

        public string AuthenticationType { get { return "Admin authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
        //

        public string Password
        {
            get
            {
                using (var ctx = new WarehouseDataAccess.WarehouseDBContext())
                {
                    paswd = ctx.Supervisor.Find().Password;
                }
                return paswd;
            }
        }

    }
}