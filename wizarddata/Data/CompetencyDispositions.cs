using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wizarddata.Data
{
    public class CompetencyDisposition
    {
        public int Id {get; set;}
        public Disposition Disposition{get; set;}

        public int CompetencyId{get; set;}    
        public Competency Competency{get; set;}
    }
}