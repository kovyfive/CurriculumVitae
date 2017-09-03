using CurriculumVitae;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CurriculumVitae
{
    using Owin;

    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}