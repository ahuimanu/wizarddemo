using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wizarddata.Data
{
    public class Competency
    {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        [DataType(DataType.Text)]
        public string Description {get; set;}

        public IEnumerable<Disposition> Dispostions {get; set;}

    }

    public class AtomicCompetency : Competency 
    {
        public Dictionary<KnowledgeElement, SkillLevel> KSPairs {get; set;}
    }
    public class CompositeCompetency : Competency
    {
        IEnumerable<Competency> ConstituentCompetencies {get; set;}
    }
}