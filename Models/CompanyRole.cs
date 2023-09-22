namespace WarOfRightsWeb.Models
{
    public record CompanyRole
    {
        public long Id { get; init; }

        public string Mention { get; init; }

        public string Name { get; init; }
    }
}
