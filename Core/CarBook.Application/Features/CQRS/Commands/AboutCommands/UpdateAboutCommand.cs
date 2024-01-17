﻿namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
    public class UpdateAboutCommand
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagUrl { get; set; }
    }
}
