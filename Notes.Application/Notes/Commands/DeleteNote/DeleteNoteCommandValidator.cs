﻿using System;
using FluentValidation;

namespace Notes.Application.Notes.Commands.DeleteNote{
    public class DeleteNoteCommandValidator: AbstractValidator<DeleteNoteCommand>{
        public DeleteNoteCommandValidator(){
            RuleFor(deleteNoteCommand => deleteNoteCommand.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand => deleteNoteCommand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}