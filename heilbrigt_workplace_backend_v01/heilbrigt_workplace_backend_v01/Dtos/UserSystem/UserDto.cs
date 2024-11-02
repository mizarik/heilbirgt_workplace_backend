namespace heilbrigt_workplace_backend_v01.Dtos.UserSystem
{
    public class UserBaseDto
    {
        public string email { get; set; } = string.Empty;

        public string userid { get; set; } = string.Empty;

        public int adminlevel { get; set; } = 0;
    }

    public class UserFullDto : UserBaseDto
    {
        public string firstname { get; set; } = string.Empty;

        public string lastname { get; set; } = string.Empty;
    }
}
