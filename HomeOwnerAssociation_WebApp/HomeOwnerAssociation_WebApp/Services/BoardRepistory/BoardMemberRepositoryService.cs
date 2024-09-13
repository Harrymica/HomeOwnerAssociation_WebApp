using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.BoardRepistory
{
    public class BoardMemberRepositoryService : IBoardMemberRepositoryService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public BoardMemberRepositoryService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddBoardMember(BoardMember boardMember)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.BoardMembers.Add(boardMember);
            await db.SaveChangesAsync();
        }

        public async Task EdithBoardMemeber(BoardMember boardMember)
        {
            using var db = _factory.CreateDbContextAsync();
            var member = await db.Result.BoardMembers.FirstOrDefaultAsync(s => s.Id == boardMember.Id);
            if (member != null)
            {
                member.Email = boardMember.Email;
                member.Phone = boardMember.Phone;
                member.Name = boardMember.Name;

                db.Result.Update(member);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<BoardMember>> GetAllBoardMembersAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.BoardMembers.ToListAsync();

            return await result;
        }

        public async Task<BoardMember> GetBoardMemberById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.BoardMembers.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeleteBoardMemberAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var boardMember = await db.Result.BoardMembers.FirstOrDefaultAsync(s => s.Id == id);
            if (boardMember != null)
            {
                db.Result.Remove(boardMember);
                await db.Result.SaveChangesAsync();
            }
        }

    }
}
