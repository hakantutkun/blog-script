using BlogScript.DTOs.Abstract;

namespace BlogScript.DTOs.DTOs.CategoryDTOs
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
