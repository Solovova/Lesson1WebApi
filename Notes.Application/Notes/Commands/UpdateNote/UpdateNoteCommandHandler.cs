﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>{
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken){
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(
                note => note.Id == request.Id,
                cancellationToken
            );

            if (entity == null || entity.UserId != request.UserId){
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Title = request.Title;
            entity.Details = request.Details;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}