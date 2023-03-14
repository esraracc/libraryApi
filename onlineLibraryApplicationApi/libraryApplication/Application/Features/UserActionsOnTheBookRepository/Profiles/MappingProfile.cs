using Application.Features.UserActionsOnTheBookRepository.Commands.BookStatusUpdateCommand;
using Application.Features.UserActionsOnTheBookRepository.Commands.CreateUserBook;
using Application.Features.UserActionsOnTheBookRepository.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserActionsOnTheBookRepository.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserActionsOnTheBook, CreatedUserBookDto>().ReverseMap();
            CreateMap<UserActionsOnTheBook, CreateUserBookCommand>().ReverseMap();
            CreateMap<UserActionsOnTheBook, UpdateUserBookStatusCommand>().ReverseMap();
            CreateMap<UserActionsOnTheBook, UpdatedBookStatusDto>().ReverseMap();
        }
    }
}
