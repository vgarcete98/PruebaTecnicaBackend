namespace PruebaTecnicaBackend.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery
	{
        public bool? isActive { get; set; }
        public GetUsersQuery(bool? is_active)
        {

            isActive = is_active;
        }

    }
}
