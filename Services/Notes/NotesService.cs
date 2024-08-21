﻿using Microsoft.EntityFrameworkCore;
using TasterNotes.Application.Models.Notes;
using TasterNotes.Persistence;
using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Services.Notes
{
    public class NotesService(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<Note> Create(CreateNoteDto model, Guid userId)
        {
            var note = await _db.Notes.AddAsync(model.ToNote(userId));
            await _db.SaveChangesAsync();

            return note.Entity;
        }

        public async Task<List<Note>> GetAllByUserAsync(int userId)
        {
            return await _db.Notes.AsNoTracking().Where(n => n.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<Note?> GetById(int noteId, int userId)
        {
            var note = await _db.Notes
                .AsNoTracking()
                .Include(n => n.Taste)
                .Include(n => n.DescriptorSet)
                .Include(n => n.Dishware)
                .SingleOrDefaultAsync(n => n.NoteId.Equals(noteId));

            return note;
        }
    }
}
