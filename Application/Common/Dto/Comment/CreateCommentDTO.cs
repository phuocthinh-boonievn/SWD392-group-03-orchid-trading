namespace Application.Common.Dto.Comment
{
    public class CreateCommentDTO
    {
        public string CommentMsg { get; set; }

        public int UserID { get; set; } 

        public int InformationID { get; set; }  
    }
}
