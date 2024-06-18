using Dapper;
using StickyNotesCore.Domain.Models;
using System.Data;
using System.Reflection.Metadata;

namespace StickyNotesCore.Domain.Logic.Repository
{
    public class Notes : INotes
    {
        public IDbConnection _connection;
        public Notes(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task DeleteNote(Guid id)
        {
            var dp = new DynamicParameters();
            dp.Add("@Id", id);
            await _connection.QueryAsync(
                   param: dp,
                  sql: "DeleteNoteById",
                  commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Note>> GetAllNotes()
        {
    
            var resultlist= await _connection.QueryAsync<Note>(
                sql: "GetAllNotes",
                commandType: CommandType.StoredProcedure); 
            return resultlist.ToList();
        }

        public async Task<Note> GetDetailById(Guid id)
        {
            var dp = new DynamicParameters();
            dp.Add("@Id", id);
            return await _connection.QueryFirstOrDefaultAsync<Note>(
                sql: "GetDetailById",
                param: dp,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Note> InsertUpdateNotes(Note note)
        {
           
                var dp = new DynamicParameters();
                dp.Add("@Id", note.Id);
                dp.Add("@Texts", note.Text);
                var result = await _connection.ExecuteScalarAsync<Guid>(
                    sql: "InsertUpdateNotes",
                    param: dp,
                    commandType: CommandType.StoredProcedure);

            var dpnote = new DynamicParameters();
            dpnote.Add("@Id", result);
            var notedetail= await _connection.QueryFirstOrDefaultAsync<Note>(
                sql: "GetDetailById",
                param: dpnote,
                commandType: CommandType.StoredProcedure);
            return notedetail;
        }

        public async Task<Note> UpdateNotes(Note note)
        {
            var dp = new DynamicParameters();
            dp.Add("@Id", note.Id);
            dp.Add("@Texts", note.Text);
           var Updateddetails  = await _connection.ExecuteScalarAsync<Note>(
                sql: "InsertUpdateNotes",
                param: dp,
                commandType: CommandType.StoredProcedure);
            return Updateddetails;
        }
    }
}
