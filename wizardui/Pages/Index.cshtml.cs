using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using wizarddata.Data;
using wizardrepository;

namespace wizardui.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Disposition> DispositionList {get; set;}

        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _UOW;

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;            
        }

        public async Task OnGetAsync()
        {
            //var repository = _UOW.GetRepository<Disposition>();
            var repository = _UOW.GetRepositoryAsync<Disposition>();
            _logger.Log(LogLevel.Information, "PHELPS");
            DispositionList = await repository.GetListAsync();

        }
    }
}
