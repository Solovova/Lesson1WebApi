﻿using System;
using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>{
        public GetNoteListQueryValidator(){
            RuleFor(getNoteListQuery => getNoteListQuery.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}