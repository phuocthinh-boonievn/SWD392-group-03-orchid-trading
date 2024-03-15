using Application.Common.Dto.Comment;

namespace Application.Common.Dto.Information
{
    public class InformationViewDTO
    {
        public string Image {  get; set; }

        public string Title { get; set; }

        public float Bid {  get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public List<ViewCommentDTO> viewCommentDTOs { get; set; }
    } 
}
