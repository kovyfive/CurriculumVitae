namespace CurriculumVitae.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class EnumTypeModelDescription : ModelDescription
    {
        public Collection<EnumValueDescription> Values { get; } = new Collection<EnumValueDescription>();
    }
}