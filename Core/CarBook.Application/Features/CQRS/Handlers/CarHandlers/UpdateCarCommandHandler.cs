using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarId);
            values.Fuel = command.Fuel;
            values.Km = command.Km;
            values.CarId = command.CarId;
            values.BigImageUrl = command.BigImageUrl;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Transmission = command.Transmission;
            values.BrandId = command.BrandId;
            values.Luggage = command.Luggage;
            values.Model = command.Model;
            values.Seat = command.Seat;
            await _repository.UpdateAsync(values);
        }
    }
}