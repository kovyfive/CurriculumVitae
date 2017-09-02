namespace CurriculumViate.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class ParameterDescription
    {
        public Collection<ParameterAnnotation> Annotations { get; } = new Collection<ParameterAnnotation>();

        public string Documentation { get; set; }

        public string Name { get; set; }

        public ModelDescription TypeDescription { get; set; }
    }
}