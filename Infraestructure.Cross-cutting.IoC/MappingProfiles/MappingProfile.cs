using Aplication.ViewModels;
using AutoMapper;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Cross_cutting.IoC.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JogadorVM, Jogador>().ReverseMap();
            CreateMap<JogoVM, Jogo>().ReverseMap();
        }
       
    }
}
