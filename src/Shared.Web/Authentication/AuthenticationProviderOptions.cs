namespace Shared.Web.Authentication
{

    using System.ComponentModel.DataAnnotations;


    public sealed class OAuthProviderOptions
    {
        public const string SectionName = "OauthProviderOptions";

        [Required]
        public string Instance { get; set; } = string.Empty;

        [Required]
        public string TenantId { get; init; } = string.Empty;

        [Required]
        public string ClientId { get; init; } = string.Empty;

        [Required]
        public string ClientSecret { get; init; } = string.Empty;

    }

}
