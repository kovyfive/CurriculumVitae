namespace CurriculumVitae.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class ComplexTypeModelDescription : ModelDescription
    {
        public Collection<ParameterDescription> Properties { get; } = new Collection<ParameterDescription>();
    }
}