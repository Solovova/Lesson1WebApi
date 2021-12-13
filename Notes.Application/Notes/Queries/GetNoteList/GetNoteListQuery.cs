using System;
using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteList{
    public class GetNoteListQuery: IRequest<NoteListVm>{
        public Guid UserID{ get; set; }
    }
}