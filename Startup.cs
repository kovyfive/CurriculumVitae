﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CurriculumViate.Startup))]

namespace CurriculumViate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
