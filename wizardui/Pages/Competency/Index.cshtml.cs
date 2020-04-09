using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using wizarddata.Data;
using wizardrepository;

namespace wizardui.Pages.Competency
{

    public class IndexModel : PageModel
    {

        [BindProperty]
        public IEnumerable<wizarddata.Data.Competency> CompetencyList {get; set;}

        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _UOW;        
        public async Task OnGetAsync()
        {
            //var repository = _UOW.GetRepository<Disposition>();
            var repository = _UOW.GetRepositoryAsync<wizarddata.Data.Competency>();
            _logger.Log(LogLevel.Information, "Competencies Retrieved");
            CompetencyList = await repository.GetListAsync();

        }
    }
}
