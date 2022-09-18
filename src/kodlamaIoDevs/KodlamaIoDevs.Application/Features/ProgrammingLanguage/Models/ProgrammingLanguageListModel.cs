using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Dtos;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Models
{
    public class ProgrammingLanguageListModel: BasePageableModel
    {
        public List<ProgrammingLanguageDto> Items { get; set; }

    }
}
