namespace wizarddata.Data
{
    public class CompetencyDispositions
    {
        public int Id {get; set;}
        public int CompetencyId{get; set;}
        public Competency Competency{get; set;}
        public int DispositionId{get; set;}
        public Disposition Disposition{get; set;}
    }
}