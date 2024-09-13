using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.BoardRepistory
{
    public interface IBoardMemberRepositoryService
    {
        Task AddBoardMember(BoardMember boardMember);
        Task DeleteBoardMemberAsync(int id);
        Task EdithBoardMemeber(BoardMember boardMember);
        Task<List<BoardMember>> GetAllBoardMembersAsync();

        Task<BoardMember> GetBoardMemberById(int Id);
    }
}