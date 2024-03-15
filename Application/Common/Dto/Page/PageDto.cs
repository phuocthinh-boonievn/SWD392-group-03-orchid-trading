using System.ComponentModel;

namespace Application.Common.Dto.Page
{
    public class PageDto
    {
        [DefaultValue(1)]
        public int PageIndex { get; set; }
        [DefaultValue(10)]
        public int PageSize { get; set; }
    }
}
