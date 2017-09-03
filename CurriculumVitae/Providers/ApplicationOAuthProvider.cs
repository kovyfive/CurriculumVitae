namespace CurriculumVitae.Providers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Owin.Security.OAuth;

    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException(nameof(publicClientId));
            }

            this.publicClientId = publicClientId;
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId != this.publicClientId)
            {
                return Task.FromResult<object>(null);
            }

            var expectedRootUri = new Uri(context.Request.Uri, "/");

            if (expectedRootUri.AbsoluteUri == context.RedirectUri)
            {
                context.Validated();
            }
            else if (context.ClientId == "web")
            {
                context.Validated(expectedRootUri.AbsoluteUri);
            }

            return Task.FromResult<object>(null);
        }
    }
}